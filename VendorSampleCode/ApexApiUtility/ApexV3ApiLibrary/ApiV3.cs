using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApexV3ApiLibrary
{
    public class ApiV3
    {
        private HttpResponseMessage response;
        private static string ServiceBaseURL;
        private static string Credentials;
        private static string VendorSiteId;
        private bool OutputJsonToFile = false;
        private string jsonStringFile = string.Empty;
        private string Key { get; set; }
        private string Password { get; set; }

        private class ApexClient : HttpClient
        {
            public ApexClient()
            {
                var baseCreds = Encoding.ASCII.GetBytes(Credentials);
                var base3d64Creds = Convert.ToBase64String(baseCreds);
                BaseAddress = new Uri(ServiceBaseURL);
                DefaultRequestHeaders.Add("Authorization", "Basic " + base3d64Creds);
                DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Timeout = System.Threading.Timeout.InfiniteTimeSpan;
            }
        }

        public ApiV3()
        {
        }

        private string GetContentAsJsonString(string methodName = null)
        {
            if (response != null && response.Content != null)
            {
                string stringResult = response.Content.ReadAsStringAsync().Result;

                if (OutputJsonToFile && !string.IsNullOrWhiteSpace(methodName))
                {
                    File.WriteAllText(string.Format("{0}_{1:yyyyMMddHHmmss}-JSON.txt", methodName, DateTime.Now), stringResult);
                }
                return stringResult;
            }

            return string.Empty;
        }

        public string GetPayers(string payerType)
        {
            string jsonResult = string.Empty;

            try
            {
                using (ApexClient client = new ApexClient())
                {
                    response = client.PostAsync($"payers/get_list?vendorSiteId={VendorSiteId}&type={payerType}", null)
                        .Result;
                }

                jsonResult = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    jsonResult = null;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return jsonResult;
        }
    }
}
