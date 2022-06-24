using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;

namespace SimpleEligibility
{
	class Program
	{
		private static HttpResponseMessage _response;
		private static string _creds = "QGO4TRR1NGZOOSFBW14WML1W" + ":" + "GFL2K0I3GODAQRHBG20DOQ2H";
		private static string _vendorSiteId = "A4B";
		// private static string jsonEligTextFile = @"C:\TestFiles\EligTest01.json";
		private static string jsonEligTextFile = @"C:\Source\CSGit1\claimstaker\Apex1\WebSite\ApexDevelopers\v3\new 10.json";


		static void Main(string[] args)
		{
			using (HttpClient client = new HttpClient())
			{
				//client.BaseAddress = new Uri("https://sandbox.services.apexedi.com/api/v3/");
				client.BaseAddress = new Uri("http://localhost:58693/api/v3/");
				byte[] creds = Encoding.ASCII.GetBytes(_creds);
				string base64Creds = Convert.ToBase64String(creds);
				client.DefaultRequestHeaders.Add("Authorization", "Basic " + base64Creds);
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				client.Timeout = System.Threading.Timeout.InfiniteTimeSpan;

				StringContent httpStringContent = null;

				// The member ID of the subscriber controls what will be returned.  This is true, even if the benefits 
				// are  being requested for a dependent.  When using a test payer, the following member IDs may be 
				// used to auto-generate various errors and response scenarios

				// 1001 - envelope errors
				// 1002 - payer errors
				// 1003 - payee errors
				// 1004 - subscriber errors
				// 1005 - dependent errors
				// 1006 - syntax error
				// 1007 - complex benefits will be returned
				// 1008 - simple benefits will be returned after a delay of approximately 65 seconds. Note that
				// there will be a 65 second delay for each patient (subscriber or dependent) where 1008 is the
				// subscriber member ID.
				// Any other member ID - simple benefits will be returned
				/*
				 * Note that while any member ID other than the ones listed above will return simple benefits, member IDs
				 * in the range of 1000 to 1999 are reserved for special return values, so they should be avoided. Member
				 * ID 2001 will always be safe to use to successfully generate a benefit response.
				 */

				string memberId = "1007";	// 1007 will give complex benefits

				string jsonString =
					$@"{{
    ""BenefitInquiries"": [
				{{
					""Payers"": [
					{{
						""CommonName"": ""Test Payer"",
						""EntityType"": ""Organization"",
						""Payees"": [
						{{
							""CommonName"": ""LASTNAME"",
							""EntityType"": ""Individual"",
							""FirstName"": ""FIRSTNAME"",
							""NationalProviderId"": ""1234567893"",
							""Subscribers"": [
							{{
								""Dependents"": null,
								""RequestedBenefits"": [
								{{
									""IsFamilyBenefit"": false,
									""Type"": [
									""HealthBenefitPlanCoverage""
										]
								}}],
								""CommonName"": ""LastName"",
								""FirstName"": ""Benjamin"",
								""BirthDate"": ""1981-08-21"",
								""Gender"": ""Male"",
								""MemberId"": ""{memberId}"",
								""PayeeTraceNumber"": {{
									""Number"": ""SingleSubServiceSingle-01"",
									""OriginatorID"": ""1923457658""
								}}
							}}],
							""Type"": ""Facility""
						}}],
						""PayerId"": ""APX15944"",
						""Type"": ""Payer""
					}}]
				}}],
				""IsTest"": true
			}}
			";
				// Alternately, you can load a JSON file instead of using the hard coded
				// inline example
				//if (File.Exists(jsonEligTextFile))
				//{
				//	jsonString = File.ReadAllText(jsonEligTextFile);
				//}
				//,
				//""RequestType"": ""Request""

				httpStringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
				_response = client.PostAsync($"eligibility/submit?vendorSiteId={_vendorSiteId}", httpStringContent)
					.Result;

				string resultString = string.Empty;
				if (_response != null && _response.Content != null)
				{
					resultString = _response.Content.ReadAsStringAsync().Result;
				}

				try
				{
					long requestId = 0L;
					if (_response.StatusCode == HttpStatusCode.OK)
					{
						JObject jObject = JObject.Parse(resultString);
						requestId = (long) (jObject["RequestId"] ?? 0);

						string statusMsg = (string) (jObject["Status"] ?? string.Empty);

						if (string.Compare(statusMsg, 
							    "ResultsComplete", StringComparison.CurrentCultureIgnoreCase) != 0)
						{
							_response = client.PostAsync(
									$"eligibility/get_responses?vendorSiteId={_vendorSiteId}&requestId={requestId}",
									null)
								.Result;

							if (_response != null && _response.Content != null)
							{
								resultString = _response.Content.ReadAsStringAsync().Result;
							}
						}
					}

				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
					throw;
				}
			}
		}
	}
}
