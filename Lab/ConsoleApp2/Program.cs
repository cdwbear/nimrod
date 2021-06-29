using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
	class Program
	{
		public static string PATTERN_BILL_PROV = @"HL\*[\d]+\*\*20\*1";
		public static string PATTERN_SUBSCRIBER = @"HL\*[\d]+\*[\d]+\*22\*[01]";
		public static string PATTERN_PATIENT = @"HL\*[\d]+\*[\d]+\*23\*[01]";
		public static string PATTERN_CLAIM = @"~CLM\*";
		public static string PATTERN_OTHER_SUBSCRIBER = @"~SBR\*";
		public static string PATTERN_LINE_ITEM = @"~LX\*";
		public static string PATTERN_SUBMITTER_CONTACT = @"~NM1\*41\*";

		static void Main(string[] args)
		{
			string claimText = @"ISA*00*          *00*          *ZZ*11916          *ZZ*APEX EDI       *190702*0101*^*00501*000000905*1*P*:~GS*HC*11916*APEX EDI*20190702*0101*1*X*005010X222A1~ST*837*000000001*005010X222A1~BHT*0019*00*5d1aacf606480f105cdbe2f4*20190702*0101*CH~NM1*41*2*Andrea Miller Counseling*****46*11916~PER*IC*Andrea Miller Counseling*TE*2538394172~PER*IC*Andrea Miller Counseling*EM*apex@apexedi.com~NM1*40*2*Apex*****46*APEX EDI~HL*1**20*1~NM1*85*2*Andrea Miller Counseling*****XX*1669817979~N3*31919 1st Ave S Suite 203~N4*Federal Way*WA*980035236~REF*EI*831397170~HL*2*1*22*0~SBR*P**1002534******OF~NM1*IL*1*Coker*Bryan****MI*AVN601261603~N3*13538 NE 127th Ave~N4*Kirkland*WA*98034~DMG*D8*19711207*M~NM1*PR*2*Premera Blue Cross - Washington*****PI*00430~N3*P O Box 914059~N4*seattle*WA*98111~HL*3*2*23*0~PAT*19~NM1*QC*1*Coker*Marley~N3*3234 Destination Ave E~N4*Fife*WA*98424~DMG*D8*19990721*F~CLM*000000003668*175.00***11:B:1*Y*A*Y*Y~HI*ABK:F41.1*ABF:F90.2*ABF:F33.9~NM1*82*1*Miller*Andrea*Celeste***XX*1669817979~LX*1~SV1*HC:90837*175.00*UN*1***1:2:3~DTP*472*D8*20190701~REF*6R*002~SE*33*000000001~GE*1*1~IEA*1*000000905~";

			Parse(claimText);
		}


		public static string Parse(string content)
		{
			string retVal = string.Empty;

			try
			{
				var text = content.ToUpperInvariant();
				var elSep = GetElementSeparator(text, "");
				var compSep = GetComponentSeparator(text, "", elSep);
				var subelSep = GetSubElementSeparator(text, elSep);
				if (!string.IsNullOrEmpty(subelSep) && string.CompareOrdinal(subelSep, ":") != 0)
				{
					text = text.Replace(subelSep, ":");
				}

				var patBillProv = PATTERN_BILL_PROV.Replace("\\*", "\\" + elSep).Replace("~", compSep);
				var patSubscriber = PATTERN_SUBSCRIBER.Replace("\\*", "\\" + elSep).Replace("~", compSep);
				var patPatient = PATTERN_PATIENT.Replace("\\*", "\\" + elSep).Replace("~", compSep);
				var patClaim = PATTERN_CLAIM.Replace("\\*", "\\" + elSep).Replace("~", compSep);
				var patOtherSub = PATTERN_OTHER_SUBSCRIBER.Replace("\\*", "\\" + elSep).Replace("~", compSep);
				var patLineItem = PATTERN_LINE_ITEM.Replace("\\*", "\\" + elSep).Replace("~", compSep);
				var patGS = compSep + "GS" + "\\" + elSep;
				var patSubmitContact = PATTERN_SUBMITTER_CONTACT.Replace("\\*", "\\" + elSep).Replace("~", compSep);

				//var patSubmitterContact = PATTER

				var gsSegmentStrs = Regex.Split(text, patGS);

				if (gsSegmentStrs == null || gsSegmentStrs.Length == 1) //no gs segment found - Hey, it could happen!
				{
					//if (errors != null)
					//{
					//	errors.Add(new ErrorInfo
					//	{
					//		ErrorDescription = "GS segment could not be found.",
					//		MethodName = MethodBase.GetCurrentMethod().Name,
					//		IsFatal = true
					//	});
					//}
				}

				// GS Segments
				for (var i = 1; i < gsSegmentStrs.Length; i++)
				{
					var submitterMatch = GetSubmitterContactInfo(gsSegmentStrs[i], elSep, compSep);

					var groupMatches = submitterMatch.Groups;

					Dictionary<string, object> valueDict = new Dictionary<string, object>();

					valueDict["submitEnt"] = groupMatches["submitEnt"].Value;
					valueDict["submitLast"] = groupMatches["submitList"].Value;
					valueDict["submitFirst"] = groupMatches["submitFirst"].Value;
					valueDict["submitMI"] = groupMatches["submitMI"].Value;
					valueDict["identCode"] = groupMatches["identCode"].Value;
					valueDict["name1"] = groupMatches["name1"].Value;
					valueDict["qual1_1"] = groupMatches["qual1_1"].Value;
					valueDict["num1_1"] = groupMatches["num1_1"].Value;
					valueDict["qual2_1"] = groupMatches["qual2_1"].Value;
					valueDict["num2_1"] = groupMatches["num2_1"].Value;
					valueDict["qual3_1"] = groupMatches["qual3_1"].Value;
					valueDict["num3_1"] = groupMatches["num3_1"].Value;
					valueDict["name2"] = groupMatches["name2"].Value;
					valueDict["qual1_2"] = groupMatches["qual1_2"].Value;
					valueDict["num1_2"] = groupMatches["num1_2"].Value;
					valueDict["qual2_2"] = groupMatches["qual2_2"].Value;
					valueDict["num2_2"] = groupMatches["num2_2"].Value;
					valueDict["qual3_2"] = groupMatches["qual3_2"].Value;
					valueDict["num3_2"] = groupMatches["num3_2"].Value;
					valueDict["jojo"] = groupMatches["jojo"].Value;

					foreach(Group groupObj in submitterMatch.Groups)
					{
						Console.WriteLine($"Group Name: {groupObj.Name}, Value: {groupObj.Value}");

					}

					var billProvStrs = Regex.Split(gsSegmentStrs[i], patBillProv);
					if (billProvStrs.Length == 1) //If No billProvStrs -> error  
					{
					}

					// Billing Providers
					for (var j = 1; j < billProvStrs.Length; j++)
					{
						var billProvMatch = GetBillingProviderInfo(billProvStrs[j], elSep, compSep);

						//if (!billProvMatch.Success)
						//{
						//	if (errors != null)
						//	{
						//		errors.Add(new ErrorInfo
						//		{
						//			ErrorDescription = "No Billing Provider information could be found.",
						//			MethodName = MethodBase.GetCurrentMethod().Name,
						//			IsFatal = true
						//		});
						//	}
						//}
						var payToMatch = GetPayToProviderInfo(billProvStrs[j], elSep, compSep);
					}
				}
			}
			catch (Exception ex)
			{

			}

			return retVal;
		}

		public static string GetElementSeparator(string text)
		{
			return GetElementSeparator(text, null);
		}

		public static string GetElementSeparator(string text, string fileName)
		{
			string elSep = null;
			try
			{
				var tmpRegex = new Regex("ISA(?<elSep>.)00");
				var tmpMatch = tmpRegex.Match(text);
				if (tmpMatch.Success)
				{
					elSep = tmpMatch.Result("${elSep}");
				}
			}
			catch (Exception ex)
			{
				throw;
			}

			return elSep;
		}
		public static string GetSubElementSeparator(string text, string elSep)
		{
			string subElementSeparator = null;

			try
			{
				// Get the component separator
				var tmpRegex = new Regex(@"[01]\*[PT]\*(?<subElemSep>[\^\<\>\:\|\%\{])?([`'~])[GS|TA]".Replace("*", elSep),
					RegexOptions.Compiled);
				var tmpMatch = tmpRegex.Match(text);
				if (tmpMatch.Success)
				{
					subElementSeparator = tmpMatch.Result("${subElemSep}");
				}
			}
			catch (Exception ex)
			{
				throw;
			}

			return subElementSeparator;
		}


		public static string GetComponentSeparator(string text, string fileName, string elSep)
		{
			string compSep = null;

			try
			{
				// Get the component separator
				var tmpRegex = new Regex(@"[01]\*[PT]\*([\^\<\>\:\|\%\{])?(?<compSep>[`'~])[GS|TA]".Replace("*", elSep),
					RegexOptions.Compiled);
				var tmpMatch = tmpRegex.Match(text);
				if (tmpMatch.Success)
				{
					compSep = tmpMatch.Result("${compSep}");
				}
				else
				{
					compSep = text[105].ToString();
				}
			}
			catch (Exception ex)
			{
				throw;
			}

			return compSep;
		}


		public static string GetFunctionalGroupControlNumber(string text)
		{
			// Note: This method will only return the first functional group control number.
			string contNum = null;

			// First lets get the element separator and component separator
			var elSep = GetElementSeparator(text);
			var compSep = GetComponentSeparator(text, null, elSep);

			var pattern =
				@"~GS\*([\w\d]+)\*([\w\s\d\#\/\\\,\(\)\&\'\.-]+)\*([\w\s\d\#\/\\\,\(\)\&\'\.-]+)\*([\d]+)\*([\d]+)\*(?<contNumber>[\d]+)";
			var tmpRegex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var tmpMatch = tmpRegex.Match(text);
			if (tmpMatch.Success)
			{
				var tmpStr = tmpMatch.Result("${contNumber}");
				if (tmpStr != "" && tmpStr != "${contNumber}")
				{
					contNum = tmpStr;
				}
			}

			return contNum;
		}


		public static string GetSubmitterTransactionID(string text)
		{
			string transID = null;

			// First lets get the element separator and component separator
			var elSep = GetElementSeparator(text);
			var compSep = GetComponentSeparator(text, null, elSep);

			var pattern =
				@"~BHT\*([\d]+)\*([\d]+)\*(?<submitterTransID>[\w\s\d\#\/\\\,\(\)\&\'\.-]+)\*";
			var tmpRegex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var tmpMatch = tmpRegex.Match(text);
			if (tmpMatch.Success)
			{
				var tmpStr = tmpMatch.Result("${submitterTransID}");
				if (tmpStr != "" && tmpStr != "${submitterTransID}")
				{
					transID = tmpStr;
				}
			}

			return transID;
		}


		public static string GetISASubmitterID(string text)
		{
			string transID = null;

			// First lets get the element separator and component separator
			var elSep = GetElementSeparator(text);
			var compSep = GetComponentSeparator(text, null, elSep);

			var pattern =
				@"ISA\*([\w]+)\*([\w\s]+)\*([\w]+)\*([\w\s]+)\*([\w]+)\*([\w\s\d\#\/\\\,\(\)\&\'\.-]+)\*([\w]+)\*(?<submitterID>[\w\s\d\#\/\\\,\(\)\&\'\.-]+)\*";
			var tmpRegex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var tmpMatch = tmpRegex.Match(text);
			if (tmpMatch.Success)
			{
				var tmpStr = tmpMatch.Result("${submitterID}");
				if (tmpStr != "" && tmpStr != "${submitterID}")
				{
					transID = tmpStr.Trim();
				}
			}

			return transID;
		}


		public static string GetTraceNumber(string text)
		{
			string traceNumber = null;

			if (!string.IsNullOrEmpty(text))
			{
				// First lets get the element separator and component separator
				var elSep = GetElementSeparator(text);

				if (!string.IsNullOrEmpty(elSep))
				{
					var pattern =
						@"~TRN\*([\d]+)\*(?<traceNumber>[\d\w]+)\*";
					var tmpRegex = new Regex(pattern.Replace("\\*", "\\" + elSep));
					var tmpMatch = tmpRegex.Match(text);
					if (tmpMatch.Success)
					{
						var tmpStr = tmpMatch.Result("${traceNumber}");
						if (tmpStr != "" && tmpStr != "${traceNumber}")
						{
							traceNumber = tmpStr;
						}
					}
				}
			}

			return traceNumber;
		}

		public static Match GetSubmitterContactInfo(string text, string elSep, string compSep)
		{
			//const string pattern = @"~NM1\*41\*(?<provEnt>\d)\*?(?<provLastName>[^\*~]+)?\*?(?<provFirstName>[^\*~]+)?\*?(?<provMI>[^\*~]+)?\*\*\*46\*?(?<identCode>[^\*~]+)?\*?\*?\*?";
			const string pattern = @"~NM1\*41\*(?<submitEnt>\d)\*?(?<submitLast>[^\*~]+)?\*?(?<submitFirst>[^\*~]+)?\*?(?<submitMI>[^\*~]+)?\*\*\*46\*?(?<identCode>[^\*~]+)?\*?\*?\*?" +
									@"(~PER\*IC\*(?<name1>[^\*~]+)?\*(?<qual1_1>\w+)\*(?<num1_1>[^\*~]+)\*?(?<qual2_1>\w+)?\*?(?<num2_1>[^\*~]+)?\*?(?<qual3_1>\w+)?\*?(?<num3_1>[^\*~]+)?)" + 
									@"(~PER\*IC\*(?<name2>[^\*~]+)?\*(?<qual1_2>\w+)\*(?<num1_2>[^\*~]+)\*?(?<qual2_2>\w+)?\*?(?<num2_2>[^\*~]+)?\*?(?<qual3_2>\w+)?\*?(?<num3_2>[^\*~]+)?)?";

			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var matches = regex.Match(text);

			return matches;
		}


		public static Match GetBillingProviderInfo(string text, string elSep, string compSep)
		{
			const string pattern = @"(?:~PRV\*BI\*PXC\*(?<taxonomyCode>[^\*~]+))?" +
									@"~NM1\*85\*(?<provEnt>\d)\*?(?<provLastName>[^\*~]+)?\*?(?<provFirstName>[^\*~]+)?\*?(?<provMI>[^\*~]+)?\*?\*?(?<provSuffix>[^\*~]+)?\*?\w*\*?(?<provNPI>[^\*~]+)?" +
									@"(?:~N3\*(?<provAddr1>[^\*~]+)?(\*(?<provAddr2>[^\*~]+))?)?" +
									@"(?:~N4\*(?<provCity>[^\*~]+)?\*?(?<provST>[^\*~]+)?\*?(?<provZip>[^\*~]+)?)?" +
									@"(?<billRefs>(~REF\*\w+\*[^\*~]+)+)?" +
									@"(?<contactInfo>(~PER\*IC\*[^\*~]*\*\w+\*[^\*~]+\*?\w*\*?[^\*~]*\*?\w*\*?[^\*~]*)+)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(text);

			return match;
		}


		public static MatchCollection GetPers(string input, string elSep, string compSep)
		{
			const string pattern =
				@"~PER\*IC\*(?<name>[^\*~]+)?\*(?<qual1>\w+)\*(?<num1>[^\*~]+)\*?(?<qual2>\w+)?\*?(?<num2>[^\*~]+)?\*?(?<qual3>\w+)?\*?(?<num3>[^\*~]+)?";

			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var matches = regex.Matches(input);
			return matches;
		}


		public static Match GetClaimMedInfo(string input, string elSep, string compSep)
		{
			const string pattern =
				@"~CLM\*(?<clmPatContNum>[^\*~]+)?\*(?<clmChargeAmt>[^\*~]+)?\*\*\*((?<clmFacCode>\w+)?:\w*:(?<clmFreqCodeType>\w+)?)?\*" +
				@"(?<clmSigInd>\w+)?\*(?<clmAccCode>\w+)?\*(?<clmBenCert>\w+)?\*?(?<clmRelCode>\w+)?\*?(?<clmSigSrc>\w+)?\*?((?<clm111>\w+)?:?(?<clm112>\w+)?:?(?<clm113>\w+)?:?(?<clm114>\w+)?:?(?<clm115>\w+)?)?\*?" +
				@"(?<clmSpecProgCode>\w+)?\*?\*?\*?\*?\*?\*?\*?\*?(?<clmDelReasCode>\w+)?" +
				@"(?<clmDTP>(~DTP\*\w*\*\w*\*[^\*~]*)+)?" +
				@"(?<clmPWK>(~PWK\*\w*\*\w*\*?\*?\*?\w*\*?[^\*~]*)+)?" +
				@"(?:~CN1\*(?<cn1TypeCode>\w+)\*?(?<cn1MonAmt>[^\*~]+)?\*?(?<cn1AllowPct>[^\*~]+)?\*?(?<cn1RefIdent>[^\*~]+)?\*?(?<cn1DiscPct>[^\*~]+)?\*?(?<cn1VersionId>[^\*~]+)?)?" +
				@"(?:~AMT\*F5\*(?<amtPaid>[^\*~]+))?" +
				@"(?<clmRefs>(~REF\*\w*\*([^\*~]+)?)+)?" +
				@"(?<clmFileInfo>(~K3\*[^\*~]+)+)?" +
				@"(?:~NTE\*(?<nteRefCode>\w+)?\*(?<nteDesc>[^\*~]+)?)?" +
				@"(?:~CR1\*\w*\*(?<cr1Weight>[^\*~]+)?\*\*(?<cr1AmbCode>\w+)?\*\w*\*(?<cr1TransDist>[^\*~]+)?\*?\*?\*?\*?(?<cr1Desc1>[^\*~]+)?\*?(?<cr1Desc2>[^\*~]+)?)?" +
				@"(?:~CR2\*\*\*\*\*\*\*\*(?<cr2CondCode>\w+)?\*?\*?(?<cr2Desc1>[^\*~]+)?\*?(?<cr2Desc2>[^\*~]+)?)?" +
				@"(?<clmCRC>(~CRC\*\w*\*\w*\*\w*\*?\w*\*?\w*\*?\w*\*?\w*)+)?" +
				@"(?<hiHCDC>(~HI(?:\*A?B(?:K|F):[^\*~]+)+)+)?" +
				@"(?:~HI\*BP:(?<hiARP>[^\*~]+))?" +
				@"(?<hiCI>(~HI(?:\*BG:[^\*~]+)+)+)?" +
				@"(?<clmHCP>(~HCP\*(?<hcpPrMeth>\w+)?\*(?<hcpAllowAmt>[^\*~]+)?\*?(?<hcpSaveAmt>[^\*~]+)?\*?(?<hcpOrgIdent>[^\*~]+)?\*?(?<hcpPerDiem>[^\*~]+)?\*?(?<hcpAmbGrpCd>[^\*~]+)?\*?(?<hcpAmbGrpCdAmt>[^\*~]+)?\*?\*?\*?\*?\*?\*?(?<hcpRejRsnCd>\w+)?\*?(?<hcpPolComCd>\w+)?\*?(?<hcpExcCd>\w+)?))?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(input);

			return match;
		}


		public static MatchCollection GetDTP(string input, string elSep, string compSep)
		{
			const string pattern = @"~DTP\*(?<dtpQual>\w+)\*(?<dtpFormat>\w+)\*(?<dtpDate1>\d+)(?:[\-\s]+)?(?<dtpDate2>\d+)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var matches = regex.Matches(input);

			return matches;
		}


		public static Match GetPatientInfo(string input, string elSep, string compSep)
		{
			const string pattern =
				@"~PAT\*(?<patRel>\w+)\*?\*?\*?\*?(?:D8)?\*?(?<patDate>[^\*~]+)?\*?(?:01)?\*?(?<patWeight>[^\*~]+)?\*?(?<ynResponse>Y)?" +
				//@"~NM1\*QC\*1\*(?<patLastName>[^\*~]+)\*?(?<patFirstName>[^\*~]+)?\*?(?<patMI>[^\*~]+)?\*?\*?(?<patSuffix>[^\*~]+)?" +
				@"~NM1\*QC\*1\*(?<patLastName>[^\*~]+)\*?(?<patFirstName>[^\*~]+)?\*?(?<patMI>[^\*~]+)?\*?\*?(?<patSuffix>[^\*~]+)?[^~]*" +
				@"(?:~N3\*(?<patAddr1>[^\*~]+)?(\*(?<patAddr2>[^\*~]+))?)?" +
				@"(?:~N4\*(?<patCity>[^\*~]+)?\*?(?<patST>[^\*~]+)?\*?(?<patZip>[^\*~]+)?)?" +
				@"(?:~DMG\*D8\*(?<patDOB>[^\*~]+)?\*?(?<patSex>\w)?)?" +
				@"(?:~REF\*Y4\*(?<propCasClaimNum>[^\*~]+))?" +
				@"(?:~PER\*IC\*(?<perName>[^\*~]+)?\*(?<perQual1>\w+)\*(?<perNum1>[^\*~]+)\*?(?<perQual2>\w+)?\*?(?<perNum2>[^\*~]+)?\*?(?<perQual3>\w+)?\*?(?<perNum3>[^\*~]+)?)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", !string.IsNullOrEmpty(compSep) ? compSep : "~"));
			var match = regex.Match(input);

			return match;
		}


		public static Match GetPayerInfo(string input, string elSep, string compSep)
		{
			const string pattern = @"(?<!~OI\*.*?)" +
									@"~NM1\*PR\*(?<payEnt>\d)\*(?<payLastName>[^\*~]+)\*?\*?\*?\*?\*?(?<payIDQual>\w+)?\*?(?<payID>[^\*~]+)?" +
									@"(?:~N3\*(?<payAddr1>[^\*~]+)?(\*(?<payAddr2>[^\*~]+))?)?" +
									@"(?:~N4\*(?<payCity>[^\*~]+)?\*?(?<payST>[^\*~]+)?\*?(?<payZip>[^\*~]+)?)?" +
									@"(?<payRefs>(~REF\*(?:2U|EI|FY|NF)\*([^\*~]+)?){0,3})?" +
									@"(?<billRefs>(~REF\*(?:G2|LU)\*([^\*~]+)?){0,2})?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			return regex.Match(input);
		}


		public static Match GetPayToProviderInfo(string text, string elSep, string compSep)
		{
			const string pattern = @"~NM1\*87\*(?<payToEnt>\d)" +
									@"~N3\*(?<payToAddr1>[^\*~]+)(\*(?<payToAddr2>[^\*~]+))?" +
									@"~N4\*(?<payToCity>[^\*~]+)?\*?(?<payToST>[^\*~]+)?\*?(?<payToZip>[^\*~]+)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(text);

			return match;
		}


		public static MatchCollection GetRefs(string input, string elSep, string compSep)
		{
			const string pattern = @"~REF\*(?<refQual>\w+)\*(?<refIdent>[^\*~]+)\*?(?<reDesc>[^\*~]+)?\*?(?<refIdent2>[^\*~]+)?";

			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var matches = regex.Matches(input);

			return matches;
		}


		public static MatchCollection GetPWK(string input, string elSep, string compSep)
		{
			const string pattern =
				@"~PWK\*(?<pwkRepCode>\w+)?\*(?<pwkTransCode>\w+)?\*?\*?\*?(?<pwkQual>\w+)?\*?(?<pwkCode>[^\*~]+)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var matches = regex.Matches(input);

			return matches;
		}


		public static Match GetSubscriberInfo(string input, string elSep, string compSep)
		{
			const string pattern =
				@"^~SBR\*(?<payerResp>\w)\*?(?<subRelationship>[^\*~]+)?\*?(?<subPolicy>[^\*~]+)?\*?(?<subPlanName>[^\*~]+)?\*?(?<subInsuranceTypeCode>\w+)?\*?\w*\*?\*?\*?(?<claimIndicatorCode>[^\*~]+)?" +
				@"(?:~PAT\*?\*?\*?\*?\*?\w+\*?(?<patDeathDt>[^\*~]+)?\*?\w+\*?(?<patWeight>[^\*~]+)?\*?(?<patPregnant>[^\*~]+)?)?" +
				@"~NM1\*IL\*(?<subEnt>\d)\*(?<subLastName>[^\*~]+)\*?(?<subFirstName>[^\*~]+)?\*(?<subMI>[^\*~]+)?\*?\*?(?<subSuffix>[^\*~]+)?\*?(?<subIDQual>\w+)?\*?(?<subID>[^\*~]+)?" +
				@"(?:~N3\*(?<subAddr1>[^\*~]+)?(\*(?<subAddr2>[^\*~]+))?)?" +
				@"(?:~N4\*(?<subCity>[^\*~]+)?\*?(?<subST>[^\*~]+)?\*?(?<subZip>[^\*~]+)?)?" +
				@"(?:~DMG\*D8\*(?<subDOB>[^\*~]+)?\*?(?<subSex>[^\*~])?)?" +
				@"(?<subRefs>(~REF\*\w+\*[^\*~]+)+)?" +
				@"(?:~PER\*IC\*(?<perName>[^\*~]+)?\*(?<perQual1>\w+)\*(?<perNum1>[^\*~]+)\*?(?<perQual2>\w+)?\*?(?<perNum2>[^\*~]+)?\*?(?<perQual3>\w+)?\*?(?<perNum3>[^\*~]+)?)?";

			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			return regex.Match(input);
		}


		public static Match GetSubscriberPatientInfo(string input, string elSep, string compSep)
		{
			const string pattern =
				@"~PAT\*?\*?\*?\*?\*?(?<dtPerQual>\w+)?\*?(?<dtPer>[^\*~]+)?\*?\w*\*?(?<weight>\w+)?\*?(?<ynResp>\w+)?";

			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(input);

			return match;
		}


		public static MatchCollection GetFileInformation(string input, string elSep, string compSep)
		{
			const string pattern = @"~K3\*(?<fixFormInfo>[^\*~]+)?";

			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var matches = regex.Matches(input);

			return matches;
		}


		public static MatchCollection GetCRC(string input, string elSep, string compSep)
		{
			const string pattern =
				@"~CRC\*(?<crcCat>\w+)?\*(?<crcResp>\w+)?\*?(?<crcCond1>\w+)?\*?(?<crcCond2>\w+)?\*?(?<crcCond3>\w+)?\*?(?<crcCond4>\w+)?\*?(?<crcCond5>\w+)?";

			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var matches = regex.Matches(input);

			return matches;
		}


		public static MatchCollection GetDiagnosisCode(string input, string elSep, string compSep)
		{
			const string pattern = @"(?<qual>\w+):(?<code>[^\*~:]+)";

			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var matches = regex.Matches(input);

			return matches;
		}


		public static MatchCollection GetConditionCodes(string input, string elSep, string compSep)
		{
			const string pattern = @"(?<condCodes>~HI(?:\*BG:[^\*~:]+)+)";

			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var matches = regex.Matches(input);

			return matches;
		}


		public static MatchCollection GetReferringProviderInfo(string input, string elSep, string compSep)
		{
			const string pattern =
				@"~NM1\*(?<rpQual>P3|DN)\*?\w*\*?(?<rpLName>[^\*~]+)?\*?(?<rpFName>[^\*~]+)?\*?(?<rpMName>[^\*~]+)?\*?\*?(?<rpSuffix>[^\*~]+)?\*?\w*\*?(?<rpNPI>[^\*~]+)?" +
				@"(?:~PRV\*RF\*PXC\*(?<taxCode>[^\*~]+))?" +
				@"(?<refProvRefs>(~REF\*\w+\*[^\*~]+\*?\*?[^\*~]*)+)?";

			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var matches = regex.Matches(input);

			return matches;
		}


		public static Match GetRenderingProviderInfo(string text, string elSep, string compSep)
		{
			const string pattern =
				@"~NM1\*82\*(?<provEnt>[12])\*?(?<provLastName>[^\*~]+)?\*?(?<provFirstName>[^\*~]+)?\*?(?<provMI>[^\*~]+)?\*?\*?(?<provSuffix>[^\*~]+)?\*?\w*\*?(?<provNPI>[^\*~]+)?" +
				@"(?:~PRV\*PE\*PXC\*(?<taxonomyCode>[^\*~]+))?" +
				@"(?<rendRefs>(~REF\*\w+\*[^\*~]+\*?\*?[^\*~]*)+)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(text);

			return match;
		}


		public static Match GetServiceLocationInfo(string text, string elSep, string compSep)
		{
			const string pattern = @"~NM1\*77\*\w*\*?(?<servLastName>[^\*~]+)?\*?\*?\*?\*?\*?\w*\*?(?<servID>[^\*~]+)?" +
									@"(?:~N3\*(?<servAddr1>[^\*~]+)?(\*(?<servAddr2>[^\*~]+))?)?" +
									@"(?:~N4\*(?<servCity>[^\*~]+)?\*?(?<servST>[^\*~]+)?\*?(?<servZip>[^\*~]+)?)?" +
									@"(?<servRefs>(~REF\*\w+\*[^\*~]+\*?\*?[^\*~]*)+)?" +
									@"(?:~PER\*IC\*(?<perName>[^\*~]+)?\*(?<perQual1>\w+)\*(?<perNum1>[^\*~]+)\*?(?<perQual2>\w+)?\*?(?<perNum2>[^\*~]+)?)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(text);

			return match;
		}


		public static Match GetSupervisingProviderInfo(string text, string elSep, string compSep)
		{
			const string pattern =
				@"~NM1\*DQ\*\w*\*?(?<provLastName>[^\*~]+)?\*?(?<provFirstName>[^\*~]+)?\*?(?<provMI>[^\*~]+)?\*?\*?(?<provSuffix>[^\*~]+)?\*?\w*\*?(?<provNPI>[^\*~]+)?" +
				@"(?<supRefs>(~REF\*\w+\*[^\*~]+\*?\*?[^\*~]*)+)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(text);

			return match;
		}


		public static Match GetAmbulancePickupInfo(string input, string elSep, string compSep)
		{
			const string pattern = @"~NM1\*PW\*2" +
									@"~N3\*(?<ambAddr1>[^\*~]+)?(?:\*(?<ambAddr2>[^\*~]+))?" +
									@"~N4\*(?<ambCity>[^\*~]+)?\*?(?<ambST>\w+)?\*?(?<ambZip>[^\*~]+)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(input);

			return match;
		}


		public static Match GetAmbulanceDropOffInfo(string input, string elSep, string compSep)
		{
			const string pattern = @"~NM1\*45\*2(?:\*(?<dropOffLocation>[^\*~]+))?" +
									@"~N3\*(?<ambAddr1>[^\*~]+)?(?:\*(?<ambAddr2>[^\*~]+))?" +
									@"~N4\*(?<ambCity>[^\*~]+)?\*?(?<ambST>[^\*~]+)?\*?(?<ambZip>[^\*~]+)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(input);

			return match;
		}


		public static Match GetOtherSubscribers(string input, string elSep, string compSep)
		{
			const string pattern =
				@"~SBR\*(?<payerResp>\w+)\*(?<indRelCd>\w+)?\*?(?<subPolicy>[^\*~]+)?\*?(?<subPlanName>[^\*~]+)?\*?(?<subInsuranceTypeCode>\w+)?\*?(?:\*\*\*(?<claimIndicatorCode>[^\*~]+)?)?" +
				@"(?<adjustments>(~CAS\*(?<gCode>\w+)\*(?<r1>[^\*~]+)\*(?<m1>[^\*~]+)\*?(?<q1>[^\*~]+)?\*?(?<r2>[^\*~]+)?\*?(?<m2>[^\*~]+)?\*?(?<q2>[^\*~]+)?\*?(?<r3>[^\*~]+)?\*?(?<m3>[^\*~]+)?\*?(?<q3>[^\*~]+)?\*?(?<r4>[^\*~]+)?\*?(?<m4>[^\*~]+)?\*?(?<q4>[^\*~]+)?\*?(?<r5>[^\*~]+)?\*?(?<m5>[^\*~]+)?\*?(?<q5>[^\*~]+)?\*?(?<r6>[^\*~]+)?\*?(?<m6>[^\*~]+)?\*?(?<q6>[^\*~]+)?)+)?" +
				@"(?<amtSegs>(~AMT\*\w+\*[^\*~]+)+)?" +
				@"(?:~OI\*\*\*(?<ynResp>\w)\*(?<patSigSrcCd>\w+)?\*\*(?<relInfoCd>\w))?" +
				@"(?<outAdj>~MOA\*?(?<rate>[^\*~]+)?\*?(?<payAmt>[^\*~]+)?\*?(?<rem1>[^\*~]+)?\*?(?<rem2>[^\*~]+)?\*?(?<rem3>[^\*~]+)?\*?(?<rem4>[^\*~]+)?\*?(?<rem5>[^\*~]+)?\*?(?<endPayAmt>[^\*~]+)?\*?(?<nonPayAmt>[^\*~]+)?)?" +
				@"(?:~NM1\*IL\*(?<subEnt>\d)\*?(?<subLastName>[^\*~]+)\*?(?<subFirstName>[^\*~]+)?\*?(?<subMI>[^\*~]+)?\*?\*?(?<subSuffix>[^\*~]+)?\*?(?<subIDQual>\w+)?\*?(?<subID>[^\*~]+)?)?" +
				@"(?:~N3\*(?<subAddr1>[^\*~]+)?(?:\*(?<subAddr2>[^\*~]+))?)?" +
				@"(?:~N4\*(?<subCity>[^\*~]+)?\*?(?<subST>[^\*~]+)?\*?(?<subZip>[^\*~]+)?)?" +
				@"(?<othSubRefs>(~REF\*\w+\*[^\*~]+)+)?" +
				@"(?:~NM1\*PR\*\w*\*?(?<othPayLastName>[^\*~]+)\*?(?<othPayFirstName>[^\*~]+)?\*?(?<othPayMI>[^\*~]+)?\*?\*?(?<othPaySuffix>[^\*~]+)?\*?(?<othPayIDQual>\w+)?\*?(?<othPayID>[^\*~]+)?)?" +
				@"(?:~N3\*(?<othPayAddr1>[^\*~]+)?(\*(?<othPayAddr2>[^\*~]+))?)?" +
				@"(?:~N4\*(?<othPayCity>[^\*~]+)?\*(?<othPayST>\w+)?\*(?<othPayZip>[^\*~]+)?)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(input);

			return match;
		}


		public static MatchCollection GetCAS(string input, string elSep, string compSep)
		{
			const string pattern =
				@"~CAS\*(?<gCode>\w+)\*(?<r1>[^\*~]+)\*(?<m1>[^\*~]+)\*?(?<q1>[^\*~]+)?\*?(?<r2>[^\*~]+)?\*?(?<m2>[^\*~]+)?\*?(?<q2>[^\*~]+)?\*?(?<r3>[^\*~]+)?\*?(?<m3>[^\*~]+)?\*?(?<q3>[^\*~]+)?\*?(?<r4>[^\*~]+)?\*?(?<m4>[^\*~]+)?\*?(?<q4>[^\*~]+)?\*?(?<r5>[^\*~]+)?\*?(?<m5>[^\*~]+)?\*?(?<q5>[^\*~]+)?\*?(?<r6>[^\*~]+)?\*?(?<m6>[^\*~]+)?\*?(?<q6>[^\*~]+)?";

			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var matches = regex.Matches(input);

			return matches;
		}


		public static MatchCollection GetAMT(string input, string elSep, string compSep)
		{
			const string pattern = @"~AMT\*(?<amtQualCode>\w+)\*(?<monAmt>[^\*~]+)";

			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var matches = regex.Matches(input);

			return matches;
		}


		public static Match GetOtherPayer(string input, string elSep, string compSep)
		{
			const string pattern =
				@"~NM1\*PR\*\w*\*?(?<othPayLastName>[^\*~]+)\*?\*?\*?\*?\*?(?<othPayIDQual>\w+)?\*?(?<othPayID>[^\*~]+)?" +
				@"(?:~N3\*(?<othPayAddr1>[^\*~]+)?(\*(?<othPayAddr2>[^\*~]+))?)?" +
				@"(?:~N4\*(?<othPayCity>[^\*~]+)?\*?(?<othPayST>[^\*~]+)?\*?(?<othPayZip>[^\*~]+)?)?" +
				@"(?:~DTP\*573\*\w*\*(?<dtClmPd>[^\*~]+))?" +
				@"(?<othPayRefs>(~REF\*\w+\*[^\*~]+)+)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(input);

			return match;
		}


		public static Match GetMedServiceLineInfo(string input, string elSep, string compSep)
		{
			const string pattern = @"~LX\*?(?<lineNum>\d+)?" +
									@"(~SV1\*?(?:(?<prodQual>\w+)?:?(?<prodCode>[^\*~:]+)?:?(?<procMod1>\w+)?:?(?<procMod2>\w+)?:?(?<procMod3>\w+)?:?(?<procMod4>\w+)?:?(?<prodDesc>[^\*~]+)?)?" +
									@"\*?(?<lineChargeAmt>[^\*~]+)?\*?(?<unitCode>\w+)?\*?(?<unitCount>[^\*~]+)?\*?(?<placeSerCode>\w+)?" +
									@"\*(?<serviceTypeCode>\w+)?\*?(?:(?<dPtr1>\w+)?:?(?<dPtr2>\w+)?:?(?<dPtr3>\w+)?:?(?<dPtr4>\w+)?)?\*?\*?(?<emerInd>\w+)?\*?\*?(?<EPSDTInd>\w+)?\*?(?<famPlanInd>\w+)?\*?\*?\*?(?<coPayStatus>\w+)?)?" +
									@"(?:~SV5\*(?:HC:[^\*~:]+)\*?(?:DA)?\*?(?<lenMedNec>\d+)?\*?(?<dmeRentPrice>[^\*~]+)?\*?(?<dmePurPrice>[^\*~]+)?\*?(?<dmeRentFreq>\w+)?)?" +
									@"(?<linePWK>(~PWK\*\w*\*\w*\*?\*?\*?\w*\*?[^\*~]*)+)?" +
									@"(?:~CR1\*\w*\*(?<cr1Weight>[^\*~]+)?\*\*(?<cr1AmbCode>\w+)?\*\w*\*(?<cr1TransDist>[^\*~]+)?\*?\*?\*?\*?(?<cr1Desc1>[^\*~]+)?\*?(?<cr1Desc2>[^\*~]+)?)?" +
									@"(?:~CR3\*?(?<cr3Type>\w+)?\*?(?:MO)?\*(?<cr3Len>[^\*~]+)?)?" +
									@"(?<lineCRC>(~CRC\*\w*\*\w*\*\w*\*?\w*\*?\w*\*?\w*\*?\w*)+)?" +
									@"(?<lineDTP>(~DTP\*\w*\*\w*\*[^\*~]*)+)?" +
									@"(?:~QTY\*PT\*(?<ambPatCount>[^\*~]+))?" +
									@"(?:~QTY\*FL\*(?<obAddUnits>[^\*~]+))?" +
									@"(?<meaSegs>(~MEA\*\w+\*\w+\*[^\*~]+)+)?" +
									@"(?:~CN1\*(?<cn1TypeCode>\w+)\*?(?<cn1MonAmt>[^\*~]+)?\*?(?<cn1AllowPct>[^\*~]+)?\*?(?<cn1RefIdent>[^\*~]+)?\*?(?<cn1DiscPct>[^\*~]+)?\*?(?<cn1VersionId>[^\*~]+)?)?" +
									@"(?<lineRefs>(~REF\*\w+\*[^\*~]+\*?\*?[^\*~]?)+)?" +
									@"(?:~AMT\*T\*(?<amtTax>[^\*~]+))?" +
									@"(?:~AMT\*F4\*(?<amtPostage>[^\*~]+))?" +
									@"(?<lineFileInfo>(~K3\*[^\*~]+)+)?" +
									@"(?:~NTE\*(?<lineNoteRefCode>(?:ADD|DCP))?\*(?<lineNoteDesc>[^\*~]+)?)?" +
									@"(?:~NTE\*TPO\*(?<nte3NoteDesc>[^\*~]+)?)?" +
									@"(?:~PS1\*(?<ps1Ident>[^\*~]+)?\*(?<ps1Amt>[^\*~]+)?)?" +
									@"(?<lineHCP>(~HCP\*(?<hcpPrMeth>\w+)?\*(?<hcpAllowAmt>[^\*~]+)?\*?(?<hcpSaveAmt>[^\*~]+)?\*?(?<hcpOrgIdent>[^\*~]+)?\*?(?<hcpPerDiem>[^\*~]+)?\*?(?<hcpAmbGrpCd>[^\*~]+)?\*?(?<hcpAmbGrpCdAmt>[^\*~]+)?\*?\*?\*?\*?\*?\*?(?<hcpRejRsnCd>\w+)?\*?(?<hcpPolComCd>\w+)?\*?(?<hcpExcCd>\w+)?))?" +
									@"(?:~LIN\*\*N4\*(?<natDrugCode>[^\*~]+))?" +
									@"(?:~CTP\*\*\*\*(?<natDrugCount>[^\*~]+)\*(?<natDrugQual>\w+)(?:~REF\*(?<presNumQual>VY|XZ)?\*(?<presNum>[^\*~]+))?)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(input);

			return match;
		}


		public static MatchCollection GetMEA(string input, string elSep, string compSep)
		{
			const string pattern = @"~MEA\*(?<meaRefId>\w+)\*(?<meaQual>\w+)\*(?<meaVal>[^\*~]+)";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var matches = regex.Matches(input);

			return matches;
		}


		public static Match GetPurchasedServiceProvider(string input, string elSep, string compSep)
		{
			const string pattern = @"~NM1\*QB\*(?<purEnt>\d)\*?\*?\*?\*?\*?\*?\w*\*?(?<purID>[^\*~]+)?" +
									@"(?<purRefs>(~REF\*\w+\*[^\*~]+\*?\*?[^\*~]+)+)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(input);

			return match;
		}


		public static Match GetOtherPayerPrimaryIdentifier(string input, string elSep, string compSep)
		{
			const string pattern = @"(?<othPayQual>2U):(?<othPayNum>[^\*~]+)";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(input);

			return match;
		}


		public static Match GetOrderingProviderInfo(string text, string elSep, string compSep)
		{
			const string pattern =
				@"~NM1\*DK\*\w*\*(?<provLastName>[^\*~]+)\*?(?<provFirstName>[^\*~]+)?\*?(?<provMI>[^\*~]+)?\*?\*?(?<provSuffix>[^\*~]+)?\*?\w*\*?(?<provNPI>[^\*~]+)?" +
				@"(?:~N3\*(?<ordAddr1>[^\*~]+)?(\*(?<ordAddr2>[^\*~]+))?)?" +
				@"(?:~N4\*(?<ordCity>[^\*~]+)?\*?(?<ordST>[^\*~]+)?\*?(?<ordZip>[^\*~]+)?)?" +
				@"(?<ordRefs>(~REF\*\w+\*[^\*~]+\*?\*?[^\*~]*)+)?" +
				@"(?:~PER\*IC\*(?<perName>[^\*~]+)?\*(?<perQual1>\w+)\*(?<perNum1>[^\*~]+)\*?(?<perQual2>\w+)?\*?(?<perNum2>[^\*~]+)?\*?(?<perQual3>\w+)?\*?(?<perNum3>[^\*~]+)?)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(text);

			return match;
		}


		public static MatchCollection GetLineAdjudicationInfo(string text, string elSep, string compSep)
		{
			const string pattern =
				@"~SVD\*(?<othPayID>[^\*~]+)\*(?<linePdAmt>[^\*~]+)\*(?<prodQual>[^\*~:]*):(?<pCode>[^\*~:]*):?(?<pm1>[^\*~:]*)?:?(?<pm2>[^\*~:]*)?:?(?<pm3>[^\*~:]*)?:?(?<pm4>[^\*~:]*)?:?(?<pDesc>[^\*~:]*)?\*\*?(?<unitCount>[^\*~]+)\*?(?<bunLineNum>\w+)?" +
				@"(?<adjustments>(~CAS\*(?<gCode>\w+)\*(?<r1>[^\*~]+)\*(?<m1>[^\*~]+)\*?(?<q1>[^\*~]+)?\*?(?<r2>[^\*~]+)?\*?(?<m2>[^\*~]+)?\*?(?<q2>[^\*~]+)?\*?(?<r3>[^\*~]+)?\*?(?<m3>[^\*~]+)?\*?(?<q3>[^\*~]+)?\*?(?<r4>[^\*~]+)?\*?(?<m4>[^\*~]+)?\*?(?<q4>[^\*~]+)?\*?(?<r5>[^\*~]+)?\*?(?<m5>[^\*~]+)?\*?(?<q5>[^\*~]+)?\*?(?<r6>[^\*~]+)?\*?(?<m6>[^\*~]+)?\*?(?<q6>[^\*~]+)?)+)?" +
				@"(?:~DTP\*573\*\w*\*(?<adjPayDt>[^\*~]+))?" +
				@"(?:~AMT\*EAF\*(?<remLiab>[^\*~]+))?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var matches = regex.Matches(text);

			return matches;
		}


		public static Match GetLineSupportingDocumentation(string text, string elSep, string compSep)
		{
			const string pattern =
				@"~LQ\*(?<codeListQual>\w+)\*(?<formIdent>[^\*~]+)(?<lineFRMs>(~FRM\*[^\*~]+\*?\w*\*?[^\*~]*?\*?[^\*~]*\*?[^\*~]*\*?[^\*~]*)+)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(text);

			return match;
		}


		public static MatchCollection GetFRMs(string input, string elSep, string compSep)
		{
			const string pattern =
				@"~FRM\*(?<qNumLet>[^\*~]+)\*?(?<q1>\w+)?\*?(?<q2>[^\*~]+)?\*?(?<q3>[^\*~]+)?\*?(?<q4>[^\*~]+)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));

			var matches = regex.Matches(input);

			return matches;
		}


		public static Match GetClaimDentInfo(string input, string elSep, string compSep)
		{
			const string pattern =
				@"~CLM\*(?<clmPatContNum>[^\*~]+)?\*(?<clmChargeAmt>[^\*~]+)?\*\*\*((?<clmFacCode>\w+)?:\w*:(?<clmFreqCodeType>\w+)?)?\*(?<clmSigInd>\w+)?\*?(?<clmAccCode>\w+)?\*(?<clmBenCert>\w+)?\*(?<clmRelCode>\w+)?\*?\*?(?<clm111>\w+)?:?(?<clm112>\w+)?:?(?<clm113>\w+)?:?(?<clm114>\w+)?:?(?<clm115>\w+)?\*?(?<clmSpecProgCode>\w+)?\*?\*?\*?\*?\*?\*?\*?(?<clmPreBen>\w+)?\*?(?<clmDelReasCode>\w+)?" +
				@"(?<clmDTP>(~DTP\*\w*\*\w*\*[^\*~]*)+)?" +
				@"(?:~DN1\*(?<clmOrthQty1>[^\*~]+)?\*?(?<clmOrthQty2>[^\*~]+)?\*?\*?(?<clmOrthDesc>[^\*~]+)?)?" +
				@"(?<clmDN2>(~DN2\*[^\*~]+\*[^\*~]+(\*\*\*\*JP)?)+)?" +
				@"(?<clmPWK>(~PWK\*\w*\*\w*\*?\*?\*?\w*\*?[^\*~]*)+)?" +
				@"(?:~CN1\*(?<cn1TypeCode>\w+)\*?(?<cn1MonAmt>[^\*~]+)?\*?(?<cn1AllowPct>[^\*~]+)?\*?(?<cn1RefIdent>[^\*~]+)?\*?(?<cn1DiscPct>[^\*~]+)?\*?(?<cn1VersionId>[^\*~]+)?)?" +
				@"(?:~AMT\*F5\*(?<amtPaid>[^\*~]+))?" +
				@"(?<clmRefs>(~REF\*\w*\*([^\*~]+)?)+)?" +
				@"(?<clmFileInfo>(~K3\*[^\*~]+)+)?" +
				@"(?<clmNTE>(~NTE\*\w+\*[^\*~]+)+)?" +
				@"(?:~HI(?<hiCodes>(\*?\w+:[^\*~]+)+))?" +
				@"(?<clmHCP>(~HCP\*(?<hcpPrMeth>\w+)?\*(?<hcpAllowAmt>[^\*~]+)?\*?(?<hcpSaveAmt>[^\*~]+)?\*?(?<hcpOrgIdent>[^\*~]+)?\*?(?<hcpPerDiem>[^\*~]+)?\*?(?<hcpAmbGrpCd>[^\*~]+)?\*?\*?\*?\*?\*?\*?\*?(?<hcpRejRsnCd>\w+)?\*?(?<hcpPolComCd>\w+)?\*?(?<hcpExcCd>\w+)?))?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(input);

			return match;
		}


		public static MatchCollection GetNTEs(string input, string elSep, string compSep)
		{
			const string pattern = @"~NTE\*\w+\*(?<note>[^\*~]+)";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));

			var matches = regex.Matches(input);

			return matches;
		}


		public static MatchCollection GetDN2s(string input, string elSep, string compSep)
		{
			//now allowing tooth status to be anything. should be \w per spec, but this way we accept everything, and can validate from there
			const string pattern = @"~DN2\*(?<toothNum>[^\*~]+)\*(?<toothStatus>[^\*~]+)(\*\*\*\*JP)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));

			var matches = regex.Matches(input);

			return matches;
		}


		public static Match GetAssistantSurgeonInfo(string text, string elSep, string compSep)
		{
			const string pattern =
				@"~NM1\*DD\*(?<provEnt>\w+)?\*?(?<provLastName>[^\*~]+)?\*?(?<provFirstName>[^\*~]+)?\*?(?<provMI>[^\*~]+)?\*?\*?(?<provSuffix>[^\*~]+)?\*?\w*\*?(?<provNPI>[^\*~]+)?" +
				@"(?:~PRV\*AS\*PXC\*(?<taxonomyCode>[^\*~]+))?" +
				@"(?<provRefs>(~REF\*\w+\*[^\*~]+\*?\*?[^\*~]*)+)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(text);

			return match;
		}


		public static Match GetDentServiceLineInfo(string input, string elSep, string compSep)
		{
			const string pattern = @"~LX\*(?<lineNum>\d+)?" +
									@"~SV3\*(?:(?<prodQual>\w+)?:?(?<prodCode>[^\*~:]+)?:?(?<procMod1>\w+)?:?(?<procMod2>\w+)?:?(?<procMod3>\w+)?:?(?<procMod4>\w+)?:?(?<prodDesc>[^\*~]+)?)?" +
									@"\*(?<lineChargeAmt>[^\*~]+)?\*?(?<plSrvcCode>\w+)?" +
									@"\*?(?:(?<ocdc1>[^\*~:]+)?:?(?<ocdc2>[^\*~:]+)?:?(?<ocdc3>[^\*~:]+)?:?(?<ocdc4>[^\*~:]+)?:?(?<ocdc5>[^\*~]+)?)?" +
									@"\*?(?<inlayCode>\w+)?\*?(?<procCount>[^\*~]+)?\**" +
									@"\*?(?:(?<dPtr1>[^\*~:]+)?:?(?<dPtr2>[^\*~:]+)?:?(?<dPtr3>[^\*~:]+)?:?(?<dPtr4>[^\*~]+)?)?" +
									@"(?<lineToo>(~TOO\*JP\*[^\*~]+\*?[^\*~]*)+)?" +
									@"(?<lineDTP>(~DTP\*\w*\*\w*\*[^\*~]*)+)?" +
									@"(?:~CN1\*(?<cn1TypeCode>\w+)\*?(?<cn1MonAmt>[^\*~]+)?\*?(?<cn1AllowPct>[^\*~]+)?\*?(?<cn1RefIdent>[^\*~]+)?\*?(?<cn1DiscPct>[^\*~]+)?\*?(?<cn1VersionId>[^\*~]+)?)?" +
									@"(?<lineRefs>(~REF\*\w+\*[^\*~]+\*?\*?[^\*~]+)+)?" +
									@"(?:~AMT\*T\*(?<amtTax>[^\*~]+))?" +
									@"(?<lineFileInfo>(~K3\*[^\*~]+)+)?" +
									@"(?<lineHCP>(~HCP\*(?<hcpPrMeth>\w+)?\*(?<hcpAllowAmt>[^\*~]+)?\*?(?<hcpSaveAmt>[^\*~]+)?\*?(?<hcpOrgIdent>[^\*~]+)?\*?(?<hcpPerDiem>[^\*~]+)?\*?(?<hcpAmbGrpCd>[^\*~]+)?\*?(?<hcpAmbGrpCdAmt>[^\*~]+)?\*?\*?\*?\*?\*?\*?(?<hcpRejRsnCd>\w+)?\*?(?<hcpPolComCd>\w+)?\*?(?<hcpExcCd>\w+)?))?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));
			var match = regex.Match(input);

			return match;
		}


		public static MatchCollection GetTOOs(string input, string elSep, string compSep)
		{
			const string pattern =
				@"~TOO\*JP\*(?<code>[^\*~]+)\*?(?<sur1>[^\*~:]+)?:?(?<sur2>[^\*~:]+)?:?(?<sur3>[^\*~:]+)?:?(?<sur4>[^\*~:]+)?:?(?<sur5>[^\*~:]+)?";
			var regex = new Regex(pattern.Replace("\\*", "\\" + elSep).Replace("~", compSep));

			var matches = regex.Matches(input);

			return matches;
		}
	}
}
