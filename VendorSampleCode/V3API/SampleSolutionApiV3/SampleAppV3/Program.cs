using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;

namespace SampleAppV3_2
{
    class Program
    {
        static HttpResponseMessage _response;
        static string _token;

        //private const string ServiceBaseURL = "http://localhost:49923/api/v3/";
        //private const string ServiceBaseURL = "http://10.45.120.59:58693/api/v3/";
        //private const string ServiceBaseURL = "https://EC2AMAZ-G004EIP/api/v3/";
        private const string ServiceBaseURL = "http://clayton2.services.apexedi-eng.com/api/v3/";
        //private const string EligServiceBaseURL = "http://clayton2.services.apexedi-eng.com/api/v3/";
        //private const string ServiceBaseURL = "http://clayton2.services.apexedi-eng.com/api/v3/";
        private const string EligServiceBaseURL = "http://localhost:58693/api/v3/";
        //private const string ServiceBaseURL = "https://kamika.OneTouchWebService/api/v3/";
        //private const string ServiceBaseURL = "http://localhost:58693/api/v3/";
        //private const string ServiceBaseURL = "http://localhost:49923/api/v3/";
        //private const string ServiceBaseURL = "http://localhost:49923/";
        //private const string ServiceBaseURL = "http://localhost:52846/api/v3/";
        //private const string ServiceBaseURL = "https://production.services.apexedi.com/api/v3/";
        //private const string ServiceBaseURL = "http://stage.services.apexedi-stage.com/api/v3/";
        //private const string ServiceBaseURL = "https://sandbox.services.apexedi.com/api/v3/";
        //private const string ServiceBaseURL = "https://jarik.services.apexedi-eng.com/api/v3/";

        //private const string ServiceBaseURL = "https://stage-web.apexedi.com/api/v3/";
        //                          vendor key                         vendor password
        //private static string creds = " 4YZLQVUAQWJRE1IDZNREEW3I" + ":" + "040KQ4OH5NCQSQKMPCBJ5QIW"; // 
        //private static string creds = "P5M1XIFDI0DIGSISAECLUGX1" + ":" + "5NENAJ11ZZ3YC4343MOEW23P"; // dental writer
        //private static string creds = "HV0GTPR3PU3DNPB0EGRI4J2P" + ":" + "OMTDBWBOQGCQCGEJZTAXU4JL"; // soft_age
        //private static string creds = "1JXAPOZGHALR4VBAFTJEKM5R" + ":" + "MG2PQ2WTOPP3JVSAW44UVO4O"; //liquidEHR
        //private static string creds = "4QRDCJMIGQTWUZURPGSSRXP3" + ":" + "NSTF424PXCHG10PMBQGBTPDK"; // test dev account
        //private static string creds = "QGO4TRR1NGZOOSFBW14WML1W" + ":" + "GHRPUCSIEQ0CCL4KZ2OE4G1W"; // Luminello
        //private static string creds = "NIT3EY1EWKKYXHBPHRWGPE4M" + ":" + "4YMYMLRODAIFIZ0LGC0NHHKZ"; // LiquidEHR Production
        //private static string creds = "G3JMO2UQJWFQZJHWOGWS4CYT" + ":" + "VA2SWXO2YXKF54JSNQVM2AQL"; // ODLink, temporary - ZZZ
        //private static string creds = "DA1HV3YZAP3VGOCB0CRCRBAV" + ":" + "3OY2UGSICRR2HBQDCPCW5UZY"; // winbuilt
        //private static string creds = "NIT3EY1EWKKYXHBPHRWGPE4M" + ":" + "4YMYMLRODAIFIZ0LGC0NHHKZ"; // winbuilt
        //private static string creds = "LIJ5H0DMTRAAWP2COS4MBB3N" + ":" + "20HE5TPVIMFF4OPP33JH12BS"; // BP8
        //private static string creds = "FG2IWZRXZYBFRMNUFCZ3MNVH" + ":" + "MTJD1RWTJ1141XKBNGPDSGGO"; // TOL
        //private static string creds = "QGO4TRR1NGZOOSFBW14WML1W" + ":" + "K5JG0GF4JE1WLYGXHCZC1POT";
        private static string creds = "QGO4TRR1NGZOOSFBW14WML1W" + ":" + "QDJU0N5NGXAWN5L2IAYVQTX5"; // Luminello
        //private static string creds = "QGO4TRR1NGZOOSFBW14WML1W" + ":" + "GFL2K0I3GODAQRHBG20DOQ2H"; //SoftAge_1329
        private static string eligCreds = "QGO4TRR1NGZOOSFBW14WML1W" + ":" + "K5JG0GF4JE1WLYGXHCZC1POT";
        //private static string creds = "440N2VBHIXB1JB0YWPY40XDF" + ":" + "KQMZYOA334X2WFY4X4ATDBJ1"; // ABO
        //private static string creds = "QGO4TRR1NGZOOSFBW14WML1W" + ":" + "K5JG0GF4JE1WLYGXHCZC1POT"; // A4B

