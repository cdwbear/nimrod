using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ConsoleLab2
{
    class Program
    {
        private static HttpResponseMessage _response;
        private static string _token;
        private const string ServiceBaseURL = "http://production.services.apexedi.com/api/v3/";

        static void Main(string[] args)
        {
            string creds = "P34NOPEA453211QUEXWOXRVK" + ":" + "JA12345KTQOFK4WOHIWQ0J5D";
            byte[] bcreds = Encoding.ASCII.GetBytes(creds);
            string base64Creds = Convert.ToBase64String(bcreds);
            HttpClient client = new HttpClient { BaseAddress = new Uri(ServiceBaseURL) };
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + base64Creds);

            try
            {
                _response = client.PostAsync(
                    "claims/status/get_by_date?vendorSiteId=000_Client&startDate=2016-06-12&endDate=2016-06-16",
                    null).Result;

                if (_response.StatusCode == HttpStatusCode.Accepted)
                {
                    string results = _response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

/*
 * 
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
 
namespace SampleAppV3
{
    class Program
    {
        private static HttpResponseMessage _response;
        private static string _token;
        private const string ServiceBaseURL = "http://production.services.apexedi.com/api/v3/";
    }
 
    static void Main(string[] args)
    {
        string creds = "P34NOPEA453211QUEXWOXRVK" + ":" + "JA12345KTQOFK4WOHIWQ0J5D";
        byte[] bcreds = Encoding.ASCII.GetBytes(creds);
        string base64Creds = Convert.ToBase64String(bcreds);
        HttpClient client = new HttpClient { BaseAddress = new Uri(ServiceBaseURL) };
        client.DefaultRequestHeaders.Add("Authorization", "Basic " + base64Creds);
        MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
 
        try
        {
            _response = client.PostAsync(
                    "claims/status/get_by_date?vendorSiteId=000_Client&startDate=2016-06-12&endDate=2016-06-16",
                    null).Result;
 
            if (_response.StatusCode == HttpStatusCode.Accepted)
            {
                string results = _response.Content.ReadAsStringAsync().Result;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
} 
     * * 
 * 
 * */
