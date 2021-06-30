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


namespace MadaketTool
{
    class Program
    {
        static HttpResponseMessage _response;
        static string _token;

        private static string mcreds = "apexedi" + ":" + "Apex1edi";

        private static bool _outputJsonToFile = false;

        private static Guid _instancedGuid = Guid.Empty;
        private static string _instanceName = "LUMINELLO2";
        private static string _instanceToken = string.Empty;

        private static string _mkKey = "apexedi";
        private static string _mkToken = "Apex1edi";

        private const string MadaketURL = "https://test.madakethealth.com/services/api/v1.1/";

        static void Main(string[] args)
        {
            GetMedicalGroupEnrollmentStatus(new DateTime(2018, 08, 01), DateTime.Today);
        }

        private class MadaketClient : HttpClient
        {
            public MadaketClient()
            {
                var bcreds = Encoding.ASCII.GetBytes(mcreds);
                var base64Creds = Convert.ToBase64String(bcreds);
                BaseAddress = new Uri(MadaketURL);
                DefaultRequestHeaders.Add("Authorization", "Basic " + base64Creds);
                DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        private static void GetMedicalGroupEnrollmentStatus(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (MadaketClient client = new MadaketClient())
                {
                    var urlString = string.Format("medical-group-enrollment-status/from/{0}/to/{1}/auth-id=apexedi",
                        startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
                    _response = client
                        .GetAsync(urlString)
                        .Result;

                    var stringResult = GetContentAsJsonString(MethodBase.GetCurrentMethod().Name);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        static string GetContentAsJsonString(string methodName = null)
        {
            if (_response != null && _response.Content != null)
            {
                string stringResult = _response.Content.ReadAsStringAsync().Result;

                if (_outputJsonToFile && !string.IsNullOrWhiteSpace(methodName))
                {
                    //File.WriteAllText(string.Format("{0}_{1:yyyyMMddHHmmss}-JSON.txt", methodName, DateTime.Now), stringResult);
                }
                return stringResult;
            }

            return string.Empty;
        }

    }
}