        //private static string vendorSiteId = "SoftAge_1329";
        private static string vendorSiteId = "C6W"; // "AUJ";

        private static string eligVendorSiteId = "A4B";
        //private static string vendorSiteId = "ZZZ";
        //private static string vendorSiteId = "JOD_1329";
        //private static string vendorSiteId = "A9J";
        //private static string vendorSiteId = "AAZ";
        //private static string vendorSiteId = "WML";
        //private static string vendorSiteId = "WML";
        //private static string vendorSiteId = "C83";
        private static bool _outputJsonToFile = false;

        private static Guid _instancedGuid = Guid.Empty;
        private static string _instanceName = "DNX";
        private static string _instanceToken = string.Empty;

        //private static string jsonStringFile = "D:\\ClientFiles\\LiquidEHR\\request0-CDW-doesn't exist.txt";
        //private static string jsonStringFile = "D:\\ClientFiles\\LiquidEHR\\SandboxResponseTest-6.txt";
        //private static string jsonStringFile = "D:\\ClientFiles\\EnterInc\\M0329181804.A3G";
        //private static string jsonStringFile = "D:\\ClientFiles\\Luminello\\A3W.txt";
        //private static string jsonStringFile = "D:\\ClientFiles\\Luminello\\AUJ.txt";
        //        private static string jsonStringFile = "D:\\ClientFiles\\Luminello\\M1103181410.A9J";
        //private static string jsonStringFile = "D:\\ClientFiles\\ApexVendorTest\\SubmittedClaim-Test-2.txt";[dbo].[AcknowledgementAssignmentType_T]
        //private static string jsonStringFile = "D:\\ClientFiles\\AA0\\Claim001.json";
        // private static string jsonStringFile = @"D:\ClientFiles\NOE\M1300458928-VCI-32668.NOE";
        //private static string jsonStringFile = @"D:\ClientFiles\Luminello\SecondaryClaims-Y.A9J";
		//private static string jsonStringFile = @"D:\ClientFiles\ODLink\M20191023002.MAL";
		private static string jsonStringFile = @"C:\ClientFiles\Input2.txt";
        private static string jsonEligStringFile = @"C:\Source\CSGit1\claimstaker\Apex1\WebSite\ApexDevelopers\v3\SingleSubscriberSingleServiceType-Test.json";


        static void Main(string[] args)
        {
            //UseOneTouchSSOApi();
            //Console.WriteLine("About to call GetPayers");
            GetPayers("medical");
            //GetEligibilityPayers("medical");
            //GetTestPayers("medical");
            //GetPayers("dental");
            //SubmitClaims();
            //SubmitEligibilityRequests();
            //GetClaimStatusByDate(new DateTime(2018,04,01), DateTime.Today);
            //Thread.Sleep(60000);
            // GetPayResponseDocumentsWithIds(new List<string> { "AFTTWJM4KQNTI7OOIHZ5TDVBXH5UAENN76K7LUNJBKY6SL2FTS4SQ5", });
            GetPayResponseDocumentsWithIds(new List<string> { "AFHNJ7LVQWIW7MEYZW4AHYXXZAXJLCDP3B4RGHESAMLWCROYK7RXO5", });
//            GetPayerResponseDocuments(DateTime.Today.AddDays(-21), DateTime.Now);
            //GetPayerResponseDocuments(new DateTime(2022, 2, 22), new DateTime(2022, 2, 25));
            //GetPayerResponseDocuments(new DateTime(2018, 04, 01), DateTime.Now);
            // GetClaimStatusByDate(new DateTime(2018, 4, 3), DateTime.Today);
            // GetPayerResponseDocuments(new DateTime(2017, 3, 4), DateTime.Today);
            //Johnny:
            // GetPayerResponseDocuments(new DateTime(2017, 11, 8), DateTime.Today);
            Console.ReadLine();
        }

