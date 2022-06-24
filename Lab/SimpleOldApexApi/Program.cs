using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.Remoting.Channels;

namespace SimpleOldApexApi
{
	class Program
	{
		static void Main(string[] args)
		{
			GetEligibilityPayers(null);
		}

		private static readonly HttpClient client = new HttpClient();
		public static void GetEligibilityPayers(string methodCall)
		{
			var response =
				client.PostAsync(
					
						"http://onetouch.clayton2.apexedi-eng.com/secure/apexeligibilityapi.asmx/GetEligibilityPayers?username=WARRN&password=Abc1!acdeasdf", null);

			// "http://onetouch.clayton2.apexedi-eng.com/secure/apexeligibilityapi.asmx/GetEligibilityPayers?username=csw&password=Abc1!abcdegoober", null);

			var responseString = response.Result.Content.ReadAsStringAsync().Result;

			Console.WriteLine(responseString);
		}
	}
}
