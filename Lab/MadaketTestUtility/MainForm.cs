using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Apex.AdministrativeServices;
using Apex.AdministrativeServices.Contracts.Clients;

namespace MadaketTestUtility
{
    public partial class MainForm : Form
    {
        //public class MadaketClient
        //{
        //    public static readonly string apiV2EndPointBase = "https://test.madakethealth.com/services/api/v";
        //    private readonly string _key = "apexeditest";
        //    private readonly string _secret = "32n!a5xiCjp%sS";
        //    private readonly string _authId = "apexeditest";
        //    private readonly string _partnerShortName = "APEXAPI";

        //    private static int CONTACT_ROLLID_BILLING = 3;
        //    private static int CONTACT_ROLLID_PRIMARY = 7;
        //    private HttpResponseMessage _response = null;
        //    private static ApexClient _apexClient = null;
        //    private static List<string> apiList = new List<string>{"1.2", "2.0", "3.0"};

        //    private class ApexClient : HttpClient
        //    {
        //        public ApexClient(string apiVersion)
        //        {
        //            BaseAddress = new Uri($"{apiV2EndPointBase}{apiVersion}");
        //            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        }

        //        // private static ApexClient Client => _apexClient ?? (_apexClient = new ApexClient());

        //        //public MadaketClient(string endPoint, string key, string secret, string authId, string partnerShortName)
        //        //{
        //        //    apiV2EndPointBase = endPoint;
        //        //    //_key = key;
        //        //    //_secret = secret;
        //        //    //_authId = authId;
        //        //    //_partnerShortName = partnerShortName;
        //        //}
        //    }
        //}

        //public static readonly string apiV2EndPointBase = "https://test.madakethealth.com/services/api/v1.2";
        public static readonly string apiV2EndPointBase = "https://enrollment.madakethealth.com/services/api/v1.2";
        //private readonly string _key = "apexeditest";
        private readonly string _key = "apexediprod";
        //private readonly string _secret = "32n!a5xiCjp%sS";
        private readonly string _secret = "2Nowk2n#@BL25w";
        //private readonly string _authId = "apexeditest";
        private readonly string _authId = "apexediprod";
        private readonly string _partnerShortName = "APEX";
        //private readonly string _partnerShortName = "APEXAPI";
        private MadaketClient client = null;

        public MainForm()
        {
            InitializeComponent();
        }


        /*
         *
         *      <add name="MadaketKey" value="apexediprod" />
      <add name="MadaketSecret" value="2Nowk2n#@BL25w" />
      <add name="MadaketAuthId" value="apexediprod" />
      <add name="MadaketPartnerShortName" value="APEX" />
      <add name="MadaketTestKey" value="apexeditest" />
      <add name="MadaketTestSecret" value="32n!a5xiCjp%sS" />
      <add name="MadaketTestAuthId" value="apexeditest" />
      <add name="MadaketTestPartnerShortName" value="APEXAPI" />

         *
         */

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(comboBoxApiVersion.Items.Count > 0)
                comboBoxApiVersion.SelectedItem = 0;

            MadaketClient client = new MadaketClient(apiV2EndPointBase, _key, _secret, _authId, _partnerShortName);
            //string query = client.GetSite(");")

            var madaketToken = CreateToken();

            //var siteobject = client.GetSite("MCP_51143MCKEEVER");
            //var siteobject = client.GetSite("EGL_698044");
            //var siteobject = client.GetSite("SAQ_832331");

        }


        private string CreateToken()
        {
            string token = null;
            DateTime time = DateTime.UtcNow;
            string timestamp = time.ToString("yyyy-MM-dd-HH-mm");

            string cleartexttoken = $"{_key}{_secret}{timestamp}";
            //string cleartextToken = "apexediprod" + "2Nowk2n#@BL25w" + timestamp;
            token = ToBase64UrlSafeSha256Hash(cleartexttoken);

            return token;
        }

        static string ToBase64UrlSafeSha256Hash(String s)
        {
            HashAlgorithm Hasher = new SHA256CryptoServiceProvider();
            byte[] strBytes = Encoding.UTF8.GetBytes(s);
            byte[] strHash = Hasher.ComputeHash(strBytes);
            string hash = BitConverter.ToString(strHash).Replace("-", "").ToLowerInvariant().Trim();
            var hashBytes = Encoding.UTF8.GetBytes(hash);
            String base64encodedToken = System.Convert.ToBase64String(hashBytes);

            // Remove two extra '=' characters at the end for server-side compatibility
            var base64encodedTokenBytes = System.Text.Encoding.UTF8.GetBytes(base64encodedToken);

            byte[] bytes = new byte[base64encodedTokenBytes.Length - 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = base64encodedTokenBytes[i];
            }
            string truncatedBase64encodedToken = System.Text.Encoding.UTF8.GetString(bytes);

            return truncatedBase64encodedToken;
        }

        /*
         *
                static void Main(string[] args)
                {
                    //MadaketClient client = new MadaketClient(endPoint: "https://test.madakethealth.com/services/api/v3.0",
                    //	key: "apexeditest", secret: "32n!a5xiCjp%sS", authId: "apexeditest", partnerShortName: "APEXAPI");

                    MadaketClient client = new MadaketClient(endPoint: "https://test.madakethealth.com/services/api/v3.0",
                            key: "apexeditest", secret: "32n!a5xiCjp%sS", authId: "apexeditest", partnerShortName: "APEXAPI");

                    var madaketToken = CreateToken();

                    Console.WriteLine(madaketToken);

                }

                static string CreateToken()
                {
                    string token = null;
                    DateTime time = DateTime.UtcNow;
                    string timestamp = time.ToString("yyyy-MM-dd-HH-mm");

                    string cleartextToken = "apexediprod" + "2Nowk2n#@BL25w" + timestamp;
                    token = ToBase64UrlSafeSha256Hash(cleartextToken);

                    return token;
                }

                static string ToBase64UrlSafeSha256Hash(String s)
                {
                    HashAlgorithm Hasher = new SHA256CryptoServiceProvider();
                    byte[] strBytes = Encoding.UTF8.GetBytes(s);
                    byte[] strHash = Hasher.ComputeHash(strBytes);
                    string hash = BitConverter.ToString(strHash).Replace("-", "").ToLowerInvariant().Trim();
                    var hashBytes = Encoding.UTF8.GetBytes(hash);
                    String base64encodedToken = System.Convert.ToBase64String(hashBytes);

                    // Remove two extra '=' characters at the end for server-side compatibility
                    var base64encodedTokenBytes = System.Text.Encoding.UTF8.GetBytes(base64encodedToken);

                    byte[] bytes = new byte[base64encodedTokenBytes.Length - 2];
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        bytes[i] = base64encodedTokenBytes[i];
                    }
                    string truncatedBase64encodedToken = System.Text.Encoding.UTF8.GetString(bytes);

                    return truncatedBase64encodedToken;
                }
        *
         *
         */
    }
}