        private class ApexClient : HttpClient
        {
	        private string Creds { get; set; }
            private string Url { get; set; }

            public ApexClient(string vendorCreds = null, string vendorServiceUrl = null)
            {
	            Creds = vendorCreds ?? creds;
	            Url = vendorServiceUrl ?? ServiceBaseURL;
                //Console.WriteLine(ServicePointManager.SecurityProtocol.ToString());
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var bcreds = Encoding.ASCII.GetBytes(Creds);
                var base64Creds = Convert.ToBase64String(bcreds);
                BaseAddress = new Uri(Url);
                DefaultRequestHeaders.Add("Authorization", "Basic " + base64Creds);
                DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				Timeout = System.Threading.Timeout.InfiniteTimeSpan;
            }
        }
        static void UseOneTouchSSOApi()
        {
            try
            {
                using (ApexClient client = new ApexClient())
                {
                    if (_instancedGuid == Guid.Empty)
                        _instancedGuid = Guid.NewGuid();

                    var instanceId = _instancedGuid.ToString("B");
                    _response = client.PostAsync(
                        $"proxylogin/create_instance_token?vendorSiteId={eligVendorSiteId}&instanceId={instanceId}&instanceName={_instanceName}", null).Result;

                    var stringResult = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);

                    if(_response.StatusCode == HttpStatusCode.OK)
                    {
                        var obj = JObject.Parse(stringResult);
                        _instanceToken = (string) obj["token"];

                        //string _encodedToken = HttpUtility.UrlEncode(_instanceToken);
                        string _encodedToken = _instanceToken;

                        _response = client.PostAsync(string.Format(
                            "proxylogin/get_url?vendorSiteId={0}&instanceId={1}&token={2}", vendorSiteId,
                            _instancedGuid.ToString("B"), _encodedToken), null).Result;

                        if (_response.StatusCode == HttpStatusCode.OK)
                        {
                            stringResult = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);

                            obj = JObject.Parse(stringResult);
                            var url = (string) obj["url"];

                            if (string.IsNullOrWhiteSpace(url) == false)
                            {
                                Process.Start(url);
                            }

                            _response = client.PostAsync(string.Format(
                                "proxylogin/delete_instance_token?vendorSiteId={0}&instanceId={1}", vendorSiteId,
                                _instancedGuid.ToString("B")), null).Result;
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        static void GetPayers(string payerType)
        {
	        try
	        {
		        var urlString = string.Format("payers/get_list?vendorSiteId={0}&type={1}", eligVendorSiteId, payerType);
		        Console.WriteLine($"{urlString}");
		        //Console.ReadLine();
		        using (ApexClient client = new ApexClient())
		        {
			        _response = client
				        //.PostAsync(string.Format("payers/get_list?vendorSiteId={0}&type={1}", vendorSiteId, payerType), null).Result;
				        .PostAsync(urlString, null).Result;
		        }

		        var stringResult = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);
		        Console.WriteLine(stringResult);
		        if (_response.StatusCode == HttpStatusCode.OK)
		        {
			        List<Payer> payerList = JsonConvert.DeserializeObject<List<Payer>>(stringResult).Where(payer => payer.OffersEligibility).ToList<Payer>();
		        }

	        }
	        catch (Exception e)
	        {
		        Console.WriteLine(e);
	        }
        }

        static void GetEligibilityPayers(string payerType)
        {
	        try
	        {
		        var urlString = string.Format("payers/get_list_of_eligibility?vendorSiteId={0}&type={1}", eligVendorSiteId, payerType);
		        Console.WriteLine($"{urlString}");
		        //Console.ReadLine();
		        using (ApexClient client = new ApexClient(eligCreds, EligServiceBaseURL))
		        {
			        _response = client
				        //.PostAsync(string.Format("payers/get_list?vendorSiteId={0}&type={1}", vendorSiteId, payerType), null).Result;
				        .PostAsync(urlString, null).Result;
		        }

		        var stringResult = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);
		        Console.WriteLine(stringResult);
		        if (_response.StatusCode == HttpStatusCode.OK)
		        {
			        List<Payer> payerList = JsonConvert.DeserializeObject<List<Payer>>(stringResult).Where(payer => payer.OffersEligibility).ToList<Payer>();
		        }

	        }
	        catch (Exception e)
	        {
		        Console.WriteLine(e);
	        }
        }

        static void GetTestPayers(string payerType)
        {
	        try
	        {
		        var urlString = string.Format("payers/get_list_of_test?vendorSiteId={0}&type={1}", eligVendorSiteId, payerType);
		        Console.WriteLine($"{urlString}");
		        //Console.ReadLine();
		        using (ApexClient client = new ApexClient(eligCreds, EligServiceBaseURL))
		        {
			        _response = client
				        //.PostAsync(string.Format("payers/get_list?vendorSiteId={0}&type={1}", vendorSiteId, payerType), null).Result;
				        .PostAsync(urlString, null).Result;
		        }

		        var stringResult = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);
		        Console.WriteLine(stringResult);
		        if (_response.StatusCode == HttpStatusCode.OK)
		        {
			        List<Payer> payerList = JsonConvert.DeserializeObject<List<Payer>>(stringResult).Where(payer => payer.OffersEligibility).ToList<Payer>();
		        }

	        }
	        catch (Exception e)
	        {
		        Console.WriteLine(e);
	        }
        }


