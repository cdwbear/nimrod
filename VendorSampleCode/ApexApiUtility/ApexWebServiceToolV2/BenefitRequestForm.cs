using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
// using ApexWebServiceToolV2.ApexProduction;
// using ApexWebServiceToolV2.ApexProd;
// using ApexWebServiceToolV2.ApexLocal;
using ApexWebServiceToolV2.ApexSandbox;
//using ApexWebServiceToolV2.ApexLocal9557;

namespace ApexWebServiceToolV2
{
    public partial class BenefitRequestForm : Form
    {
        private List<Payer[]> _payerses = null;
        private string _key = string.Empty;
        private string _password = string.Empty;
        private string _vendorSiteId = string.Empty;
        private ClientHelper _clientHelper = null;
        private OneTouchServicesClient client15 = new OneTouchServicesClient();
        private XmlSerializer _xmlSerializer = null;
        private DataContractSerializer _dataContractSerializer = null;
                //_key_15 = ConfigurationManager.AppSettings.Get(ConfigKeys.key15);
                //_pwd_15 = ConfigurationManager.AppSettings.Get(ConfigKeys.password15);
                //_vendorSiteId = ConfigurationManager.AppSettings.Get(ConfigKeys.vendorSiteId);
                //_bindingAddress = ConfigurationManager.AppSettings.Get(ConfigKeys.lastBinding);
 
        public BenefitRequestForm(string key, string password, string vendorSiteId)
        {
            InitializeComponent();

            _clientHelper = ClientHelper.Instance;
            client15 = _clientHelper.ApexClient;

            var currentUrl = client15.Endpoint.Address.ToString();
            if (!string.IsNullOrWhiteSpace(currentUrl))
            {
                this.Text += $" ({currentUrl})";
            }

            dataGridViewServiceTypes.Columns.Add("serviceType", "Service Type");
            dataGridViewServiceTypes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (WsServiceType st in Enum.GetValues(typeof (WsServiceType)))
            {
                if (st != WsServiceType.Unknown)
                {
                    int idx = dataGridViewServiceTypes.Rows.Add(st.ToString());
                    dataGridViewServiceTypes.Rows[idx].Tag = st;
                }
            }

            dataGridViewServiceTypes.Sort(dataGridViewServiceTypes.Columns[0], ListSortDirection.Ascending);
            DataGridViewRow defaultSelectedRow = null;
            foreach (DataGridViewRow row in dataGridViewServiceTypes.Rows)
            {
                if (row.Tag != null && row.Tag is WsServiceType)
                {
                    if ((WsServiceType) row.Tag == WsServiceType.HealthBenefitPlanCoverage)
                    {
                        defaultSelectedRow = row;
                        break;
                    }
                }
            }

            if (defaultSelectedRow != null)
            {
                defaultSelectedRow.Selected = true;
            }

            _key = key;
            _password = password;
            _vendorSiteId = vendorSiteId;

            textBoxEligibilityVendorSiteId.Text = _vendorSiteId;
        }

        private void loadSettings()
        {
            textBoxEligibilityPayeeFirstName.Text = ConfigurationManager.AppSettings.Get(ConfigKeys.eligFirstName);
            textBoxEligibilityPayeeCommonName.Text = ConfigurationManager.AppSettings.Get(ConfigKeys.eligCommonName);
            textBoxNPI.Text = ConfigurationManager.AppSettings.Get(ConfigKeys.eligPayeeNpi);
            textBoxTaxId.Text = ConfigurationManager.AppSettings.Get(ConfigKeys.eligTaxId);
            textBoxPayerID.Text = ConfigurationManager.AppSettings.Get(ConfigKeys.eligPayerId);
            textBoxSubscriberFirst.Text = ConfigurationManager.AppSettings.Get(ConfigKeys.eligSubscriberFirstName);
            textBoxSubscriberLast.Text = ConfigurationManager.AppSettings.Get(ConfigKeys.eligSubscriberLastName);
            textBoxSubscriberID.Text = ConfigurationManager.AppSettings.Get(ConfigKeys.eligSubscriberId);
            DateTime subscriberDob = new DateTime();
            DateTime.TryParse(ConfigurationManager.AppSettings.Get(ConfigKeys.eligSubscriberDob), out subscriberDob);
            if (subscriberDob < dateTimePickerSubscriberDOB.MinDate) subscriberDob = dateTimePickerSubscriberDOB.MinDate;
            dateTimePickerSubscriberDOB.Value = subscriberDob;
            radioButtonSubMale.Checked =
                ConfigurationManager.AppSettings.Get(ConfigKeys.eligSubscriberGender).ToLower() == "male";
            radioButtonSubFemale.Checked = !radioButtonSubMale.Checked;
            textBoxSubscriberID.Text = ConfigurationManager.AppSettings.Get(ConfigKeys.eligSubscriberId);
        }

        private void saveSettings()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings[ConfigKeys.eligFirstName].Value = textBoxEligibilityPayeeFirstName.Text;
            config.AppSettings.Settings[ConfigKeys.eligCommonName].Value = textBoxEligibilityPayeeCommonName.Text;
            config.AppSettings.Settings[ConfigKeys.eligPayeeNpi].Value = textBoxNPI.Text;
            config.AppSettings.Settings[ConfigKeys.eligTaxId].Value = textBoxTaxId.Text;
            config.AppSettings.Settings[ConfigKeys.eligPayerId].Value = textBoxPayerID.Text;
            config.AppSettings.Settings[ConfigKeys.eligSubscriberFirstName].Value = textBoxSubscriberFirst.Text;
            config.AppSettings.Settings[ConfigKeys.eligSubscriberLastName].Value = textBoxSubscriberLast.Text;
            config.AppSettings.Settings[ConfigKeys.eligSubscriberDob].Value =
                dateTimePickerSubscriberDOB.Value.ToString();
            config.AppSettings.Settings[ConfigKeys.eligSubscriberGender].Value = radioButtonSubMale.Checked ? "male" : "female";
            config.AppSettings.Settings[ConfigKeys.eligSubscriberId].Value = textBoxSubscriberID.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void buttonGetPayers_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var payerForm = new EligibilityPayers(_key, _password);
            payerForm.ShowDialog();

