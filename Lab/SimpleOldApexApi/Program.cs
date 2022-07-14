using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Xml;

namespace SimpleOldApexApi
{

	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Please enter the UserName:");
			//userName = Console.ReadLine();
			Console.WriteLine("Please enter the user's Password");
			//password = Console.ReadLine();

			GetEligibilityPayers("GetEligibilityPayers");
			GetProviders("GetProviders");
			SubmitEligibility("SubmitEligibility");
		}

		private static readonly HttpClient client = new HttpClient();

		//private static string URL = "http://onetouch.clayton2.apexedi-eng.com/secure/";
		private static string URL = "https://localhost:44300/secure/";

		//private static string userName = "WARREN";
		private static string userName = "drpete@abcpediatricsutah.com";
		private static string password = "abc";

		public static void GetEligibilityPayers(string methodCall)
		{
			using (var tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(45)))
			{
				var postString = $"{URL}apexeligibilityapi.asmx/{methodCall}?username={userName}&password={password}";
				var response =
					client.GetAsync(

						postString);

				var responseString = response.Result.Content.ReadAsStringAsync().Result;

				Console.WriteLine(postString);
				Console.WriteLine(responseString);
			}
		}

		public static void GetProviders(string methodCall)
		{
			var postString = $"{URL}apexeligibilityapi.asmx/{methodCall}?username={userName}&password={password}";
			var response =
				client.GetAsync(

					postString);

			var responseString = response.Result.Content.ReadAsStringAsync().Result;

			Console.WriteLine(postString);
			Console.WriteLine(responseString);

		}

		public static void SubmitEligibility(string methodCall)
		{
			var postString =
				$"{URL}apexeligibilityapi.asmx/{methodCall}?username={userName}&password={password}&providerID=3159&payerID=595&eqCode=30&subscriberID=210644197&subscriberFirstName=David&subscriberLastName=turner&subscriberDateOfBirth=04/11/1976&subscriberIsMale=true&isInNetwork=true&dependentFirstName=&dependentLastName=&dependentDateOfBirth=&dependentIsMale=false";

			var response = client.GetAsync(postString);

			var responseString = response.Result.Content.ReadAsStringAsync().Result;

			Console.WriteLine(postString);
			Console.WriteLine(responseString);
			XmlDocument xml = new XmlDocument();
			xml.LoadXml(responseString);
			string requestId = xml.InnerText;

			GetEligibilityResponse("GetEligibilityResponse", requestId, false);
		}

		public static void GetEligibilityResponse(string methodCall, string requestId, bool return271Response)
		{
			var postString =
				$"{URL}apexeligibilityapi.asmx/{methodCall}?username={userName}&password={password}&functionalGroupEligibilityID={requestId}&return271Response={return271Response}";

			var response = client.GetAsync(postString);

			var responseString = response.Result.Content.ReadAsByteArrayAsync().Result;
			string responseStr = Encoding.UTF8.GetString(responseString, 0, responseString.Length);

			Console.WriteLine(postString);

			if (return271Response)
			{
				XmlDocument xml = new XmlDocument();
				xml.LoadXml(responseStr);
				var prettyPrint = xml.InnerText.Replace("~", "~\r\n");
				Console.WriteLine(prettyPrint);
			}
			else
			{
				Console.WriteLine(responseStr);
			}
		}
	}
}