        static void GetClaimStatusByDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (ApexClient client = new ApexClient())
                {
                    _response = client
                        .PostAsync(
                            string.Format("claims/status/get_by_date?vendorSiteId={0}&startDate={1}&endDate={2}", vendorSiteId, startDate, endDate),
                            null).Result;
                }

                var stringResult = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);
                if (_response.StatusCode == HttpStatusCode.OK)
                {
                    List<WsHealthCareClaimStatus> claimStatuses =
                        JsonConvert.DeserializeObject<List<WsHealthCareClaimStatus>>(stringResult);

                    List<WsHealthCareClaimStatus> remittances =
                        claimStatuses.FindAll(x => x.RelatedDocumentType == WsDocumentType.RemittanceAdvice).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void GetPayResponseDocumentsWithIds(List<string> docIds)
		{
			using (ApexClient client = new ApexClient())
			{
				StringBuilder docSb = new StringBuilder();
				docSb.Append("[");
				docIds.ForEach(s => { docSb.Append($"\"{s}\","); });
				docSb = docSb.Replace(',', ']', docSb.Length - 1, 1);
				var httpContentString = JsonSerialize(docIds);

				_response = client
					.PostAsync(
						string.Format("claims/responses/get_by_doc_id?vendorSiteId={0}", vendorSiteId),
						httpContentString).Result;

				var stringResult = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);
				if (_response.StatusCode == HttpStatusCode.OK)
				{
					var responses =
						JsonConvert.DeserializeObject<WsPayerResponseDocuments>(stringResult);
				}
			}
        }