            Payer payer = payerForm.SelectedPayer;

            if (null != payer)
            {
                textBoxPayerID.Text = payer.ApexPayerId;
                textBoxPayerID.Tag = payer;
                checkBoxEligibilityIsTest.Checked = payerForm.IsTestPayer(payer);
            }

            Cursor.Current = Cursors.Default;
        }

        private void buttonSubmitEligibilityRequest_Click(object sender, EventArgs e)
        {
            dataGridViewEligibilityResponses.Rows.Clear();

            //submitDeserializedFiles("150101.request.xml");
            //submitDeserializedFiles("150112.request.xml");

            //return;

            if (string.IsNullOrWhiteSpace(_key) || string.IsNullOrWhiteSpace(_password))
            {
                MessageBox.Show("Service credentials are missing!");
            }
            else if (string.Compare(_key, _password, StringComparison.CurrentCulture) == 0)
            {
                MessageBox.Show("Key and Password cannot be the same.");
            }
            else if (textBoxEligibilityVendorSiteId.Text == string.Empty)
            {
                MessageBox.Show("Vendor Site ID is missing!");
                textBoxEligibilityVendorSiteId.Focus();
            }
            else if (textBoxEligibilityPayeeCommonName.Text == string.Empty)
            {
                MessageBox.Show("Please enter Payee Common Name");
                textBoxEligibilityPayeeCommonName.Focus();
            }
            else
            {
                List<string> Names = new List<string>();
                List<string> SubscriberIds = new List<string> ();
                List<string> Birthdates = new List<string>();

                List<WsSubscriberBenefit> benefits = new List<WsSubscriberBenefit>();
                foreach (DataGridViewRow row in dataGridViewServiceTypes.SelectedRows)
                {
                    var theType = dataGridViewServiceTypes.SelectedRows[0].Tag;

                    if (theType is WsServiceType)
                    {
                        benefits.Add(
                            new WsSubscriberBenefit()
                            {
                                Type = new WsServiceType[] { (WsServiceType)theType }
                            });
                    }
                }

                WsEligibilityRequestDependent dependent = null;
                if (checkBoxUseDependent.Checked)
                {
                    dependent = new WsEligibilityRequestDependent()
                    {
                        FirstName = textBoxDependentFirst.Text,
                        CommonName = textBoxDependentLast.Text,
                        BirthDate = dateTimePickerDependentDOB.Value,
                        Gender = radioButtonDepMale.Checked ? WsGender.Male : WsGender.Female,
                        MemberId = "",
                        RequestedBenefits = benefits.ToArray(),
                        PayeeTraceNumber =
                            (string.IsNullOrWhiteSpace(textBoxTraceNumber.Text) && string.IsNullOrWhiteSpace(textBoxOriginatingCompanyId.Text)) ? null
                            : new WsTraceNumber() { Number = textBoxTraceNumber.Text, OriginatorId = textBoxOriginatingCompanyId.Text },
                    };
                }

                var subscriber = new WsEligibilityRequestSubscriber()
                {
                    FirstName = textBoxSubscriberFirst.Text,
                    CommonName = textBoxSubscriberLast.Text,
                    BirthDate = (DateTime?)dateTimePickerSubscriberDOB.Value,
                    Gender = radioButtonSubMale.Checked ? WsGender.Male : WsGender.Female,
                    MemberId = textBoxSubscriberID.Text,
                    Dependents = (dependent == null) ? null : new WsEligibilityRequestDependent[] { dependent },
                    RequestedBenefits = benefits.ToArray(),
                    PayeeTraceNumber =
                        (string.IsNullOrWhiteSpace(textBoxTraceNumber.Text) && string.IsNullOrWhiteSpace(textBoxOriginatingCompanyId.Text)) ? null
                        : new WsTraceNumber() { Number = textBoxTraceNumber.Text, OriginatorId = textBoxOriginatingCompanyId.Text },
                };

                var payee = new WsEligibilityRequestPayee()
                {
                    TaxIdNumber = string.IsNullOrWhiteSpace(textBoxTaxId.Text) ? null : textBoxTaxId.Text,
                    NationalProviderId = textBoxNPI.Text,
                    CommonName = textBoxEligibilityPayeeCommonName.Text,
                    FirstName = textBoxEligibilityPayeeFirstName.Text,
                    Type = WsPayeeType.Provider,
                    EntityType = WsEntityType.Individual,
                    Subscribers = new WsEligibilityRequestSubscriber[]
                            {
                                subscriber,
                            },
                };

                var selectedPayer = textBoxPayerID.Tag as Payer;
                if (selectedPayer == null)
                    selectedPayer = new Payer();

                var payer = new WsEligibilityRequestPayer()
                {
                    PayerId = textBoxPayerID.Text,
                    Type = WsPayerType.Payer,
                    EntityType = WsEntityType.Organization,
                    CommonName = selectedPayer.Name ?? string.Empty,
                    Payees = new WsEligibilityRequestPayee[]
                            {
                                payee
                            }
                };

                var inquiry = new WsBenefitInquiry()
                {
                    Payers = new WsEligibilityRequestPayer[]
                            {
                                payer
                            },
                };

                var request = new WsBenefitSubmitRequest()
                {
                    IsTest = checkBoxEligibilityIsTest.Checked,
                    BenefitInquiries = new WsBenefitInquiry[]
                            {
                                inquiry
                            }
                };


                try
                {
                    if (checkBoxSerializeRequest.Checked)
                    {
                        _xmlSerializer = new XmlSerializer(typeof(WsBenefitSubmitRequest));

                        var fileName = string.Format("270-{0}-{1}-{2}.xml", _vendorSiteId,
                                                     request.BenefitInquiries[0].Payers[0].CommonName, DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                        var pathAndFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                        FileStream file = File.Create(pathAndFile);
                        _xmlSerializer.Serialize(file, request);
                        file.Close();
                    }

                    var firstPayer = request.BenefitInquiries[0].Payers[0];
                    var firstPayee = firstPayer.Payees[0];
                    var firstSubscriber = firstPayee.Subscribers[0];
                    WsEligibilityRequestDependent firstDependent = null;
                    if(firstSubscriber.Dependents != null)
                    {
                        firstDependent = firstSubscriber.Dependents.Length > 0 ? firstSubscriber.Dependents[0] : null;
                    }

                    var newRowIdx = dataGridViewRequests.Rows.Add(
                        _vendorSiteId, firstPayer.CommonName,
                        string.Format("{0} {1}", firstPayee.FirstName, firstPayee.CommonName),
                        string.Format("{0} {1}", firstSubscriber.FirstName, firstSubscriber.CommonName),
                        (firstDependent != null)
                            ? string.Format("{0} {1}", firstDependent.FirstName, firstDependent.CommonName)
                            : string.Empty);

                    dataGridViewRequests.Rows[newRowIdx].Tag = request;

                    // add to data grid view:
                    // Payer Name
                    // Vendor Site ID
                    // Subscriber First/Last DOB
                    // Dependent Firs/Last DOB
                    WsBenefitSubmitResult result = client15.SubmitEligibilityRequest(_key, _password,
                                                                                        textBoxEligibilityVendorSiteId
                                                                                            .Text, request);
                    var errorMessage = string.Empty;
                    if (result.ErrorResponses != null && result.ErrorResponses.Length > 0)
                    {
                        errorMessage = string.Format("{0} errors!  First error: \"{1}\"", result.ErrorResponses.Length,
                                                        result.ErrorResponses[0].ErrorMessage);
                    }

                    var responseCount = 0;
                    if (result.Responses != null && result.Responses.Length > 0)
                    {
                        responseCount = result.Responses.Length;
                    }

                    var idx = dataGridViewEligibilityResponses.Rows.Add(result.RequestId.ToString(), result.Status.ToString(), responseCount, errorMessage);
                    dataGridViewEligibilityResponses.Rows[idx].Tag = result;
                }
                catch (Exception submitEx)
                {
                    MessageBox.Show(submitEx.ToString());
                }
            }
        }

        private void submitDeserializedFiles(string fileName)
        {
            try
            {
                _xmlSerializer = new XmlSerializer(typeof(WsBenefitSubmitRequest));
                // var doveTailFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "150101.request.xml");
                var doveTailFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                var fileStream = File.OpenRead(doveTailFile);
                WsBenefitSubmitRequest doveTailRequest = _xmlSerializer.Deserialize(fileStream) as WsBenefitSubmitRequest;
                fileStream.Close();

                WsBenefitSubmitResult doveTailResult = client15.SubmitEligibilityRequest(_key, _password,
                                                                                         textBoxEligibilityVendorSiteId
                                                                                             .Text, doveTailRequest);

                var errorMessage = string.Empty;
                if (doveTailResult.ErrorResponses != null && doveTailResult.ErrorResponses.Length > 0)
                {
                    errorMessage = string.Format("{0} errors!  First error: \"{1}\"", doveTailResult.ErrorResponses.Length,
                                                    doveTailResult.ErrorResponses[0].ErrorMessage);
                }

                var responseCount = 0;
                if (doveTailResult.Responses != null && doveTailResult.Responses.Length > 0)
                {
                    responseCount = doveTailResult.Responses.Length;
                }

                var idx = dataGridViewEligibilityResponses.Rows.Add(doveTailResult.RequestId.ToString(), doveTailResult.Status.ToString(), responseCount, errorMessage);
                dataGridViewEligibilityResponses.Rows[idx].Tag = doveTailResult;
            }
            catch (Exception submitEx)
            {
                MessageBox.Show(submitEx.ToString());
            }
        }

        private void buttonGetEligibilityResponses_Click(object sender, EventArgs e)
        {
            long idLong = 0L;
            List<long> idList =
                (from DataGridViewRow row in dataGridViewEligibilityResponses.Rows
                 where row.Cells.Count > 0
                 select row.Cells[0].Value.ToString() into idString
                 where long.TryParse(idString, out idLong)
                 select idLong).ToList();

            //idList.Clear();
	        // idList.AddRange((new long[] { 148144, 148173, 148303, 148305, 148321, 148519, 148604, 148605, 148607, 148610, 148615, 148784, 148787, 148791, 148805, 148887, 148904, 148915, 148935, 148944 }));
	        //idList.AddRange((new long[] { 471340, 471342 }));
			//idList.AddRange((new long[] {482146, 482141, 482139}));

			var results = new List<WsBenefitResponseResult>();
            try
            {
                idList.ForEach(id =>
                    results.Add(
                    client15.GetEligibilityResponses(_key, _password,
                    textBoxEligibilityVendorSiteId.Text, id)));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }

            var sb = new StringBuilder("Eligibility Response Results\n\r");
            results.ForEach(
                result =>
                {
                    if (checkBoxSerializeResponse.Checked)
                    {
                        try
                        {
                            _dataContractSerializer = new DataContractSerializer(typeof(WsBenefitResponseResult));

                            //_xmlSerializer = new XmlSerializer(typeof(WsBenefitResponseResult));

                            var fileName = string.Format("EligResponse-{0}-{1}-{2}.xml", _vendorSiteId,
                                result.RequestId, DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                            var pathAndFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                            FileStream file = File.Create(pathAndFile);
                            // _xmlSerializer.Serialize(file, result);
                            _dataContractSerializer.WriteObject(file, result);

                            //var objectReadIn = _dataContractSerializer.ReadObject(file);
                            //XmlReader xmlReader = XmlReader.Create(file);
                            // var xmlContent = xmlReader.ReadElementContentAsString();
                            // XmlDocument xmlDoc = new XmlDocument();
                            // var xmlString = xmlReader.ReadContentAsString();
                           
                            file.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(string.Format("Exception in serializing the Eligibility Response: {0}", ex.Message), 
                                "Exception serializing response", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    sb.AppendLine(string.Format("For Response ID: {0}", result.RequestId));
                    sb.AppendLine("===========================================================");
                    sb.AppendLine(string.Format("Status: {0}", result.Status.ToString()));

                    if (null != result.ErrorResponses)
                    {
                        sb.AppendLine("Errors Returned:");
                        for (int idx = 0; idx < result.ErrorResponses.Length; idx++)
                        {
                            WsErrorResponse err = result.ErrorResponses[idx];
                            sb.AppendLine(string.Format("\r\nError {0}:", idx + 1));
                            sb.AppendLine(string.Format("\tMessage: {0}", err.ErrorMessage));
                            sb.AppendLine(string.Format("\tPayee Trace Number: {0}", err.PayeeTraceNumber));
                            sb.AppendLine(string.Format("\tClearinghouse Trace Number: {0}",
                                                        err.ClearinghouseTraceNumber));
                        }
                    }

                    //if (result.InterchangeStatuses != null)
                    //{
                    //    sb.AppendLine("InterchangeStatus Results Returned:");
                    //    sb.AppendLine("===========================================================");
                    //    foreach (WsPayerInterchangeStatus interchangeStatus in result.InterchangeStatuses)
                    //    {
                    //        sb.AppendLine(string.Format("Group Status: {0}", interchangeStatus.GroupStatus));
                    //        sb.AppendLine(string.Format("Transation Count: {0}", interchangeStatus.TransactionCount));
                    //        foreach (WsTransactionResponse transactionResponse in interchangeStatus.Transactions)
                    //        {
                    //            if (transactionResponse.SyntaxErrors != null)
                    //            {
                    //                transactionResponse.SyntaxErrors.Select(
                    //                    x => sb.AppendLine(string.Format("Syntax Error: {0}", x)));
                    //            }

                    //            if (transactionResponse.Errors != null)
                    //            {
                    //                sb.AppendLine("Segment Errors:");

                    //                int errorIdx = 0;
                    //                transactionResponse.Errors.ToList().ForEach(
                    //                    error =>
                    //                        {
                    //                            sb.AppendLine(string.Format("Error {0}:", ++errorIdx));
                    //                            sb.AppendLine("===========================");
                    //                            if (error.ErrorContexts != null)
                    //                            {
                    //                                sb.AppendLine(string.Format("\tError Context(s):"));
                    //                                sb.AppendLine("===========================");

                    //                                foreach (WsErrorContext errorContext in error.ErrorContexts)
                    //                                {
                    //                                    //errorContext.ElementId, errorContext.ElementReferenceNumber,
                    //                                    //errorContext.LoopId, errorContext.RepeatId, errorContext.SegmentId,
                    //                                    //errorContext.SegmentName, errorContext.SubElementId

                    //                                    sb.AppendLine(string.Format("Element ID: {0}",
                    //                                                                errorContext.ElementId ?? 0));
                    //                                    sb.AppendLine(string.Format("Element Reference Number: {0}",
                    //                                                                errorContext.ElementReferenceNumber ??
                    //                                                                string.Empty));
                    //                                    sb.AppendLine(string.Format("Loop ID: {0}",
                    //                                                                errorContext.LoopId ?? string.Empty));
                    //                                    sb.AppendLine(string.Format("Repeat ID: {0}",
                    //                                                                errorContext.RepeatId ?? 0));
                    //                                    sb.AppendLine(string.Format("Segment ID: {0}",
                    //                                                                errorContext.SegmentId ?? 0));
                    //                                    sb.AppendLine(string.Format("Segment Name: {0}",
                    //                                                                errorContext.SegmentName));
                    //                                    sb.AppendLine(string.Format("SubElement ID: {0}",
                    //                                                                errorContext.SubElementId ?? 0));
                    //                                }
                    //                            }
                    //                            //error.ErrorContexts, error.ElementError, error.EntityReference, error.EntityReferenceType,
                    //                            //error.LoopId, error.SegmentId, error.SegmentPosition, error.SyntaxError, error.

                    //                            if (error.ElementErrors != null)
                    //                            {
                    //                                foreach (WsElementError elementError in error.ElementErrors)
                    //                                {
                    //                                    /*
                    //                                    //elementError.ErrorContexts, 
                    //                                     * elementError.ElementId, elementError.ElementReferenceNumber,
                    //                                    //elementError.RelatedData, 
                    //                                     * elementError.RepeatId, 
                    //                                     * elementError.SubElementId, 
                    //                                     * elementError.SyntaxError
                    //                                     * */
                    //                                }
                    //                            }
                    //                        }
                    //                    );
                    //            }
                    //        }
                    //    }
                    //}

                    if (result.ValidationResults != null)
                    {
                        sb.AppendLine("Validation Results Returned:");
                        sb.AppendLine("===========================================================");
                        foreach (WsValidationResult validation in result.ValidationResults)
                        {
                            processRequestErrors(validation.GeneralErrors, sb, "General");

                            sb.AppendLine(string.Format("Original Submitter Transaction ID: {0}",
                                                        validation.OriginalSubmitterTransactionId));

                            if (validation.ValidationPayers != null)
                            {
                                foreach (WsValidationPayer payer in validation.ValidationPayers)
                                {
                                    processRequestErrors(payer.Errors, sb, "Validation Payer");

                                    sb.AppendLine("Validation Payer IDs:");
                                    processIDs(payer.Ids, sb);

                                    if (payer.Payees == null)
                                        continue;

                                    sb.AppendLine("Validation Payees:");
                                    foreach (WsValidationPayee payee in payer.Payees)
                                    {
                                        processRequestErrors(payee.Errors, sb, "Payee");

                                        sb.AppendLine("Validation Payee IDs:");
                                        processIDs(payee.Ids, sb);

                                        if (null == payee.Subscribers)
                                            continue;

                                        sb.AppendLine("Subscribers:");
                                        foreach (WsValidationSubscriber subscriber in payee.Subscribers)
                                        {
                                            processRequestErrors(subscriber.Errors, sb, "Subscriber");

                                            sb.AppendLine("Subscriber Ids:");
                                            processIDs(subscriber.Ids, sb);


                                            if (null == subscriber.Dependents)
                                                continue;

                                            sb.AppendLine("Subscriber Dependents:");
                                            foreach (WsValidationDependent dependent in subscriber.Dependents)
                                            {
                                                processRequestErrors(dependent.Errors, sb, "Dependent");
                                                sb.AppendLine("Dependent IDs:");

                                                if (null == dependent.Ids)
                                                    continue;

                                                processIDs(dependent.Ids, sb);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (null != result.Responses)
                    {
                        sb.AppendLine("Responses Returned:");
                        sb.AppendLine("===========================================================");
                        foreach (WsBenefitResponse response in result.Responses)
                        {
                            //var serializer = new XmlSerializer(typeof (WsBenefitResponse));
                            //var path = string.Format(@"BenefitResponse-{0}.xml", DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                            //FileStream file = File.Create(path);

                            //serializer.Serialize(file, response);
                            //file.Close();

                            sb.AppendFormat("\tCreated: ");
                            if (response.CreateDate.HasValue)
                            {
                                sb.AppendFormat("{0}\r\n", response.CreateDate.Value.ToLongTimeString());
                            }
                            sb.AppendLine(string.Format("\tDocument ID: {0}", response.DocumentId ?? string.Empty));
                            sb.AppendLine(string.Format("\tGroup Control Number: {0}", response.GroupControlNumber ?? string.Empty));
                            sb.AppendLine(string.Format("\tTrading Partner ID: {0}", response.TradingPartnerId ?? string.Empty));

                            processRequestErrors(response.EnvelopeErrors, sb, "Envelope");

                            if (null == response.Payers)
                                continue;

                            sb.AppendLine("Response Payers:");

                            foreach (WsEligibilityResponsePayer payer in response.Payers)
                            {
                                
                                sb.AppendLine(string.Format("\tFirst Name: {0}", payer.FirstName ?? string.Empty));
                                sb.AppendLine(string.Format("\tMiddle Name: {0}", payer.MiddleName ?? string.Empty));
                                sb.AppendLine(string.Format("\tCommon Name: {0}", payer.CommonName ?? string.Empty));

                                sb.AppendLine(string.Format("\tCmsPlanId: {0}", payer.CmsPlanId ?? string.Empty));
                                sb.AppendLine(string.Format("\tElectronic Transmitter ID Number: {0}",
                                                            payer.ElectronicTransmitterIdNumber ?? string.Empty));
                                sb.AppendLine(string.Format("\tEmployers ID Number: {0}", payer.EmployersIdNumber ?? string.Empty));
                                sb.AppendLine(string.Format("\tNaic ID: {0}", payer.NaicId ?? string.Empty));
                                sb.AppendLine(string.Format("\tNational Payer ID Number: {0}",
                                                            payer.NationalPayerIdNumber ?? string.Empty));
                                sb.AppendLine(string.Format("\tNational Provider ID: {0}", payer.NationalProviderId ?? string.Empty));
                                sb.AppendLine(string.Format("\tPayer ID: {0}", payer.PayerId ?? string.Empty));
                                sb.AppendLine(string.Format("\tSuffix: {0}", payer.Suffix ?? string.Empty));
                                sb.AppendLine(string.Format("\tTax ID: {0}", payer.TaxIdNumber ?? string.Empty));

                                if (payer.EntityType.HasValue)
                                {
                                    sb.AppendLine(string.Format("\tEntity Type: {0}", payer.EntityType.ToString()));
                                }

                                if (payer.Type.HasValue)
                                {
                                    sb.AppendLine(string.Format("\tPayer Type: {0}", payer.Type.Value.ToString()));
                                }


                                processRequestErrors(payer.Errors, sb, "Payer");

                                if (null != payer.Contacts)
                                {
                                    sb.AppendLine("Payer Contacts:");
                                    foreach (WsResponseContact contact in payer.Contacts)
                                    {
                                        sb.AppendLine(string.Format("\tName: {0}", contact.Name ?? string.Empty));
                                        if (contact.Methods != null)
                                        {
                                            sb.AppendLine("\tPayer Contact Methods:");
                                            foreach (WsResponseContactMethods methods in contact.Methods)
                                            {
                                                sb.AppendLine(string.Format("\t\tEDI Access Number: {0}",
                                                    methods.EdiAccessNumber ?? string.Empty));
                                                sb.AppendLine(string.Format("\t\tEmail Address: {0}",
                                                    methods.EmailAddress ?? string.Empty));
                                                sb.AppendLine(string.Format("\t\tFax Number: {0}",
                                                    methods.FaxNumber ?? string.Empty));
                                                sb.AppendLine(string.Format("\t\tPhone Number: {0}",
                                                    methods.PhoneNumber ?? string.Empty));
                                                sb.AppendLine(string.Format("\t\tPhone Number Extension: {0}",
                                                    methods.PhoneNumberExtension ?? string.Empty));
                                                sb.AppendLine(
                                                    string.Format("\t\tUrl: {0}", methods.Url ?? string.Empty));
                                            }
                                        }
                                    }
                                }

                                if (null == payer.Payees)
                                    continue;

                                sb.AppendLine("Eligibility Response Payees:");

                                foreach (WsEligibilityResponsePayee payee in payer.Payees)
                                {

                                    sb.AppendLine(string.Format("\tFirst Name: {0}", payee.FirstName ?? string.Empty));
                                    sb.AppendLine(string.Format("\tMiddle Name: {0}", payee.MiddleName ?? string.Empty));
                                    sb.AppendLine(string.Format("\tLast Name: {0}", payee.CommonName ?? string.Empty));
                                    sb.AppendLine(string.Format("\tSuffix: {0}", payee.Suffix ?? string.Empty));
                                    processPhysicalAddress(payee.PhysicalAddress, sb);

                                    sb.Append("\tEntity Type: ");
                                    if (payee.EntityType.HasValue)
                                    {
                                        sb.AppendFormat("\t{0}\r\n", payee.EntityType.ToString());
                                    }

                                    sb.Append("\tPayee Type: ");
                                    if (payee.Type.HasValue)
                                    {
                                        sb.AppendFormat("\t{0}\r\n", payee.Type.Value.ToString());
                                    }

                                    sb.Append("\tProvider Role: ");
                                    if (payee.ProviderRole.HasValue)
                                    {
                                        sb.AppendFormat("\t{0}\r\n", payee.ProviderRole.Value.ToString());
                                    }

                                    sb.AppendLine(string.Format("\tPayer ID: {0}", payee.PayerId ?? string.Empty));
                                    sb.AppendLine(string.Format("\tNational Provider ID: {0}",
                                                                payee.NationalProviderId ?? string.Empty));
                                    sb.AppendLine(string.Format("\tTax ID Number: {0}", payee.TaxIdNumber ?? string.Empty));
                                    sb.AppendLine(string.Format("\tState Issuing License: {0}",
                                                                payee.StateIssuingLicense ?? string.Empty));
                                    sb.AppendLine(string.Format("\tReceiving Provider Taxonomy Code: {0}",
                                                                payee.ReceivingProviderTaxonomyCode ?? string.Empty));
                                    sb.AppendLine(string.Format("\tCMS Plan ID: {0}", payee.CmsPlanId ?? string.Empty));
                                    sb.AppendLine(string.Format("\tProvider Plan Network ID: {0}",
                                                                payee.ProviderPlanNetworkId ?? string.Empty));

                                    sb.AppendLine(string.Format("\tContract Number: {0}", payee.ContractNumber ?? string.Empty));
                                    sb.AppendLine(string.Format("\tEmployee ID Number: {0}", payee.EmployersIdNumber ?? string.Empty));
                                    sb.AppendLine(string.Format("\tFacility Network ID: {0}",
                                                                payee.FacilityNetworkIdNumber ?? string.Empty));
                                    sb.AppendLine(string.Format("\tSocial Security Number: {0}",
                                                                payee.SocialSecurityNumber ?? string.Empty));
                                    sb.AppendLine(string.Format("\tMedicaid Provider Number: {0}",
                                                                payee.MedicaidProviderNumber ?? string.Empty));
                                    sb.AppendLine(string.Format("\tMedicare Provider Number: {0}",
                                                                payee.MedicareProviderNumber ?? string.Empty));
                                    sb.AppendLine(string.Format("\tService Provider Number: {0}",
                                                                payee.ServiceProviderNumber ?? string.Empty));
                                    sb.AppendLine(string.Format("\tSubmitter ID Number: {0}",
                                                                payee.SubmitterIdNumber ?? string.Empty));
                                    sb.AppendLine(string.Format("\tPersonal ID Number: {0}", payee.PersonalIdNumber ?? string.Empty));
                                    sb.AppendLine(string.Format("\tDevice PIN: {0}", payee.DevicePin ?? string.Empty));
                                    sb.AppendLine(string.Format("\tPharmacy Number: {0}", payee.PharmacyNumber ?? string.Empty));
                                    sb.AppendLine(string.Format("\tPrior ID Number: {0}", payee.PriorIdNumber ?? string.Empty));
                                    sb.AppendLine(string.Format("\tUser ID: {0}", payee.UserId ?? string.Empty));

                                    processRequestErrors(payee.Errors, sb, "Payee");

                                    if (null == payee.Subscribers)
                                        continue;

                                    sb.AppendLine("Eligibility Response Subscribers:");
                                    sb.AppendLine("===========================================================");
                                    foreach (WsEligibilityResponseSubscriber subscriber in payee.Subscribers)
                                    {
                                        // Subscriber Unique:
                                        //  Case Number
                                        //  Entity Type
                                        //  Dependent[]

                                        // Dependent Unique:
                                        //  RelationshipToSubscriber
                                        sb.AppendLine(string.Format("\tCase Number: {0}", subscriber.CaseNumber ?? string.Empty));

                                        sb.Append("\tEntity Type: ");
                                        if (subscriber.EntityType.HasValue)
                                        {
                                            sb.AppendFormat("\t{0}\r\n", subscriber.EntityType.Value.ToString());
                                        }

                                        processEligibilityPatient(subscriber, sb);

                                        if (null == subscriber.Dependents)
                                            continue;

                                        sb.AppendLine("Dependents");
                                        sb.AppendLine(
                                            "===========================================================");
                                        foreach (WsEligibilityResponseDependent dependent in subscriber.Dependents)
                                        {
                                            sb.AppendLine(string.Format("\tRelation to Subscriber: {0}",
                                                                        dependent.RelationshipToSubscriber
                                                                                    .ToString()));

                                            processEligibilityPatient(dependent, sb);
                                        }
                                    }
                                }
                            }
                        }
                    }
                });
            richTextBoxResults.Clear();
            richTextBoxResults.Text = sb.ToString();

        }

        private void processEligibilityPatient(WsEligibilityResponsePatient patient, StringBuilder sb)
        {
            sb.AppendLine(string.Format("\tFirst Name: {0}", patient.FirstName ?? string.Empty));
            sb.AppendLine(string.Format("\tMiddle Name: {0}", patient.MiddleName ?? string.Empty));
            sb.AppendLine(string.Format("\tLast Name: {0}", patient.CommonName ?? string.Empty));
            sb.AppendLine(string.Format("\tSuffix: {0}", patient.Suffix ?? string.Empty));
            sb.AppendLine(string.Format("\tGender: {0}", patient.Gender.ToString()));
            processDate(patient.BirthDate, sb, "Birth Date");
            processDate(patient.DeathDate, sb, "Death Date");
            processPhysicalAddress(patient.PhysicalAddress, sb);
            sb.AppendLine(string.Format("\tSocial Security Number: {0}", patient.SocialSecurityNumber ?? string.Empty));
            processDate(patient.AdmissionDate, sb, "Admission Date");
            sb.AppendLine(string.Format("\tAgency Claim Number: {0}", patient.AgencyClaimNumber ?? string.Empty));
            processDate(patient.CertificationDate, sb, "Certification Date");
            sb.AppendLine(string.Format("\tClass of Contract: {0}", patient.ClassOfContract ?? string.Empty));
            sb.AppendLine(string.Format("\tClearinghouse Trace Number: {0}", patient.ClearinghouseTraceNumber));
            processDateRange(patient.CobraDates, sb, "Cobra Dates");
            sb.AppendLine(string.Format("\tContract Number: {0}", patient.ContractNumber));
            processDate(patient.DateAdded, sb, "Date Added");
            processDate(patient.DateOfLastUpdate, sb, "Date of Last Update");
            processDate(patient.DischargeDate, sb, "Discharge Date");
            processDate(patient.EffectiveDateOfChange, sb, "Effective Date of Change");
            sb.AppendLine(string.Format("\tEligibility Category: {0}", patient.EligibilityCategory));
            processDate(patient.EligibilityDate, sb, "Eligibility Date");
            processDateRange(patient.EligibilityDates, sb, "Eligibility Dates");
            processDate(patient.EnrollmentDate, sb, "Enrollment Date");
            sb.AppendLine(string.Format("\tFamily Unit Number: {0}", patient.FamilyUnitNumber));
            sb.AppendLine(string.Format("\tGroup Number: {0}", patient.GroupNumber));
            sb.AppendLine(string.Format("\tGroup or Policy Number: {0}", patient.GroupOrPolicyNumber));
            sb.AppendLine(string.Format("\tHealth Insurance Claim Number: {0}",
                                        patient.HealthInsuranceClaimNumber));
            sb.AppendLine(string.Format("\tID Card Serial Number: {0}", patient.IdCardSerialNumber));
            sb.AppendLine(string.Format("\tIdentity Card Number: {0}",
                                        patient.IdentityCardNumber));
            sb.AppendLine(string.Format("\tIs Insured: {0}", patient.IsInsured));
            processDateRange(patient.IssueDate, sb, "Issue Date");
            sb.AppendLine(string.Format("\tIssue Number: {0}", patient.IssueNumber));
            sb.AppendLine(string.Format("\tMedical Recipient ID: {0}", patient.MedicaidRecipientId));
            sb.AppendLine(string.Format("\tMedical Record Number: {0}", patient.MedicalRecordNumber));
            sb.AppendLine(string.Format("\tMember ID: {0}", patient.MemberId));
            sb.AppendLine(string.Format("\tMember ID Suffix: {0}", patient.MemberIdSuffix));
            processMilitaryService(patient.MilitaryService, sb);
            sb.AppendLine(string.Format("\tMultiple Birth Sequence Number: {0}",
                                        patient.MultipleBirthSequenceNumber != null
                                        ? patient.MultipleBirthSequenceNumber.Value.ToString() : string.Empty));
            sb.AppendLine(string.Format("\tOriginal Primary ID: {0}", patient.OriginalPrimaryId));
            sb.AppendLine(string.Format("\tPatient Account Number: {0}", patient.PatientAccountNumber));
            sb.AppendLine(string.Format("\tPayee Trace Number: {0}", patient.PayeeTraceNumber));
            sb.AppendLine(string.Format("\tPayer Trace Number: {0}", patient.PayerTraceNumber));
            processDateRange(patient.PlanDate, sb, "Plan Date");
            processDateRange(patient.PlanDates, sb, "Plan Dates");
            sb.AppendLine(string.Format("\tPlan Network ID Number: {0}", patient.PlanNetworkIdNumber));
            sb.AppendLine(string.Format("\tPlan Number: {0}", patient.PlanNumber));
            sb.AppendLine(string.Format("\tPlan or Group Name: {0}", patient.PlanOrGroupName));
            processDateRange(patient.PolicyDates, sb, "Policy Dates");
            sb.AppendLine(string.Format("\tPolicy Number: {0}", patient.PolicyNumber));
            processDateRange(patient.PremiumPaidDates, sb, "Premium Paid Dates");
            sb.AppendLine(string.Format("\tPrimary Information Changed: {0}", patient.PrimaryInformationChanged));
            processDate(patient.ServiceDate, sb, "Service Date");
            sb.AppendLine(string.Format("\tStandard Unique ID: {0}", patient.StandardUniqueId));
            processDate(patient.StatusDate, sb, "Status Date");
            sb.AppendLine(string.Format("\tTaxonomy Code: {0}", patient.TaxonomyCode));
            sb.AppendLine(string.Format("\tTaxonomy Role: {0}", patient.TaxonomyRole != null
                                            ? patient.TaxonomyRole.Value.ToString()
                                            : string.Empty));
            processRequestErrors(patient.Errors, sb);

        }

        private void processMilitaryService(WsMilitaryService militaryService, StringBuilder sb)
        {
            if (null != militaryService)
            {
                sb.AppendLine("\tMilitary Service:");
                sb.AppendLine(string.Format("\t\tAffiliation: {0}", militaryService.Affiliation.ToString()));
                sb.AppendLine(string.Format("\t\tDescription: {0}", militaryService.Description));
                sb.AppendLine(string.Format("\t\tRank: {0}", militaryService.Rank != null
                                                                 ? militaryService.Rank.Value.ToString()
                                                                 : string.Empty));
                processDateRange(militaryService.ServiceDate, sb, "Service Date");
                sb.AppendLine(string.Format("\tStatus: {0}", militaryService.Status.ToString()));
                sb.AppendLine(string.Format("\tStatus of Service: {0}", militaryService.StatusOfService.ToString()));
            }
        }

        private void processDate(DateTime? dateTime, StringBuilder sb, string fieldName)
        {
            if (null != dateTime)
            {
                sb.AppendLine(string.Format("\t{0}: {1}", fieldName,
                                            dateTime.HasValue ? dateTime.Value.ToLongDateString() : "<Not Given>"));
            }
        }

        private void processDateRange(WsDateRange dateRange, StringBuilder sb, string fieldName)
        {
            if (null != dateRange)
            {
                processDate(dateRange.Start, sb, fieldName + " - Start");
                processDate(dateRange.End, sb, fieldName + " - End");
            }
        }

        private void processPhysicalAddress(WsAddress address, StringBuilder sb)
        {
            if (null != address)
            {
                sb.AppendLine(string.Format("\tPhysical Address:"));
                sb.AppendLine(string.Format("\t\tSend To Attention Of: {0}",
                                            address.SendToAttentionOf));
                sb.AppendLine(string.Format("\t\tAddress1: {0}", address.Address1));
                sb.AppendLine(string.Format("\t\tAddress2: {0}", address.Address2));
                sb.AppendLine(string.Format("\t\tCity: {0}, State: {1}, ZIP: {2}",
                                            address.City,
                                            address.State,
                                            address.ZipCode));
                sb.AppendLine(string.Format("\t\tCountry Code: {0}, Country Sub Code: {1}",
                                            address.CountryCode,
                                            address.CountrySubCode));
            }
        }

        private void processIDs(Dictionary<string, string> idDict, StringBuilder sb)
        {
            if (idDict != null)
            {
                foreach (KeyValuePair<string, string> kvp in idDict)
                {
                    sb.AppendLine(string.Format("\t{0}:{1}", kvp.Key, kvp.Value));
                }
            }
        }

        private void processRequestErrors(WsRequestError[] rqeArray, StringBuilder sb, string objectName = "")
        {
            if (rqeArray != null)
            {
                sb.AppendLine(string.Format("{0}Errors",
                                            !string.IsNullOrWhiteSpace(objectName) ? objectName + " " : string.Empty));
                //foreach(ValidationConstraints.)
                foreach (WsRequestError error in rqeArray)
                {
                    sb.AppendLine(string.Format("\tPayer ID {0} returned Error Message: {1}",
                                                error.PayerId, error.Message));
                    sb.AppendLine(string.Format("\tInvalid Request: {0}",
                                                error.InvalidRequest.ToString()));
                    sb.AppendLine(string.Format("\tAction: {0}", error.Action.ToString()));
                    sb.AppendLine(string.Format("\tReason: {0}", error.Reason.ToString()));
                    sb.AppendLine(string.Format("\tPayer ID: {0}", error.PayerId));
                }
            }
        }

        private void checkBoxUseDependent_CheckedChanged(object sender, EventArgs e)
        {
            var checkBoxDependent = sender as CheckBox;
            if (null != checkBoxDependent)
            {
                bool enabled = checkBoxDependent.Checked;

                textBoxDependentFirst.Enabled = enabled;
                textBoxDependentLast.Enabled = enabled;
                dateTimePickerDependentDOB.Enabled = enabled;
                tableLayoutPanelDepGender.Enabled = enabled;
                textBoxDependentSubscriberId.Enabled = enabled;
            }
        }

        private void BenefitRequestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettings();
        }

        private void BenefitRequestForm_Load(object sender, EventArgs e)
        {
            loadSettings();
        }

        private void textBoxEligibilityVendorSiteId_TextChanged(object sender, EventArgs e)
        {
            _vendorSiteId = ((TextBox) sender).Text;
        }

        private void textBoxTaxId_TextChanged(object sender, EventArgs e)
        {
        }

        private void buttonSubmitSelectedRequests_Click(object sender, EventArgs e)
        {
            List<WsBenefitSubmitRequest> list = new List<WsBenefitSubmitRequest>();
            WsBenefitSubmitRequest batchRequest = new WsBenefitSubmitRequest();
            List<WsBenefitInquiry> inquiries = new List<WsBenefitInquiry>();

            foreach (DataGridViewRow row in dataGridViewRequests.SelectedRows)
            {
                var request = row.Tag as WsBenefitSubmitRequest;
                if (null != request)
                {
                    inquiries.Add(request.BenefitInquiries[0]);
                }
            }

            batchRequest.BenefitInquiries = inquiries.ToArray();
        }

        private void buttonSubmitAllRequests_Click(object sender, EventArgs e)
        {

        }

        private void buttonClearRequests_Click(object sender, EventArgs e)
        {
            dataGridViewRequests.Rows.Clear();
        }
    }
}
