using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
// using ApexWebServiceToolV2.ApexSandbox;

namespace ApiV3Library
{
    public class ApiV3
    {
        static HttpResponseMessage response;
        public string ServiceBaseURL { get; set; }

        public string Credentials
        {
            get { return $"{Key}:{Password}"; }
        }

        public string VendorSiteId { get; set; }
        static bool outputJsonToFile = false;
        private string jsonStringFile = string.Empty;
        public string Key { get; set; }
        public string Password { get; set; }

        public ApiV3(string key, string pwd, string vendorSiteId, string serviceEndpoint)
        {
            Key = key;
            Password = pwd;
            VendorSiteId = vendorSiteId;
            ServiceBaseURL = serviceEndpoint;
        }

        public class ApexClient : HttpClient
        {
            public ApexClient(string key, string pwd, string serviceUrl)
            {
                var cleanUrl = string.Empty;
                Regex urlPattern = new Regex(@"^(?<Prefix>(([^:/?#]+):)?)(?<Domain>(//([^/?#]*)))?([^?#]*)(\?([^#]*))?(#(.*))?");
                var matches = urlPattern.Matches(serviceUrl);
                if (matches.Count > 0)
                {
                    cleanUrl = $"{matches[0].Groups["Prefix"]}{matches[0].Groups["Domain"]}/api/V3/";
                }
                //var v3Url = $""
                var creds = $"{key}:{pwd}";
                var baseCreds = Encoding.ASCII.GetBytes(creds);
                var base3d64Creds = Convert.ToBase64String(baseCreds);
                BaseAddress = new Uri(cleanUrl);
                DefaultRequestHeaders.Add("Authorization", "Basic " + base3d64Creds);
                DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Timeout = System.Threading.Timeout.InfiniteTimeSpan;
            }
        }

        static string GetContentAsJsonString(string methodName = null)
        {
            if (response != null && response.Content != null)
            {
                string stringResult = response.Content.ReadAsStringAsync().Result;

                if (outputJsonToFile && !string.IsNullOrWhiteSpace(methodName))
                {
                    File.WriteAllText(string.Format("{0}_{1:yyyyMMddHHmmss}-JSON.txt", methodName, DateTime.Now), stringResult);
                }
                return stringResult;
            }

            return string.Empty;
        }

        public static string GetPayers(string key, string pwd, string vendorSiteId, string serviceUrl, string payerType)
        {
            string jsonResult = string.Empty;

            try
            {
                using (ApexClient apexClient = new ApexClient(key, pwd, serviceUrl))
                {
                    response = apexClient.PostAsync($"payers/get_list?vendorSiteId={vendorSiteId}&type={payerType}",
                            null)
                        .Result;

                    jsonResult = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        jsonResult = null;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return jsonResult;
        }

        public static string GetClaimStatusByDate(string key, string pwd, string vendorSiteId, string serviceUrl, DateTime startDate, DateTime endDate)
        {
            string jsonResult = string.Empty;

            try
            {
                using (ApexClient client = new ApexClient(key, pwd, serviceUrl))
                {
                    response = client
                        .PostAsync(
                            string.Format("claims/status/get_by_date?vendorSiteId={0}&startDate={1}&endDate={2}", vendorSiteId, startDate, endDate),
                            null).Result;

                    jsonResult = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        jsonResult = null;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return jsonResult;
        }


        public static string GetPayerResponseDocuments(string key, string pwd, string vendorSiteId, string serviceUrl, string[] docIds)
        {
            string jsonResult = string.Empty;

            if (docIds != null && docIds.Length > 0)
            {
                using (ApexClient client = new ApexClient(key, pwd, serviceUrl))
                {
                    var httpContentString = JsonSerialize(docIds);
                    response = client
                        .PostAsync($"claims/responses/get_by_doc_id?vendorSiteId={vendorSiteId}", httpContentString)
                        .Result;

                    jsonResult = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);
                }
            }


            return jsonResult;
        }

        //string jsonresult = string.empty;

        //public static string GetPayerResponseDocuments(string key, string pwd, string vendorSiteId, string serviceUrl,
        //    DateTime startDate, DateTime endDate)
        //{
        //    //string jsonResult = string.Empty;

        //    //try
        //    //{
        //    //    using (ApexClient client = new ApexClient(key, pwd, serviceUrl))
        //    //    {
        //    //        response = client
        //    //            .PostAsync(
        //    //                string.Format("claims/status/get_by_date?vendorSiteId={0}&startDate={1}&endDate={2}", vendorSiteId, startDate, endDate),
        //    //                null).Result;

        //    //        jsonResult = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);
        //    //        if (response.StatusCode == HttpStatusCode.OK)
        //    //        {
        //    //            jsonResult = null;

        //    //            string results = response.Content.ReadAsStringAsync().Result;
        //    //            List<WsHealthCareClaimStatus> claimStatuses =
        //    //                JsonConvert.DeserializeObject<List<WsHealthCareClaimStatus>>(results);

        //    //            List<string> docIds = new List<string>();

        //    //            claimStatuses.ForEach(x =>
        //    //            {
        //    //                if (!string.IsNullOrEmpty(x.RelatedDocumentId))
        //    //                {
        //    //                    docIds.Add(x.RelatedDocumentId);
        //    //                }
        //    //            });

        //    //            var httpContentString = JsonSerialize(docIds);
        //    //            response = client
        //    //                .PostAsync(
        //    //                    string.Format("claims/responses/get_by_doc_id?vendorSiteId={0}", vendorSiteId), httpContentString).Result;

        //    //            jsonResult = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);
        //    //            if (response.StatusCode == HttpStatusCode.OK)
        //    //            {
        //    //                var responses =
        //    //                    JsonConvert.DeserializeObject<WsPayerResponseDocuments>(jsonResult);
        //    //            }

        //    //        }
        //    //    }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }

        //    return jsonResult;
        //}

        public static Dictionary<string, string> SubmitClaims(string key, string pwd, string vendorSiteId, string serviceUrl,
            Dictionary<string, string> claimFileDict)
        {
            Dictionary<string, string> submitResults = new Dictionary<string, string>();

            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (var kvp in claimFileDict)
                {
                    if (IsValidJson(kvp.Value))
                    {
                        sb.Append(kvp.Value);
                    }

                    submitResults[kvp.Key] = string.Empty;
                }

                using (ApexClient apexClient = new ApexClient(key, pwd, serviceUrl))
                {
                    StringContent httpStringContent = null;

                    httpStringContent = JsonSerialize(sb.ToString());

                    response = apexClient.PostAsync($"claims/submit?vendorSiteId={vendorSiteId}", httpStringContent).Result;
                    var stringResults = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        JObject jObj = JsonConvert.DeserializeObject(stringResults) as JObject;
                        
                        Dictionary<string, object> claimResultDict = new Dictionary<string, object>();
                        foreach (JObject content in jObj["ClaimResults"])
                        {
                            foreach (JProperty prop in content.Properties())
                            {
                                claimResultDict[prop.Name] = prop.Value;
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return submitResults;
        }

        public static bool IsValidJson(string input)
        {
            bool isValid = false;
            input = input.Trim();

            if ((input.StartsWith("{") && input.EndsWith("}")) ||
                (input.StartsWith("[") && input.EndsWith("]")))
            {

                try
                {
                    var obj = JToken.Parse(input);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static StringContent JsonSerialize(object obj)
        {
            string jsonString = JsonConvert.SerializeObject(obj);
            StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            return httpContent;
        }
    }
}