        static void GetPayerResponseDocuments(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (ApexClient client = new ApexClient())
                {
                    _response = client
                        .PostAsync(
                            string.Format("claims/status/get_by_date?vendorSiteId={0}&startDate={1}&endDate={2}", vendorSiteId, startDate, endDate), null)
                        .Result;

                    var stringResult = GetContentAsJsonString();
                    if (_response.StatusCode == HttpStatusCode.OK)
                    {
                        string results = _response.Content.ReadAsStringAsync().Result;
                        List<WsHealthCareClaimStatus> claimStatuses =
                            JsonConvert.DeserializeObject<List<WsHealthCareClaimStatus>>(results);

                        List<string> docIds = new List<string>();

                        claimStatuses.ForEach(x =>
                        {
                            if (!string.IsNullOrEmpty(x.RelatedDocumentId))
                            {
                                docIds.Add(x.RelatedDocumentId);
                            }
                        });

                        StringBuilder docSb = new StringBuilder();
                        docSb.Append("[");
                        docIds.ForEach(s => { docSb.Append($"\"{s}\","); });
                        docSb = docSb.Replace(',', ']', docSb.Length - 1, 1);
                        var httpContentString = JsonSerialize(docIds);
                        _response = client
                            .PostAsync(
                                string.Format("claims/responses/get_by_doc_id?vendorSiteId={0}", vendorSiteId), httpContentString).Result;

                        stringResult = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);
                        if (_response.StatusCode == HttpStatusCode.OK)
                        {
                            var responses =
                                JsonConvert.DeserializeObject<WsPayerResponseDocuments>(stringResult);
                        }

                        Console.WriteLine(stringResult);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void SubmitEligibilityRequests()
        {
	        try
	        {
		        using (ApexClient client = new ApexClient(eligCreds, EligServiceBaseURL))
		        {
			        StringContent httpStringContent = null;
			        //var testFiles = Directory.GetFiles(@"C:\Source\CSGit1\claimstaker\Apex1\WebSite\ApexDevelopers\v3_eligibility\All\");
                    List<long> requestIdList = new List<long>();

                    //foreach (var testFile in testFiles)
                    {
	                    //jsonEligStringFile = testFile;
		                    //$@"C:\Source\CSGit1\claimstaker\Apex1\WebSite\ApexDevelopers\v3_eligibility\{testFile}";

	                    if (File.Exists(jsonEligStringFile))
	                    {
		                    // JsonSerialize is a helper method that is called to convert the claim form 
		                    // structure into a serialized JSON string

		                    var jsonString = File.ReadAllText(jsonEligStringFile);
		                    httpStringContent = JsonSerializeFromJsonString(jsonString);
		                
		                    _response = client.PostAsync($"eligibility/submit?vendorSiteId={eligVendorSiteId}", httpStringContent)
			                    .Result;
		                    
		                    var stringResult = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);
		                    JObject jObject = JObject.Parse(stringResult);
		                    long requestId = 0L;

		                    if (_response.StatusCode == HttpStatusCode.OK)
		                    {
			                    requestId = (long)(jObject["RequestId"] ?? 0);
			                    var responses = JsonConvert.DeserializeObject(stringResult);
			                    Console.WriteLine($"Results for Submit Request ID:{requestId}\r\n\r\n{stringResult}\r\n\r\n");
			                    requestIdList.Add(requestId);
		                    }
		                    else
		                    {
			                    Console.WriteLine($"Error Results for submission: {stringResult}");
		                    }
	                    }

                    }

                    GetEligibilityRequests(requestIdList);

                }
            }
	        catch (Exception ex)
	        {
		        Console.WriteLine(ex);
		        throw;
	        }
        }

        static void GetEligibilityRequests(List<long> requestIds)
        {
	        try
	        {
		        using (ApexClient client = new ApexClient(eligCreds, EligServiceBaseURL))
		        {
                    Dictionary<long, string> responseDict = new Dictionary<long, string>();
                    requestIds.ForEach(l =>
                    {
	                    _response = client.PostAsync(
		                    $"eligibility/get_responses?vendorSiteId={eligVendorSiteId}&requestId={l}", null).Result;

	                    var stringResult = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);
	                    responseDict[l] = stringResult;
	                    Console.WriteLine($"Results for Response Request for Request ID{l}\r\n\r\n{stringResult}\r\n\r\n");

	                    if (_response.StatusCode == HttpStatusCode.OK)
	                    {
		                    var responses = JsonConvert.DeserializeObject(stringResult);
	                    }

                    });


		        }

            }
            catch (Exception ex)
	        {
		        Console.WriteLine(ex);
		        throw;
	        }
        }

