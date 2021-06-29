using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Apex.Diagnostics.Contracts;
using Apex.Diagnostics.Logging;
using Apex.Eligibility;
using Apex.Models.Basic;
using Apex.Models.Common;
using Apex.Models.JsonSupport;
using Apex.PayerServices.Adapters;
using Apex.PayerServices.Apex1;
using Apex.PayerServices.ClaimStatusModel;
using Apex.PayerServices.ClaimStatusModel.WorkQueue;
using Apex.PayerServices.Contracts;
using Apex.PayerServices.Contracts.Errors;
using Apex.PayerServices.DataObjects;
using Apex.PayerServices.PayerModel;
using Apex.PayerServices.PayerModel.Eligibility;
using Apex.ServiceFoundation;
using Apex.ServiceFoundation.Attributes;
using Apex.Utility;
using Apex.Utility.Collections;
using Apex.Utility.Linq;
using JetBrains.Annotations;
using LinqToDB;
using LinqToDB.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Apex.PayerServices
{
	[ServiceImplementation]
	internal class PayerDataManager : IPayerDataManager
	{
		private static readonly ILog _log = LogManager.ClassLogger;
        private const int DeadlockRetryAttempts = 3;
        private const int DeadlockRetryIntervalMs = 2000;

		private VendorDataManager _vendorDataManager;

		private bool HandleError(Exception ex)
		{
			_log.LogExceptionIf(ex);

			var sqlex = ex as SqlException;
			if (sqlex == null)
			{
				return false;
			}

            const int DuplicateEntryError = 2601;
			const int nullValueError = 515;
			const int userSeverity = 16;
            const int userSeverity14 = 14;

			if (sqlex.Class == userSeverity &&
				sqlex.ErrorCode == nullValueError)
			{
				throw MissingValueError.Create(sqlex.Message);
			}

            if (sqlex.Class == userSeverity14 &&
                sqlex.ErrorCode == DuplicateEntryError)
            {
                return true;
            }

			return false;
		}

		[ServiceInitializeMethod]
		[UsedImplicitly]
		private void Initialize(NameValueCollection settings, string serviceName)
		{
			_log.Info("Starting payer data manager");

			const string apex1Connection = "Apex1Connection";
			const string apex2Connection = "Apex2Connection";


			LinqToDB.Common.Configuration.Linq.AllowMultipleQuery = true;
			//LinqToDb.Common.Configuration.Linq.GenerateExpressionTest = true;

			var apex1ConnectionString = settings.GetAsString(apex1Connection);
			if (apex1ConnectionString.IsNullOrEmpty())
			{
				_log.Error("Missing apex 1 connection string");
				throw new AbortStartException("Missing apex 1 connection string");
			}

			var apex2ConnectionString = settings.GetAsString(apex2Connection);
			if (apex2ConnectionString.IsNullOrEmpty())
			{
				_log.Error("Missing apex 2 connection string");
				throw new AbortStartException("Missing apex 2 connection string");
			}

			var dsMatch = Regex.Match(apex1ConnectionString, @"Data\s+Source\s*=\s*(?<ds>[^;]+)");
			if (dsMatch.Success)
			{
				_log.InfoFormat("Apex1 Data source: {0}", dsMatch.Groups["ds"].Value);
			}

			dsMatch = Regex.Match(apex2ConnectionString, @"Data\s+Source\s*=\s*(?<ds>[^;]+)");
			if (dsMatch.Success)
			{
				_log.InfoFormat("Apex2 Data source: {0}", dsMatch.Groups["ds"].Value);
			}

			DataConnection.DefaultDataProvider = ProviderName.SqlServer2008;
			DataConnection.AddConfiguration(Apex1DataContext.DbName, apex1ConnectionString);
			DataConnection.AddConfiguration(PayerDataContext.DbName, apex2ConnectionString);

			var updateEventRate = new TimeSpan(0, 0, 5);
			RemotingManager.CreateEventChannel<WorkQueueUpdateEvent>(WorkQueueUpdateEvent.EventChannelName,
				updateEventRate);
		}

		[ServerInitializeCompleteMethod]
		[UsedImplicitly]
		private void InitializeComplete()
		{
			_vendorDataManager = new VendorDataManager();
		}

		private PayerDataContext NewContext()
		{
			return new PayerDataContext(PayerDataContext.DefaultCommandTimeout);
		}

		public HealthCareClaimStatus GetClaimStatus(ClaimSelectCriteria criteria)
		{
			Contract.RequireNotNull(criteria, "criteria");

			try
			{
				using (var ctx = NewContext())
				{
					HealthCareClaimStatus status = null;
					if (criteria.ClaimId.HasValue)
					{
						status = ClaimStatusQueries.GetClaimStatusByClaimId(ctx, criteria.ClaimId.Value.Number);
					}
		
					if (status == null &&
						criteria.ClaimNumber.NotNullOrEmpty())
					{
						status = ClaimStatusQueries.GetClaimStatusByClaimNumber(ctx, criteria.ClaimNumber);
					}

					if (status == null &&
						criteria.PayerClaimControlNumber.NotNullOrEmpty())
					{
						status = ClaimStatusQueries.GetClaimStatusByPayerControlNumber(ctx, criteria.PayerClaimControlNumber);
					}

					return status;
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public HealthCareClaimStatus[] GetClaimsStatus(ObjectId[] claims)
		{
			if (claims.IsNullOrEmpty())
			{
				return new HealthCareClaimStatus[] {};
			}

			try
			{
				using (var ctx = NewContext())
				{
					var results = new HealthCareClaimStatus[claims.Length];

					for (var idx = 0; idx < claims.Length; idx++)
					{
						results[idx] = ClaimStatusQueries.GetClaimStatusByClaimId(ctx, claims[idx].Number);
					}

					return results;
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public HealthCareClaimStatus[] GetClaimsStatus(int vendorId, string vendorSiteId, DateTime startDate, DateTime? endDate)
		{
			Contract.RequireGreater(vendorId, 0, "vendorId");
			Contract.RequireGreater(startDate, DateTime.MinValue, "startDate");
			Contract.RequireTrue(endDate == null || !endDate.IsNullOrEmpty(), "endDate");

			try
			{
				using (var ctx = NewContext())
				{
					return ClaimStatusQueries.GetClaimStatusByDateRange(ctx, vendorId, vendorSiteId, startDate, endDate);
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

        public  HealthCareClaimStatusRecordId[] GetPagedClaimStatusRecordIds(int currentPage, int pageSize, ClaimSortField claimSortField, ClaimSortOrder claimSortOrder, int startClaimId, DateTime startDate)
        {
            try
            {
                using (var ctx = NewContext())
                {
                    return ClaimStatusQueries.GetPagedClaimStatusRecordIds(ctx, currentPage, pageSize, claimSortField, claimSortOrder, startClaimId, startDate);
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

		public HealthCareClaimStatus[] GetClaimsStatus(int vendorId, string vendorSiteId, long[] docIds)
		{
			Contract.RequireGreater(vendorId, 0, "vendorId");

			try
			{
				using (var ctx = NewContext())
				{
					return ClaimStatusQueries.GetClaimStatusByRelatedDocIds(ctx, vendorId, vendorSiteId, docIds);
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

        public WebClaimStatus[] GetWebClaimHistoryEnhanced(List<string> claimNumbers)
        {
            try
            {
                StringBuilder sb = new StringBuilder(claimNumbers == null ? 0 : claimNumbers.Count * 15);
                foreach (string s in claimNumbers)
                {
                    if (s != null)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(",");
                        }

                        sb.Append(s.ToUpper());
                    }
                }

                ClaimStatusWebQueryManager cswqm = new ClaimStatusWebQueryManager();
                WebClaimStatusData[] results = cswqm.GetWebClaimsStatusEnhanced(sb.ToString());

                WebClaimStatus[] rval = WebClaimHistoryAdapter.ToWebClaimStatus(results);
                return rval;
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

        public PayerResponseId GetPayerResponseId(string claimNumber)
        {
            PayerResponseId rval = null;

            try
            {
                using (PayerDataContext ctx = NewContext())
                {
                    rval = ClaimStatusQueries.GetPayerResponseIdByClaimNumber(ctx, claimNumber);
                    return rval;
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

        /// <summary>
        /// Record the association of an original claim with a new claim, whether by resubmission 
        /// or the submission of a secondary claim.
        /// </summary>
        /// <param name="sourceClaimBaseId">The ID of the original claim with which the new claim is to be associated.</param>
        /// <param name="newClaimBaseId">The ID of the new claim.</param>
        /// <param name="newOrdinal">0 indicates resubmission (use ordinal of original claim if already in the table, otherwise 1). 2 indicates secondary claim.</param>
        /// <param name="profession">Indicates the type of claim (medical or dental).</param>
        public void RelateClaims(long sourceClaimBaseId, long newClaimBaseId, int newOrdinal, Profession profession)
        {
            try
            {
                using (Apex1DataContext ctx = new Apex1DataContext())
                {
                    RelatedClaimQueries.RelateClaims(ctx, sourceClaimBaseId, newClaimBaseId, newOrdinal, profession);
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

        public IEnumerable<RelatedClaim> GetPagedRelatedClaimIds(int currentPage, int pageSize)
        {
            try
            {
                using (Apex1DataContext ctx = new Apex1DataContext())
                {
                    return RelatedClaimQueries.GetPagedRelatedClaimIds(ctx, currentPage, pageSize).ToRelatedClaim();
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

        public IEnumerable<RelatedClaim> GetRelatedMedicalClaimsInGroup(IEnumerable<long> medicalClaimBaseIds)
        {
            try
            {
                using (Apex1DataContext ctx = new Apex1DataContext())
                {
                    return RelatedClaimQueries.GetRelatedMedicalClaimsInGroup(ctx, medicalClaimBaseIds).ToRelatedClaim();
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

        public IEnumerable<RelatedClaim> GetRelatedDentalClaimsInGroup(IEnumerable<long> dentalClaimBaseIds)
        {
            try
            {
                using (Apex1DataContext ctx = new Apex1DataContext())
                {
                    return RelatedClaimQueries.GetRelatedDentalClaimsInGroup(ctx, dentalClaimBaseIds).ToRelatedClaim();
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

        public void DeleteMedicalClaims(IEnumerable<long> medicalClaimBaseIds)
        {
            try
            {
                Apex1Queries.DeleteMedicalClaims(medicalClaimBaseIds);
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

        public void DeleteDentalClaims(IEnumerable<long> dentalClaimBaseIds)
        {
            try
            {
                using (Apex1DataContext ctx = new Apex1DataContext())
                {
                    Apex1Queries.DeleteMedicalClaims(dentalClaimBaseIds);
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

		public void AddClaimsStatus(ClaimStatusUpdateInfo[] updateInfos)
		{
			Contract.RequireNotNull(updateInfos, "updateInfos");

			try
			{
				DateTime now = DateTime.Now;
                Dictionary<ObjectId, int> serviceLinesDict = new Dictionary<ObjectId, int>();

                List<ClaimStatusData> statusData = new List<ClaimStatusData>();
                foreach (ClaimStatusUpdateInfo updateInfo in updateInfos)
                {
                    HealthCareClaimStatus healthCareClaimStatus = updateInfo.UpdatedStatus;

                    if (healthCareClaimStatus.ApexClientId == null)
			        {
                        _log.WarnFormat("Missing metadata - ApexClientId for claim {0}", healthCareClaimStatus.ClaimNumber);
			            continue;
			        }
			        
                    healthCareClaimStatus.CreateDate = now;
                    healthCareClaimStatus.VendorSiteId = _vendorDataManager.GetVendorSiteId(healthCareClaimStatus.VendorId, healthCareClaimStatus.ApexClientId);
                    ClaimStatusData claimStatusData = healthCareClaimStatus.FromClaimStatus();
                    statusData.Add(claimStatusData);
                    serviceLinesDict[healthCareClaimStatus.ClaimId] = updateInfo.ServiceLinesResolved;
                }

				string historyType = HistoryEntryType.ClaimImport.ToString();
                IEnumerable<ClaimHistoryData> historyData = updateInfos.Select(s => new ClaimHistoryData
                {
                    EntryType = historyType,
                    ClaimId = s.UpdatedStatus.ClaimId.Number,
                    ClaimVersion = s.UpdatedStatus.ClaimId.Version,
                    EntryDate = now,
                    EffectiveDate = now,
                    PayerControlNumber = NormalizeWithNull(s.UpdatedStatus.PayerControlNumber),
                    PaymentReferenceNumber = NormalizeWithNull(s.UpdatedStatus.PaymentReferenceNumber),
                    ServiceChargeAmount = s.ServiceChargeAmountResolved,
                    ServiceLines = s.ServiceLinesResolved,
                    DisplayStatus = (int)s.UpdatedStatus.CurrentState,
                    PayerAction = (int)s.UpdatedStatus.PayerAction,
                });

				using (PayerDataContext ctx = NewContext())
				{
					try
					{
						foreach (ClaimStatusData status in statusData.ToArray())
						{
						    try
						    {
                                ctx.Connection.Insert(status);
						    }
						    catch (Exception ex)
						    {
                                //the claim already exists
                                if (HandleError(ex))
                                {
                                    ObjectId claimId = new ObjectId(status.ClaimId, status.ClaimVersion);
                                    ClaimStatusUpdateInfo newUpdateInfo = new ClaimStatusUpdateInfo()
                                    {
                                        UpdatedStatus = status.ToClaimStatus(),
                                        ServiceChargeAmountResolved = Decimal.Zero,
                                        ServiceLinesResolved = serviceLinesDict?[claimId] ?? 0,
                                    };
                                    UpdateClaimStatus(newUpdateInfo);
                                }
						    }
						}
						foreach (var entry in historyData)
						{
						    try
						    {
                                ctx.Connection.Insert(entry);
						    }
						    catch (Exception ex)
						    {
                                HandleError(ex);
						    }
						}
					}
					catch (Exception ex)
					{
						ctx.Connection.RollbackTransaction();
						HandleError(ex);
						throw;
					}
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public bool UpdateClaimStatus(ClaimStatusUpdateInfo updateInfo)
		{
            HealthCareClaimStatus updatedStatus = updateInfo.UpdatedStatus;

            Contract.RequireNotNull(updateInfo, "updateInfo");
            Contract.RequireNotNull(updatedStatus, "updatedStatus");

            try
            {
				using (var ctx = NewContext())
				{
					HealthCareClaimStatus existingStatus = ctx.ClaimStatus.FirstOrDefault(s => s.ClaimId == updatedStatus.ClaimId.Number)
						.ToClaimStatus();

					try
					{
						ctx.Connection.BeginTransaction();

						UpdateClaimStatus(ctx, existingStatus, updateInfo, HistoryEntryType.StatusChange);

						ctx.Connection.CommitTransaction();
					}
					catch (Exception)
					{
						ctx.Connection.RollbackTransaction();
						throw;
					}
				}

				return true;
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		private void AddProperty(JObject diff, string propertyName, object value, JsonSerializer serializer)
		{
			if (value == null)
			{
				diff.Add(propertyName, null);
				return;
			}

			diff.Add(propertyName,JToken.FromObject(value, serializer));
		}

		private void UpdateClaimStatus(PayerDataContext ctx, HealthCareClaimStatus original, ClaimStatusUpdateInfo updateInfo,
			HistoryEntryType entryType, DateTime? entryEffectiveDate = null,
			JsonSerializer serializer = null)
		{
			serializer = serializer ?? JsonSerializer.Create(CommonJsonSettings.Default);
            HealthCareClaimStatus updated = updateInfo.UpdatedStatus;

            DateTime now = DateTime.Now;
            PayerClaimState newState = updated.CurrentState;
            PayerClaimAction newAction = updated.PayerAction;

			var data = original.FromClaimStatus();

			var oldDiff = new JObject();
			var newDiff = new JObject();

			var command = ctx.ClaimStatus
				.Where(s => s.ClaimId == updated.ClaimId.Number)
				.Set(s => s.LastUpdateDate, now);

            if (original.ClaimId.Version != updated.ClaimId.Version)
            {
                command = command
                    .Set(s => s.ClaimVersion, updated.ClaimId.Version);
                AddProperty(oldDiff, "ClaimVersion", original.ClaimId.Version, serializer);
                AddProperty(newDiff, "ClaimVersion", updated.ClaimId.Version, serializer);
            }

            if (original.ClaimNumber != updated.ClaimNumber)
            {
                command = command
                    .Set(s => s.ClaimNumber, updated.ClaimNumber);
                AddProperty(oldDiff, "ClaimNumber", original.ClaimNumber, serializer);
                AddProperty(newDiff, "ClaimNumber", updated.ClaimNumber, serializer);
            }

            if (original.CurrentState != updated.CurrentState)
            {
                data.CurrentState = updated.CurrentState.ToString();
                command = command
                    .Set(s => s.CurrentState, updated.CurrentState.ToString())
                    .Set(s => s.StateChangeDate, now);
                AddProperty(oldDiff, "CurrentState", original.CurrentState, serializer);
                AddProperty(newDiff, "CurrentState", updated.CurrentState, serializer);
            }

            if (original.PayerAction != updated.PayerAction)
            {
                command = command
                    .Set(s => s.PayerAction, updated.PayerAction.ToString())
                    .Set(s => s.PayerActionDate, updated.PayerActionDate);
                AddProperty(oldDiff, "PayerAction", original.PayerAction, serializer);
                AddProperty(newDiff, "PayerAction", updated.PayerAction, serializer);
            }

            if (original.PayerControlNumber != updated.PayerControlNumber)
            {
                command = command.Set(s => s.PayerControlNumber, updated.PayerControlNumber);

                AddProperty(oldDiff, "PayerControlNumber", original.PayerControlNumber, serializer);
                AddProperty(newDiff, "PayerControlNumber", updated.PayerControlNumber, serializer);
            }

            if (original.TotalClaimAmount != updated.TotalClaimAmount)
            {
                command = command
                    .Set(s => s.TotalClaimAmount, updated.TotalClaimAmount);

                AddProperty(oldDiff, "TotalClaimAmount", original.TotalClaimAmount, serializer);
                AddProperty(newDiff, "TotalClaimAmount", updated.TotalClaimAmount, serializer);
            }

            if (original.PayerAmount != updated.PayerAmount)
            {
                command = command
                    .Set(s => s.PayerAmount, updated.PayerAmount);
                AddProperty(oldDiff, "PayerAmount", original.PayerAmount, serializer);
                AddProperty(newDiff, "PayerAmount", updated.PayerAmount, serializer);
            }

            if (original.Adjustments != updated.Adjustments)
            {
                command = command
                    .Set(s => s.Adjustments, updated.Adjustments);
                AddProperty(oldDiff, "Adjustments", original.Adjustments, serializer);
                AddProperty(newDiff, "Adjustments", updated.Adjustments, serializer);
            }

            if (original.PatientAmount != updated.PatientAmount)
            {
                command = command
                    .Set(s => s.PatientAmount, updated.PatientAmount);
                AddProperty(oldDiff, "PatientAmount", original.PatientAmount, serializer);
                AddProperty(newDiff, "PatientAmount", updated.PatientAmount, serializer);
            }

            if (original.PayerName != updated.PayerName)
            {
                command = command
                    .Set(s => s.PayerName, updated.PayerName);
                AddProperty(oldDiff, "PayerName", original.PayerName, serializer);
                AddProperty(newDiff, "PayerName", updated.PayerName, serializer);
            }

            if (original.PaymentMethod != updated.PaymentMethod)
            {
                command = command
                    .Set(s => s.PaymentMethod, updated.PaymentMethod.ToString());
                AddProperty(oldDiff, "PaymentMethod", original.PaymentMethod, serializer);
                AddProperty(newDiff, "PaymentMethod", updated.PaymentMethod, serializer);
            }

            if (original.PaymentReferenceNumber != updated.PaymentReferenceNumber)
            {
                command = command
                    .Set(s => s.PaymentReferenceNumber, updated.PaymentReferenceNumber);
                AddProperty(oldDiff, "PaymentReferenceNumber", original.PaymentReferenceNumber, serializer);
                AddProperty(newDiff, "PaymentReferenceNumber", updated.PaymentReferenceNumber, serializer);
            }

            if (original.PaymentEffectiveDate != updated.PaymentEffectiveDate)
            {
                var effDate = updated.PaymentEffectiveDate.AsDateTime();

                command = command.
                    Set(s => s.PaymentEffectiveDate, effDate);

                AddProperty(oldDiff, "PaymentEffectiveDate", original.PaymentEffectiveDate, serializer);
                AddProperty(newDiff, "PaymentEffectiveDate", updated.PaymentEffectiveDate, serializer);
            }

            //NOTE: the related document fields have explicit columns
            //in the history table so they are not added to the diff.
            if (original.RelatedDocumentType != updated.RelatedDocumentType)
            {
                var newValue = updated.RelatedDocumentType != null
                    ? updated.RelatedDocumentType.Value.ToString()
                    : null;

                command = command
                    .Set(s => s.RelatedDocumentType, newValue);
            }

            if (original.RelatedDocumentId != updated.RelatedDocumentId)
            {
                var newId = updated.RelatedDocumentId != null
                    ? (long?)updated.RelatedDocumentId.Value.Number
                    : null;
                var newVersion = updated.RelatedDocumentId != null
                    ? (int?)updated.RelatedDocumentId.Value.Version
                    : null;

                command = command
                    .Set(s => s.RelatedDocumentId, newId)
                    .Set(s => s.RelatedDocumentVersion, newVersion);
            }

            bool updateDatabase = false;
            // Duplicate in as submitted - allow it
            if (updated.RelatedDocumentType == null && updated.CurrentState == PayerClaimState.Submitted)
                updateDatabase = true;
            else if (original.RelatedDocumentType == null) // DocumentType.Claim
                updateDatabase = true;
            else if (original.RelatedDocumentType == DocumentType.InterchangeStatus &&
                ((updated.RelatedDocumentType == DocumentType.ClaimStatus) ||
                  (updated.RelatedDocumentType == DocumentType.RemittanceAdvice))
                )
                updateDatabase = true;
            else if (original.RelatedDocumentType == DocumentType.ClaimStatus &&
                ((updated.RelatedDocumentType == DocumentType.ClaimStatus) ||
                updated.RelatedDocumentType == DocumentType.RemittanceAdvice))
                updateDatabase = true;
            else if (original.RelatedDocumentType == DocumentType.RemittanceAdvice)
                updateDatabase = false;

            if (updateDatabase)
            {
                command.Update();
            }

            var historyEntry = new ClaimHistoryData
            {
                ClaimId = updated.ClaimId.Number,
                ClaimVersion = updated.ClaimId.Version,
                EntryType = entryType.ToString(),
                EntryDate = now,
                EffectiveDate = entryEffectiveDate ?? now,
                OriginalValue = oldDiff.ToString(Formatting.None, CommonJsonSettings.DefaultConverters),
                NewValue = newDiff.ToString(Formatting.None, CommonJsonSettings.DefaultConverters),
                PayerControlNumber = NormalizeWithNull(updated.PayerControlNumber),
                PaymentReferenceNumber = NormalizeWithNull(updated.PaymentReferenceNumber),
                ServiceChargeAmount = updateInfo.ServiceChargeAmountResolved,
                ServiceLines = updateInfo.ServiceLinesResolved,
                DisplayStatus = (int)newState,
                PayerAction = (int)newAction,
            };

            if (updated.RelatedDocumentType != null &&
                updated.RelatedDocumentId != null)
            {
                historyEntry.RelatedDocumentType = updated.RelatedDocumentType.Value.ToString();
                historyEntry.RelatedDocumentId = updated.RelatedDocumentId.Value.Number;
                historyEntry.RelatedDocumentVersion = updated.RelatedDocumentId.Value.Version;
            }

            ctx.Connection.Insert(historyEntry);
        }

	    public void UpdateClaimsStatus(ClaimStatusUpdateInfo[] updateInfos)
	    {
	        Contract.RequireNotNull(updateInfos, "updateInfos");

	        try
	        {
	            var serializer = JsonSerializer.Create(CommonJsonSettings.DefaultWithNulls);
	            using (var ctx = NewContext())
	            {
	                try
	                {
	                    ctx.Connection.BeginTransaction();

	                    foreach (ClaimStatusUpdateInfo updateInfo in updateInfos)
	                    {
	                        HealthCareClaimStatus claimStatus = updateInfo.UpdatedStatus;
	                        HealthCareClaimStatus existingStatus = ctx.ClaimStatus.FirstOrDefault(s => s.ClaimId == claimStatus.ClaimId.Number)
	                            .ToClaimStatus();
	                        if (existingStatus == null)
	                        {
	                            continue;
	                        }

	                        UpdateClaimStatus(ctx, existingStatus, updateInfo, HistoryEntryType.StatusChange,
	                            null, serializer);
	                    }
	                    ctx.Connection.CommitTransaction();
	                }
	                catch (Exception)
	                {
	                    ctx.Connection.RollbackTransaction();
	                    throw;
	                }
	            }
	        }
	        catch (Exception ex)
	        {
	            HandleError(ex);
	            throw;
	        }
	    }

        public long AddRemittanceReportStatus(RemittanceReportStatus reportStatus)
		{
			Contract.RequireNotNull(reportStatus, "reportStatus");

			try
			{
				using (var ctx = NewContext())
				{
					var createDate = DateTime.Now;
					reportStatus.CreateDate = createDate;

					var statusId = InsertRemittanceReportStatus(reportStatus, ctx, createDate, true);
					if (statusId == null)
					{
						var docId = reportStatus.RelatedDocumentId.Number;
						ctx.RemittanceReportStatus.Delete(r => r.RelatedDocumentId == docId);

						statusId = InsertRemittanceReportStatus(reportStatus, ctx, createDate, false);
					}
					return statusId.Value;
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		private long? InsertRemittanceReportStatus(RemittanceReportStatus reportStatus, PayerDataContext ctx,
			DateTime createDate, bool checkForDuplicates)
		{
			long statusId;
			ctx.Connection.BeginTransaction();
			try
			{
				var rowId = ctx.Connection.InsertWithIdentity(reportStatus.FromRemittanceReportStatus());
				statusId = Convert.ToInt64(rowId);
				foreach (var prov in reportStatus.ProviderPayments)
				{
					prov.CreateDate = createDate;
					prov.RemittanceReportStatusId = statusId;
					ctx.Connection.Insert(prov.FromProviderPaymentStatus());
				}
				ctx.Connection.CommitTransaction();
				return statusId;
			}
			catch (Exception ex)
			{
				ctx.Connection.RollbackTransaction();

				//temp hack until we figure out what the exact exception thrown is.
				if (checkForDuplicates && 
					ex.Message.Contains("Cannot insert duplicate key"))
				{
					return null;
				}
				throw;
			}
		}

		public void AddProviderPaymentStatus(ProviderPaymentStatus providerStatus)
		{
			Contract.RequireNotNull(providerStatus, "providerStatus");

			try
			{
				using (var ctx = NewContext())
				{
					providerStatus.CreateDate = DateTime.Now;
					ctx.Connection.Insert(providerStatus.FromProviderPaymentStatus());
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

        public void InsertOtherClaimHistory(OtherClaimHistory historyItem)
        {
            Contract.RequireNotNull(historyItem, "historyItem");

            try
            {
                using (var ctx = NewContext())
                {
                    ctx.Connection.Insert(historyItem.FromOtherClaimHistory());
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

        public void AddProviderPaymentStatus(ProviderPaymentStatus[] providerStatus)
		{
			Contract.RequireNotNull(providerStatus, "providerStatus");

			if (providerStatus.Length == 0)
			{
				return;
			}

			try
			{
				using (var ctx = NewContext())
				{
					var createDate = DateTime.Now;
					ctx.Connection.BeginTransaction();
					try
					{
						foreach (var prov in providerStatus)
						{
							prov.CreateDate = createDate;
							ctx.Connection.Insert(prov.FromProviderPaymentStatus());
						}
						ctx.Connection.CommitTransaction();
					}
					catch
					{
						ctx.Connection.RollbackTransaction();
						throw;
					}
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public void AddWorkItem(WorkItem newItem)
		{
			Contract.RequireNotNull(newItem, "newItem");

			try
			{
				int itemCount;
				using (var ctx = NewContext())
				{
					newItem.CreateDate = DateTime.Now;
					ctx.Connection.Insert(newItem.FromWorkItem());

					itemCount = ctx.WorkItems.Count();
				}
				RemotingManager.PublishEvent(WorkQueueUpdateEvent.EventChannelName,
					new WorkQueueUpdateEvent(itemCount, newItem.CreateDate));
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public void AddWorkItems(WorkItem[] newItems)
		{
			Contract.RequireNotNull(newItems, "newItems");

			try
			{
				var now = DateTime.Now;
				int itemCount;
				using (var ctx = NewContext())
				{
					ctx.Connection.BeginTransaction();
					foreach (var item in newItems.Pipe(i => i.CreateDate = now)
						.Select(i => i.FromWorkItem()))
					{
						ctx.Connection.Insert(item);
					}
					ctx.Connection.CommitTransaction();

					itemCount = ctx.WorkItems.Count();
				}
				RemotingManager.PublishEvent(WorkQueueUpdateEvent.EventChannelName,
					new WorkQueueUpdateEvent(itemCount, now));
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public void UpdateWorkItem(WorkItem newItem)
		{
			try
			{
				using (var ctx = NewContext())
				{
					ctx.Connection.Update(newItem.FromWorkItem());
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public WorkItem[] GetWorkItems()
		{
			try
			{
				using (var ctx = NewContext())
				{
					var items = ctx.WorkItems.ToWorkItems().ToArray();
					return items;
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public void DeleteWorkItems(long[] itemIds)
		{
			Contract.RequireNotNull(itemIds, "itemIds");

			if (itemIds.Length == 0)
			{
				return;
			}

			try
			{
				using (var ctx = NewContext())
				{
					ctx.Connection.BeginTransaction();
					ctx.WorkItems.Delete(
						item => itemIds.Contains(item.WorkItemId));
					ctx.Connection.CommitTransaction();
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public void DeleteWorkItems(DocumentType type, ObjectId id)
		{
			Contract.RequireTrue(type != DocumentType.Unknown, "type");
			Contract.RequireTrue(id.IsValid, "id");

			try
			{
				using (var ctx = NewContext())
				{
					ctx.Connection.BeginTransaction();
					var typeArg = type.ToString();
					var numArg = id.Number;
					var verArg = id.Version;
					ctx.WorkItems.Delete(
						item => item.DocumentType == typeArg &&
						item.DocumentId == numArg &&
						item.DocumentVersion == verArg);
					ctx.Connection.CommitTransaction();
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public PayerClaimMetadata[] GetPayerClaimMetadata(string[] clearninghouseControlNumbers)
		{
			Contract.RequireNotNull(clearninghouseControlNumbers, "clearninghouseControlNumbers");

			if (clearninghouseControlNumbers.Length == 0)
			{
				return Enumerable.Empty<PayerClaimMetadata>().ToArray();
			}

			try
			{
				var results = Apex1Queries.GetClaimMetadata(clearninghouseControlNumbers, _vendorDataManager).ToArray();
				return results;
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public string GetVendorSiteId(int vendorId, string apexClientId)
		{
			Contract.RequireGreater(vendorId, 0, "vendorId");
			Contract.RequireNotNullOrEmpty(apexClientId, "apexClientId");
			
			try
			{
				var siteId = _vendorDataManager.GetVendorSiteId(vendorId, apexClientId);
				return siteId;
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public void SetClientSuppressSortIssues(string clientId, bool value)
		{
			Contract.RequireNotNullOrEmpty(clientId, "clientId");

			try
			{
				using (var ctx = new Apex1DataContext())
				{
					var client = ctx.ClientConfiguration.FirstOrDefault(c => c.ClientId == clientId);
					if (client == null)
					{
						client = new ClientConfigurationData
						{
							ClientId = clientId,
							CreateDate = DateTime.Now,
							SuppressSortIssues = value
						};
						ctx.Connection.Insert(client);
						return;
					}

					ctx.ClientConfiguration
						.Where(c => c.ClientId == clientId)
						.Set(c => c.SuppressSortIssues, value)
						.Update();
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public ApexClient[] GetProviders()
		{
			try
			{
				using (var ctx = new Apex1DataContext())
				{
					var providers = (from p in ctx.Providers
						join c in ctx.ClientConfiguration on p.ClientID equals c.ClientId into pc
						from ppc in pc.DefaultIfEmpty()
						orderby p.ProviderId
						select new
						{
							Provider = p,
							SuppressSortIssues = ppc.SuppressSortIssues
						}).ToArray();
					var clients = providers.Select(p =>
					{
						var c = p.Provider.ToProvider();
						c.SuppressSortIssues = p.SuppressSortIssues ?? false;
						return c;
					}).ToArray();

					return clients;
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public ApexClient GetProvider(int providerId)
		{
			try
			{
				using (var ctx = new Apex1DataContext())
				{
					var result = (from p in ctx.Providers
						join c in ctx.ClientConfiguration on p.ClientID equals c.ClientId into pc
						from ppc in pc.DefaultIfEmpty()
						where p.ProviderId == providerId
						orderby p.ProviderId
						select new
						{
							Provider = p,
							SuppressSortIssues = ppc.SuppressSortIssues
						}).FirstOrDefault();

					if (result != null)
					{
						var client = result.Provider.ToProvider();
						client.SuppressSortIssues = result.SuppressSortIssues ?? false;
						return client;
					}

					return null;
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}



        public ApexClient GetProvider(string npi, string stateLicense, string taxId)
        {
            try
            {
                using (var ctx = new Apex1DataContext())
                {
                    var result = (from p in ctx.Providers
                                  join c in ctx.ClientConfiguration on p.ClientID equals c.ClientId into pc
                                  from ppc in pc.DefaultIfEmpty()
                                  where (p.Quit == null || p.Quit > DateTime.Now) &&  (p.RenderingProvNPI == npi || p.NPI == npi || p.License == stateLicense || p.TaxID == taxId)
                                  orderby p.ProviderId
                                  select new
                                  {
                                      Provider = p,
                                      SuppressSortIssues = ppc.SuppressSortIssues
                                  }).ToList();

                    if (result != null && result.Count != 0)
                    {
                        ApexClient client;
			            if (result.Count == 1)
			            {
			                 client = result.FirstOrDefault().Provider.ToProvider();
                                    client.SuppressSortIssues = result.FirstOrDefault().SuppressSortIssues ?? false;
                                    return client;
			            }
                        if (result.Count > 1)
                        {
                            //Filter on Rendering Provider NPI
                            var filteredProviders = result.Where(x => x.Provider.RenderingProvNPI == npi).ToList();
                            if (filteredProviders.Count == 1)
                            {
                                client = filteredProviders.FirstOrDefault().Provider.ToProvider();
                                client.SuppressSortIssues = filteredProviders.FirstOrDefault().SuppressSortIssues ?? false;
                                return client;
                            }
                            filteredProviders = result.Where(x => x.Provider.NPI == npi).ToList();
                            if (filteredProviders.Count == 1)
                            {
                                client = filteredProviders.FirstOrDefault().Provider.ToProvider();
                                client.SuppressSortIssues = filteredProviders.FirstOrDefault().SuppressSortIssues ?? false;
                                return client;
                            }
                            filteredProviders = result.Where(x => x.Provider.TaxID == taxId).ToList();
                            if (filteredProviders.Count == 1)
                            {
                                client = filteredProviders.FirstOrDefault().Provider.ToProvider();
                                client.SuppressSortIssues = filteredProviders.FirstOrDefault().SuppressSortIssues ?? false;
                                return client;
                            }
                            filteredProviders = result.Where(x => x.Provider.License == stateLicense).ToList();
                            if (filteredProviders.Count == 1)
                            {
                                client = filteredProviders.FirstOrDefault().Provider.ToProvider();
                                client.SuppressSortIssues = filteredProviders.FirstOrDefault().SuppressSortIssues ?? false;
                                return client;
                            }
                        }
 }

                    return null;
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

        //private static ApexClient ApexClient(List<Provider> filteredProviders)
        //{
        //    ApexClient client = null;
        //    if (filteredProviders.Count == 1)
        //    {
        //        client = ProviderAdapter.ToProvider((ProviderData)filteredProviders.FirstOrDefault().Provider);
        //        client.SuppressSortIssues = filteredProviders.FirstOrDefault().SuppressSortIssues ?? false;
        //    }
        //    return client;
        //}


		public PayerConfiguration GetPayerConfiguration(string apexPayerId)
		{
			Contract.RequireNotNull(apexPayerId, "apexPayerId");

			try
			{
				using (var ctx = NewContext())
				{
					var item = ctx.PayerConfiguration.Where(x => x.ApexPayerId == apexPayerId).ToPayerConfiguration().FirstOrDefault();
					return item;
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

        public PayerConfiguration GetPayerConfigurationByOutputSubId(int outputSubId)
        {
            Contract.RequireNotEqual(outputSubId, 0, "outputSubId");

            try
            {
                using (var ctx = NewContext())
                {
                    var item = ctx.PayerConfiguration.Where(x => x.OutputSubId == outputSubId).ToPayerConfiguration().FirstOrDefault();
                    return item;
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

	    public PayerConfiguration GetPayerConfigurationByClaimPayerId(string payerId)
	    {
	        Contract.RequireNotNull(payerId, "payerId");

	        try
	        {
	            using (var ctx = NewContext())
	            {
	                var item = ctx.PayerConfiguration.Where(x => x.ClaimPayerId == payerId).ToPayerConfiguration().FirstOrDefault();
	                return item;
	            }
	        }
	        catch (Exception ex)
	        {
	            HandleError(ex);
	            throw;
	        }
	    }

		public int GetMaxDependents(string apexPayerId)
		{
			Contract.RequireNotNull(apexPayerId, "apexPayerId");

			try
			{
				using (var ctx = NewContext())
				{
					var payerConfigurationData = ctx.PayerConfiguration.FirstOrDefault(x => x.ApexPayerId == apexPayerId);
					if (payerConfigurationData != null)
					{
						var maxDependents = payerConfigurationData.MaximumEligibilityDependents;
						if (maxDependents != null)
						{
							return maxDependents.Value;
						}
					}
					return 0;
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

        public List<PayerConfiguration> GetPayersByLineOfBusiness(int lineOfBusiness)
        {
            List<PayerConfiguration> payerList = new List<PayerConfiguration>();

            using (var ctx = NewContext())
            {
                payerList = (from pc in ctx.PayerConfiguration
                             join tpc in ctx.TradingPartnerConfiguration
                                 on pc.ClmTradingPartnerId equals tpc.TradingPartnerId
                             where tpc.LineOfBusiness == (int?) lineOfBusiness && !tpc.IsTest
                             select pc).ToPayerConfiguration().ToList();
            }

            return payerList;
        }

        public List<PayerConfiguration> GetTestPayersByLineOfBusiness(int lineOfBusiness)
        {
            List<PayerConfiguration> payerList = new List<PayerConfiguration>();

            using (var ctx = NewContext())
            {
                payerList = (from pc in ctx.PayerConfiguration
                             from ctpc in ctx.TradingPartnerConfiguration
                                .Where(t => t.TradingPartnerId == pc.ClmTradingPartnerId && t.LineOfBusiness == (int?)lineOfBusiness && t.IsTest)
                             from etpc in ctx.TradingPartnerConfiguration
                                .Where(e => (e == null) || ((e.TradingPartnerId == pc.ElgTradingPartnerId) && (e.EligibilityImpl == 999)))
                                .DefaultIfEmpty()
                            select pc).ToPayerConfiguration().ToList();
            }

            return payerList;
        }

		public List<PayerConfiguration> GetAllPayers()
		{
			List<PayerConfiguration> payerList = new List<PayerConfiguration>();

			using (var ctx = NewContext())
			{
				payerList = (ctx.PayerConfiguration.Select(x => x).ToList().ToPayerConfiguration().ToList());
			}

			return payerList;
		}

		public void AddPayerConfiguration(PayerConfiguration payerConfiguration)
		{
			Contract.RequireNotNull(payerConfiguration, "payerConfiguration");
			try
			{
				using (var ctx = NewContext())
				{
					payerConfiguration.CreateDate = DateTime.Now;
					payerConfiguration.LastUpdateDate = DateTime.Now;
					ctx.Connection.Insert(payerConfiguration.FromPayerConfiguration());
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public void DeletePayerConfiguration(string apexPayerId)
		{
			Contract.RequireNotNull(apexPayerId, "apexPayerId");
			try
			{
				using (var ctx = NewContext())
				{
					ctx.PayerConfiguration.Delete(x => x.ApexPayerId == apexPayerId);
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public void UpdatePayerConfiguration( PayerConfiguration payerConfiguration)
		{
			Contract.RequireNotNull(payerConfiguration, "payerConfiguration");
			try
			{
				using (var ctx = NewContext())
				{
					payerConfiguration.LastUpdateDate = DateTime.Now;
					ctx.Connection.Update(payerConfiguration.FromPayerConfiguration());
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public int AddTradingPartnerConfiguration(TradingPartnerConfiguration tradingPartnerConfiguration)
		{
			Contract.RequireNotNull(tradingPartnerConfiguration, "tradingPartnerConfiguration");
			int TPId = 0;
			try
			{
				using (var ctx = NewContext())
				{
					tradingPartnerConfiguration.CreateDate = DateTime.Now;
					tradingPartnerConfiguration.LastUpdateDate = DateTime.Now;
					ctx.Connection.Execute("SET IDENTITY_INSERT " + "TradingPartnerConfiguration" + " ON");
					TPId = Convert.ToInt32(ctx.Connection.InsertWithIdentity(tradingPartnerConfiguration.FromTradingPartnerConfiguration()));
					ctx.Connection.Execute("SET IDENTITY_INSERT " + "TradingPartnerConfiguration" + " OFF");
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
			return TPId;
		}

		public TradingPartnerConfiguration GetTradingPartnerConfiguration(long tradingPartnerId)
		{
			Contract.RequireNotNull(tradingPartnerId, "tradingPartnerId");

			try
			{
				using (var ctx = NewContext())
				{
					var item = ctx.TradingPartnerConfiguration.Where(x => x.TradingPartnerId == tradingPartnerId).ToTradingPartnerConfiguration().FirstOrDefault();
					return item;
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public List<TradingPartnerConfiguration> GetAllTradingPartners()
		{
			List<TradingPartnerConfiguration> tradingPartnerConfigurations = new List<TradingPartnerConfiguration>();

			using (var ctx = NewContext())
			{
				tradingPartnerConfigurations = (ctx.TradingPartnerConfiguration.Select(x => x).ToList().ToTradingPartnerConfiguration().ToList());
			}

			return tradingPartnerConfigurations;
		}

		public void UpdateTradingPartnerConfiguration(TradingPartnerConfiguration tradingPartnerConfiguration)
		{
			Contract.RequireNotNull(tradingPartnerConfiguration, "tradingPartnerConfiguration");
			try
			{
				using (var ctx = NewContext())
				{
					tradingPartnerConfiguration.LastUpdateDate = DateTime.Now;
					ctx.Connection.Update(tradingPartnerConfiguration.FromTradingPartnerConfiguration());
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public void DeleteTradingPartneConfiguration(long tradingPartnerId)
		{
			Contract.RequireNotNull(tradingPartnerId, "tradingPartnerId");
			try
			{
				using (var ctx = NewContext())
				{
					ctx.TradingPartnerConfiguration.Delete(x => x.TradingPartnerId == tradingPartnerId);
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public void AddPayerAddress(PayerAddress payerAddress)
		{
			Contract.RequireNotNull(payerAddress, "payerAddress");

			try
			{
				using (var ctx = NewContext())
				{
					payerAddress.CreateDate = DateTime.Now;
					ctx.Connection.Insert(payerAddress.FromPayerAddress());
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public PayerAddress GetPayerAddress(string apexPayerId)
		{
			Contract.RequireNotNull(apexPayerId, "apexPayerId");

			try
			{
				using (var ctx = NewContext())
				{
					var item = ctx.PayerAddress.Where(x => x.ApexPayerId == apexPayerId).ToPayerAddress().FirstOrDefault();
					return item;
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public void AddVendorPayerMapData(VendorPayerMap vendorPayerMap)
		{
			Contract.RequireNotNull(vendorPayerMap, "vendorPayerMap");

			try
			{
				using (var ctx = NewContext())
				{
					vendorPayerMap.CreateDate = DateTime.Now;
					ctx.Connection.Insert(vendorPayerMap.FromVendorPayerMap());
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public VendorPayerMap GetVendorPayerMapData(int vendorId, string vendorSiteId)
		{
			Contract.RequireNotNull(vendorSiteId, "vendorSiteId");
			Contract.RequireNotEqual(vendorId, 0, "vendorId");

			try
			{
				using (var ctx = NewContext())
				{
					var item = ctx.VendorPayerMap.Where(x => x.VendorId == vendorId && x.VendorSiteId == vendorSiteId).ToVendorPayerMap().FirstOrDefault();
					return item;
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public long AddEligibilityRequest(EligibilityRequest eligibilityRequest)
		{
			Contract.RequireNotNull(eligibilityRequest, "eligibilityRequest");

			try
			{
				using (var ctx = NewContext())
				{
					eligibilityRequest.CreateDate = DateTime.Now;
					return Convert.ToInt32(ctx.Connection.InsertWithIdentity(eligibilityRequest.FromEligibilityRequest()));
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public EligibilityRequest GetEligibilityRequest(long requestId)
		{
            Contract.RequireNotNull(requestId, "requestId");
			try
			{
				using (var ctx = NewContext())
				{
					var item = ctx.EligibilityRequest.Where(x => x.RequestId == requestId).ToEligibilityRequest().FirstOrDefault();
					return item;
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public void AddPayerBenefitData(DsPayerBenefitData dsPayerBenefitData)
		{
			Contract.RequireNotNull(dsPayerBenefitData, "dsPayerBenefitData");

			try
			{
				using (var ctx = NewContext())
				{
					dsPayerBenefitData.CreateDate = DateTime.Now;
					ctx.Connection.Insert(dsPayerBenefitData.FromDsPayerBenefitData());
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

		public void AddPayerBenefitDataHeader(DsPayerBenefitHeader dsPayerBenefitHeader)
		{
			Contract.RequireNotNull(dsPayerBenefitHeader, "dsPayerBenefitHeaderData");

			try
			{
				using (var ctx = NewContext())
				{
					dsPayerBenefitHeader.CreateDate = DateTime.Now;
					ctx.Connection.Insert(dsPayerBenefitHeader.FromDsPayerBenefitHeader());
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				throw;
			}
		}

        public List<EligibilitySubscriber> GetEligibilitySubscribers(string clientId)
        {
            Contract.RequireNotNull(clientId, "clientId");

            try
            {
                using (var ctxa = NewContext())
                {
                    using (var ctx = new Apex1DataContext())
                    {
                        var result = (from es in ctxa.EligibilitySubscriber
                                      join pc in ctxa.PayerConfiguration on es.ApexPayerId equals pc.ApexPayerId into pay
                                      where es.ClientId == clientId
                                      orderby es.PatientSearchLastName ascending, es.PatientSearchFirstName ascending

						select new
						{
							subscriber = es,
                            payerName = pay.FirstOrDefault().PayerName
						}).ToArray();

                        if (result != null)
                        {
                            List<EligibilitySubscriber> subscribers = new List<EligibilitySubscriber>();
                            foreach (var sub in result)
                            {
                                EligibilitySubscriber eligibilitySubscriber = new EligibilitySubscriber();
                                eligibilitySubscriber = sub.subscriber.ToEligibilitySubscriber();
                                eligibilitySubscriber.PayerName = sub.payerName;
                                subscribers.Add(eligibilitySubscriber);
                            }
                            return subscribers;
                        }
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

 
        public EligibilitySubscriber GetEligibilitySubscriber(string clientId, long elgSubscriberId)
        {
            Contract.RequireNotNull(clientId, "clientId");

            try
            {
                using (var ctx = NewContext())
                {
                    return ctx.EligibilitySubscriber.Where(x => x.ClientId == clientId && x.EligibilitySubscriberId == elgSubscriberId).ToEligibilitySubscriber().FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }


        public long AddEligibilitySubscriber(EligibilitySubscriber eligibilitySubscriber)
        {
            Contract.RequireNotNull(eligibilitySubscriber, "eligibilitySubscriber");

            try
            {
                using (var ctx = NewContext())
                {
                    var rowId = ctx.Connection.InsertWithIdentity(eligibilitySubscriber.FromEligibilitySubscriber());
                    long eligibilitySubscriberId = Convert.ToInt64(rowId);
                    return eligibilitySubscriberId;
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }          
        }

        public void UpdateEligibilitySubscriber(EligibilitySubscriber eligibilitySubscriber)
        {
            Contract.RequireNotNull(eligibilitySubscriber, "eligibilitySubscriber");

            try
            {
                using (var ctx = NewContext())
                {
                    ctx.Connection.Update(eligibilitySubscriber.FromEligibilitySubscriber());
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }          
        }

        public void DeleteEligibilitySubscriber(long eligibilitySubscriberId)
        {
            Contract.RequireGreater(eligibilitySubscriberId, 0, "eligibilitySubscriberId");

            try
            {
                using (var ctx = NewContext())
                {
                    ctx.EligibilitySubscriber.Delete(x => x.EligibilitySubscriberId == eligibilitySubscriberId);
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

        public ClaimUpdateQueueItem[] GetTopNClaimUpdateQueueItems(int n)
        {
            ClaimUpdateQueueItem[] items = null;
            bool success = false;

            for (int i = 0; !success && (i < DeadlockRetryAttempts); i++)
            {
                if (i != 0)
                {
                    Thread.Sleep(DeadlockRetryIntervalMs);
                }

                try
                {
                    // Be sure to use a new context for each attempt.
                    // See http://stackoverflow.com/questions/2256939/how-to-catch-sqlexception-caused-by-deadlock
                    using (PayerDataContext ctx = NewContext())
                    {
                        items = ClaimStatusQueries.GetTopNClaimUpdateQueueItems(ctx, n);
                        success = true;
                    }
                }
                catch (SqlException ex)
                {
                    if (!IsRetryableException(ex))
                    {
                        HandleError(ex);
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                    throw;
                }
            }

            if (!success)
            {
                _log.Error("GetTopNClaimUpdateQueueItems() failed.");
            }

            return items;
        }

        public bool DeleteClaimUpdateQueueItems(IEnumerable<long> itemIds)
        {
            bool success = true;
            Contract.RequireNotNull(itemIds, "itemIds");

            if (itemIds.Any())
            {
                success = false;

                for (int i = 0; !success && (i < DeadlockRetryAttempts); i++)
                {
                    if (i != 0)
                    {
                        Thread.Sleep(DeadlockRetryIntervalMs);
                    }

                    try
                    {
                        // Be sure to use a new context for each attempt.
                        // See http://stackoverflow.com/questions/2256939/how-to-catch-sqlexception-caused-by-deadlock
                        using (PayerDataContext ctx = NewContext())
                        {
                            ctx.Connection.BeginTransaction();
                            ctx.ClaimUpdateQueueItem.Delete(
                                item => itemIds.Contains(item.ClaimUpdateQueueItemId));
                            ctx.Connection.CommitTransaction();
                        }

                        success = true;
                    }
                    catch (SqlException ex)
                    {
                        if (!IsRetryableException(ex))
                        {
                            HandleError(ex);
                            throw;
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleError(ex);
                        throw;
                    }
                }
            }

            if (!success)
            {
                _log.Error("DeleteClaimUpdateQueueItems() failed.");
            }

            return success;
        }

        private static bool IsRetryableException(SqlException ex)
        {
            // 1204 = SqlOutOfLocks, 1205 = SqlDeadlockVictim, 1222 = SqlLockRequestTimeout
            return (ex.Number == 1204) || (ex.Number == 1205) || (ex.Number == 1222);
        }

        public void SetClaimIsIgnored(string claimNumber, bool newState)
        {
 			Contract.RequireNotNull(claimNumber, "claimNumber");

            string normalizedClaimNumber = claimNumber.ToUpper().Trim();

            try
            {
                long claimId = 0L;
                bool success = false;

                if ((normalizedClaimNumber.Length > 1) && Int64.TryParse(normalizedClaimNumber.Substring(1), out claimId))
                {
                    if (normalizedClaimNumber.StartsWith("M"))
                    {
                        Apex1Queries.SetIsIgnoredMedical(claimId, newState);
                        success = true;
                    }
                    else if (normalizedClaimNumber.StartsWith("D"))
                    {
                        Apex1Queries.SetIsIgnoredDental(claimId, newState);
                        success = true;
                    }
                }

                if (!success)
                {
                    _log.WarnFormat("SetIsIgnoredClaim(). invalid claimNumber {0}", claimNumber);
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

        public List<FileTransferParms> GetAllFileTransferParmsForTradingPartner(long tradingPartnerId)
        {
            List<FileTransferParms> fileTransferParmsList = new List<FileTransferParms>();

            using (var ctx = NewContext())
            {
                fileTransferParmsList = (ctx.FileTransferParms.Where(x => x.TradingPartnerId == tradingPartnerId).ToList().ToFileTransferParms().ToList());
            }

            return fileTransferParmsList;
        }

        public void AddFileTransferParmsList(List<FileTransferParms> listOfFileTransferParms)
        {
            Contract.RequireNotNull(listOfFileTransferParms, "listOfFileTransferParms");

            try
            {
                using (var ctx = NewContext())
                {
                    DateTime now = DateTime.Now;

                    foreach (FileTransferParms fileTransferParms in listOfFileTransferParms)
                    {
                        fileTransferParms.CreateDate = now;
                        fileTransferParms.LastUpdateDate = now;
                        ctx.Connection.Insert(fileTransferParms.FromFileTransferParms());
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

        public void UpdateFileTransferParmsList(List<FileTransferParms> listOfFileTransferParms)
        {
            Contract.RequireNotNull(listOfFileTransferParms, "listOfFileTransferParms");

            try
            {
                using (var ctx = NewContext())
                {
                    DateTime now = DateTime.Now;

                    foreach (FileTransferParms fileTransferParms in listOfFileTransferParms)
                    {
                        fileTransferParms.LastUpdateDate = now;
                        ctx.Connection.Update(fileTransferParms.FromFileTransferParms());
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

        public void DeleteFileTransferParmsList(List<FileTransferParms> listOfFileTransferParms)
        {
            Contract.RequireNotNull(listOfFileTransferParms, "listOfFileTransferParms");

            try
            {
                HashSet<long> hs = new HashSet<long>();

                foreach (FileTransferParms fileTransferParms in listOfFileTransferParms)
                {
                    hs.Add(fileTransferParms.FileTransferParmsId);
                }

                using (var ctx = NewContext())
                {
                    ctx.FileTransferParms.Delete(ftp => hs.Contains(ftp.FileTransferParmsId));
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
                throw;
            }
        }

        public List<ObjectId> GetRemittanceObjectIdsByDateRange(DateTime startDate, DateTime endDate)
        {
            using (PayerDataContext ctx = NewContext())
            {
                List<ObjectId> results = ctx.DsRemittanceAdviceHeader
                    .Where(rah => (startDate <= rah.CreateDate) && (rah.CreateDate < endDate))
                    .Select(result => new ObjectId(result.RecordId, result.CurrentVersion))
                    .ToList();

                return results;
            }
        }

        public List<RaClaimResult> GetRaClaimResults(ObjectId raId, string payerControlNumber)
        {
            using (PayerDataContext ctx = NewContext())
            {
                List<RaClaimResult> results = (from cs in ctx.ClaimStatus
                               join ch in ctx.ClaimHistory on cs.ClaimId equals ch.ClaimId
                               where ch.RelatedDocumentType == "RemittanceAdvice"
                               && ch.RelatedDocumentId == raId.Number
                               && ch.ClaimVersion == raId.Version && ch.PayerControlNumber == payerControlNumber
                               select new RaClaimResult()
                               {
                                   ClaimId = cs.ClaimId,
                                   ClaimNumber = cs.ClaimNumber,
                               }).ToList();

                return results;
            }
        }

        private DataParameter[] GetDateSelectionParameters(DateTime selectDate)
        {
            DateTime startDate = selectDate.Date;
            DateTime endDate = startDate.AddDays(1.0);

            DataParameter[] dps = new DataParameter[]
            {
                    new DataParameter()
                    {
                        DataType = DataType.Date,
                        Direction = System.Data.ParameterDirection.Input,
                        Name = "StartDate",
                        Value = startDate,
                    },
                    new DataParameter()
                    {
                        DataType = DataType.Date,
                        Direction = System.Data.ParameterDirection.Input,
                        Name = "EndDate",
                        Value = endDate,
                    },
            };

            return dps;
        }

        public List<ClaimStatusSummaryInfo> GetClaimsWithMultipleEras(DateTime selectDate)
        {
            List<ClaimStatusSummaryInfo> results = null;
            DataParameter[] dps = GetDateSelectionParameters(selectDate);

            using (PayerDataContext ctx = NewContext())
            {
                string query = @"
SELECT iq.ClaimId, iq.ClaimNumber, iq.ItemCount, iq.RaCount, iq.ServiceChargeBalance
FROM
(
	SELECT ics.[ClaimId], ics.ClaimNumber, SUM(1) AS ItemCount, SUM(CASE WHEN ich.[RelatedDocumentType] = 'RemittanceAdvice' THEN 1 ELSE 0 END) AS RaCount, SUM(ich.ServiceChargeAmount) AS ServiceChargeBalance
	FROM [Apex].[dbo].[ClaimHistory] AS ich
	JOIN [Apex].[dbo].[ClaimStatus] AS ics
	ON ich.ClaimId = ics.ClaimId
	WHERE @StartDate <= ics.CreateDate
	AND ics.CreateDate < @EndDate
	GROUP BY ics.[ClaimId], ics.[ClaimNumber]
) AS iq
WHERE iq.RaCount > 1
";

                results = ctx.Connection.Query<ClaimStatusSummaryInfo>(query, dps).ToList();
            }

            return results;
        }

        public List<ClaimStatusSummaryInfo> GetUnbalancedClaims(DateTime selectDate)
        {
            List<ClaimStatusSummaryInfo> results = null;
            DataParameter[] dps = GetDateSelectionParameters(selectDate);

            using (PayerDataContext ctx = NewContext())
            {
                string query = @"
SELECT iq.ClaimId, iq.ClaimNumber, iq.ItemCount, iq.RaCount, iq.ServiceChargeBalance
FROM
(
	SELECT ics.[ClaimId], ics.ClaimNumber, SUM(1) AS ItemCount, SUM(CASE WHEN ich.[RelatedDocumentType] = 'RemittanceAdvice' THEN 1 ELSE 0 END) AS RaCount, SUM(ich.ServiceChargeAmount) AS ServiceChargeBalance
	FROM [Apex].[dbo].[ClaimHistory] AS ich
	JOIN [Apex].[dbo].[ClaimStatus] AS ics
	ON ich.ClaimId = ics.ClaimId
	WHERE @StartDate <= ics.CreateDate
	AND ics.CreateDate < @EndDate
	GROUP BY ics.[ClaimId], ics.[ClaimNumber]
) AS iq
WHERE ABS(iq.ServiceChargeBalance) >= 0.01
";

                results = ctx.Connection.Query<ClaimStatusSummaryInfo>(query, dps).ToList();
            }

            return results;
        }

        private static string NormalizeWithNull(string s)
        {
            return String.IsNullOrWhiteSpace(s) ? null : s.Trim();
        }

        public string ConvertPayerStatusToText(PayerClaimState status)
        {
            return WebClaimHistoryAdapter.ConvertPayerStatusToText(status);
        }

        
    }
}