        static void SubmitClaims()
        {
            MedicalClaimsJson claims = GenerateMedicalClaims();
            //List<MedicalClaimJson> medicalClaimJsons = new List<MedicalClaimJson>();
            //claims.Claims = medicalClaimJsons.ToArray();

            try
            {
                using (ApexClient client = new ApexClient())
                {
                    // JsonSerialize is a helper method that is called to convert the claim form 
                    // structure into a serialized JSON string
	                StringContent httpStringContent = null;

                    if (File.Exists(jsonStringFile))
                    {
                            var jsonString = File.ReadAllText(jsonStringFile);
                        httpStringContent = JsonSerializeFromJsonString(jsonString);
                    }
                    else
                    {
		                httpStringContent = JsonSerialize(claims);
	                }

	                _response = client.PostAsync(string.Format("claims/submit?vendorSiteId={0}", vendorSiteId), httpStringContent).Result;
                    //_response = client.PostAsJsonAsync(string.Format("claims/submit?vendorSiteId={0}", vendorSiteId), claims).Result;

                    var stringResults = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);
                    if (_response.StatusCode == HttpStatusCode.OK)
                    {
                        var results =
                            JsonConvert.DeserializeObject<ClaimSubmitResult>(stringResults);

                        JObject jObj = JsonConvert.DeserializeObject(stringResults) as JObject;

                        Dictionary<string, object> claimResultDict = new Dictionary<string, object>();
                        foreach (JObject content in jObj["ClaimResults"])
                        {
                            foreach (JProperty prop in content.Properties())
                            {
                                claimResultDict[prop.Name] = prop.Value;
                            }

                            if (claimResultDict.ContainsKey("VendorClaimId"))
                                Console.WriteLine("VendorClaimId: {0}", ((JValue)claimResultDict["VendorClaimId"]).Value);
                            if (claimResultDict.ContainsKey("Status"))
                                Console.WriteLine("Status: {0}", ((JValue)claimResultDict["Status"]).Value);

                            object errors = null;
                            if (claimResultDict.TryGetValue("Errors", out errors))
                            {
                                var array = errors as JArray;
                                if (array != null)
                                {
                                    int errorCount = 0;
                                    foreach (JObject errorContent in array)
                                    {
                                        Console.WriteLine("Error {0}:", ++errorCount);
                                        var errorDict = errorContent.ToObject<Dictionary<string, object>>();
                                        foreach (KeyValuePair<string, object> kvp in errorDict)
                                        {
                                            Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                                        }
                                        Console.WriteLine();
                                    }
                                }
                            }
                        }
                    }
                    else if (_response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var results =
                            JsonConvert.DeserializeObject<ClaimSubmitResult>(stringResults);

                        JObject jObj = JsonConvert.DeserializeObject(stringResults) as JObject;

                        var jsonMessage = GetJsonMessage(jObj);
                        Console.WriteLine(jsonMessage);
                        Console.WriteLine(stringResults);

                        Dictionary<string, string> modelErrorDict = new Dictionary<string, string>();
                        var modelErrors = jObj["ModelState"];
                        if (modelErrors != null)
                        {
                            foreach (JProperty property in modelErrors)
                            {
                                modelErrorDict[property.Name] = property.Value.Count() > 1
                                    ? ((JValue)property.Value[0]).Value.ToString()
                                    : string.Empty;
                            }

                            foreach (var kvp in modelErrorDict)
                            {
                                Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                            }
                        }

                        var errors = (JArray)jObj["Errors"];
                        var sb = new StringBuilder();
                        foreach (var error in errors)
                        {
	                        JArray errMsgs = (JArray) error["Value"];
	                        List<string> errorTextList = errMsgs.Select(e => (string) e).ToList();
                            errorTextList.ForEach(x => sb.AppendLine(x));
                        }

                        if (sb.Length > 0)
                        {
	                        Console.WriteLine(sb.ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static string GetJsonMessage(JObject jObj)
        {
            var jsonMessage = string.Empty;

            if ((JValue)jObj["Message"] != null)
            {
                if (((JValue)jObj["Message"]).Value != null)
                {
                    jsonMessage = ((JValue)jObj["Message"]).Value.ToString();
                }
            }

            return jsonMessage;
        }

        /// <summary>
        /// This method is used to prerare the claim form structure into a serialized JSON string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        static StringContent JsonSerialize(object obj)
        {
            string jsonString = JsonConvert.SerializeObject(obj);
            StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            return httpContent;
        }

	    static StringContent JsonSerializeFromJsonString(string jsonContent)
	    {
		    StringContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

		    return httpContent;
	    }

        static string GetContentAsJsonString(string methodName = null)
        {
            if (_response != null && _response.Content != null)
            {
                string stringResult = _response.Content.ReadAsStringAsync().Result;

                if (_outputJsonToFile && !string.IsNullOrWhiteSpace(methodName))
                {
                    File.WriteAllText(string.Format("{0}_{1:yyyyMMddHHmmss}-JSON.txt", methodName, DateTime.Now), stringResult);
                }
                return stringResult;
            }

            return string.Empty;
        }

        static MedicalClaimJson SetPayerInfo(MedicalClaimJson claim)
        {

            claim.F00_PayerName = "BLUE SHIELD OF SOUTH DAKOTA";
            claim.F00_PayerAddress1 = "PO BOX 5023";
            claim.F00_PayerAddress2 = null;
            claim.F00_PayerCity = "SIOUX FALLS";
            claim.F00_PayerState = "SD";
            claim.F00_PayerZip = "57117";
            return claim;

        }

        static MedicalClaimJson SetPatientInfo(MedicalClaimJson claim)
        {
            claim.F02_PatientNameFirst = "DAVID";
            claim.F02_PatientNameMiddle = null;
            claim.F02_PatientNameLast = "DINGER";
            claim.F02_PatientSuffix = null;
            claim.F03_PatientSex = "M";
            claim.F05_PatientAddress1 = "10545 404TH AVE";
            claim.F05_PatientAddress2 = null;
            claim.F05_PatientCity = "HECLA";
            claim.F05_PatientState = "SD";
            claim.F05_PatientZip = "57446";
            //claim.F05_PatientPhone = "6059942218";
            claim.F06_PatientRelationshipToInsured = "Self";
            // claim.F03_PatientDob = "02/20/1951";
            claim.F03_PatientDob = "1951-02-20";
            claim.F12_PatientAuthorization = "Yes";
            claim.F12_PatientAuthorizationDate = "2016-09-20"; // "09/20/2016";
            claim.X12_RenderingNPI = "0123456789";
            return claim;
        }

        static MedicalClaimJson SetInsuredInfo(MedicalClaimJson claim)
        {
            claim.F01A_InsuredId = "205AD1598";
            claim.F04_InsuredNameFirst = "DAVID";
            claim.F04_InsuredNameMiddle = null;
            claim.F04_InsuredNameLast = "DINGER";
            claim.F04_InsuredSuffix = null;
            claim.F07_InsuredAddress1 = "10545 404TH AVE";
            claim.F07_InsuredAddress2 = null;
            claim.F07_InsuredCity = "HECLA";
            claim.F07_InsuredState = "SD";
            claim.F07_InsuredZip = "57446";
            //claim.F07_InsuredPhone = "6059942218";
            // claim.F11A_InsuredDob = "02/20/1951";
            claim.F11A_InsuredDob = "1951-02-20";
            claim.F11A_InsuredSex = "M";
            claim.F13_InsuredAuthorization = "Y";
            claim.F11_InsuredsPolicyGroupOrFecaNumber = "87847";
            return claim;
        }

        static MedicalClaimJson SetOtherInsuredInfo(MedicalClaimJson claim)
        {
            claim.F09_OtherInsuredNameFirst = "DAVID";
            claim.F09_OtherInsuredNameMiddle = null;
            claim.F09_OtherInsuredNameLast = "DINGER";
            claim.F09_OtherInsuredSuffix = null;
            claim.F09A_OtherInsuredGroupNum = null;
            claim.F09D_OtherPlanName = null;

            return claim;
        }

        static MedicalClaimJson SetRenderingProviderInfo(MedicalClaimJson claim)
        {
            //claim.F17_ReferringProviderOrOtherSource_NameLast = 			
            //claim.F17_ReferringProviderOrOtherSource_NameFirst = 			
            //claim.F17_ReferringProviderOrOtherSource_NameMiddle = 			
            //claim.F17_ReferringProviderOrOtherSource_EntityIdentifier = 	
            //claim.F17A_ReferringPhysicianIDNumber = 						
            //claim.F17A_ReferringPhysicianIDQualifier = 					
            claim.F17B_ReferringProviderNpi = "1790789543";
            //claim.F17B_SupervisingPhysicianNpi = 	

            return claim;
        }

        static MedicalClaimJson SetBillingProviderInfo(MedicalClaimJson claim)
        {
            claim.F33_BillingProviderNameLast = "RICH";
            claim.F33_BillingProviderNameFirst = "REBECCA";
            claim.F33_BillingProviderNameMiddle = null;
            claim.F33_BillingProviderSuffix = "AU.D.";
            claim.F33_BillingProviderAddress1 = "2220 6TH AVE SE #1";

            claim.F33_BillingProviderCity = "ABERDEEN";
            claim.F33_BillingProviderState = "SD";
            claim.F33_BillingProviderZip = "57401";
            claim.F33_BillingProviderPhoneNumber = "6059942218";
            claim.F33A_BillingProviderNpi = "1174566830";
            claim.F33B_BillingProviderTaxonomyCode = null;
            claim.F33B_BillingProviderEmployersIdentificationNumber = null;
            return claim;
        }

        static MedicalClaimJson SetFacilityInfo(MedicalClaimJson claim)
        {
            claim.F27_AcceptAssignment = "Assigned";

            claim.F32_FacilityName = "ABERDEEN HEARING CLINIC";
            claim.F32_FacilityAddress1 = "2220 6TH AVE SE #1";
            claim.F32_FacilityAddress2 = null;
            claim.F32_FacilityCity = "ABERDEEN";
            claim.F32_FacilityState = "SD";
            claim.F32_FacilityZip = "57401";
            claim.F32A_FacilityNpi = "1013018183";
            claim.F32B_FacilityIdStateLicenseNumber = null;
            claim.F32B_FacilityIdProviderCommercialLicenseNumber = null;
            claim.F32B_FacilityIdLocationNumber = null;
            return claim;
        }


        static MedicalClaimJson SetMiscInfo(MedicalClaimJson claim)
        {
            claim.F01_ClaimType = "Group";
            claim.Apex_PayerId = "APX10003";
            claim.Apex_VendorClaimId = DateTime.Now.Ticks.ToString();

            return claim;
        }

        static MedicalClaimJson SetDiagCodes(MedicalClaimJson claim)
        {
            string[] codes = new[] { "H903", "A0225" };
            //string[] codes = new [] { "H903", "A0225" };
            claim.F21_IcdIndicator = "10";
            claim.F21_DiagnosisCodes = codes;
            return claim;
        }


        static F24ClaimLines SetServiceLine()
        {

            var result = new F24ClaimLines();
            result.F24A_DateOfServiceFrom = "2018-07-06"; //"11/12/2016";
            result.F24A_DateOfServiceTo = "2018-07-06"; //"11/12/2016";
            result.F24B_PlaceOfServiceCode = "11";

            result.F24D_HcpcsProcedureCode = "0368T";
            result.F24D_Modifiers = new[] {"AF"};

            result.F24E_DiagnosisPointers = new[] { "A" };
            result.F24F_Charges = (decimal?) 50.00;
            result.F24G_DaysOrUnits = 1;
            result.F24J_RenderingNpi = "0123456789";
            // result.F24H_EarlyPeriodicScreeningDiagnosisAndTreatment = false;
            // result.F24H_FamilyPlannning = false;
            // result.F24J_Shaded_RendProviderTaxonomyCode = null;
            // result.F24J_Shaded_RendProviderStateLicenseNumber = null;


            return result;
        }


        static MedicalClaimsJson GenerateMedicalClaims()
        {
            MedicalClaimsJson claimforms = new MedicalClaimsJson();

            MedicalClaimJson claim = new MedicalClaimJson();

            SetPayerInfo(claim);
            SetPatientInfo(claim);
            SetInsuredInfo(claim);
            SetOtherInsuredInfo(claim);
            SetFacilityInfo(claim);
            SetBillingProviderInfo(claim);
            SetMiscInfo(claim);
            SetDiagCodes(claim);

            List<F24ClaimLines> claimLines = new List<F24ClaimLines>();

            F24ClaimLines claimline = SetServiceLine();

            //F24ClaimLines2 claimline = new F24ClaimLines2();

            claimLines.Add(claimline);

            claim.F24_ClaimLines = claimLines.ToArray();

            claimforms.Claims = new[] { claim };

            claimforms.DocumentType = "MedicalClaim";

            string postBody = JsonConvert.SerializeObject(claim);

            string postBody2 = JsonConvert.SerializeObject(claimforms);


            return claimforms;
        }

    }
}
