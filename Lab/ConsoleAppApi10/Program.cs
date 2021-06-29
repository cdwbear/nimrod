using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using ConsoleAppApi10.com.apexedi.onetouch;

namespace ConsoleAppApi10
{
	class Program
	{
		static void Main(string[] args)
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

			ApexEligibilityAPI client = new ApexEligibilityAPI();

			try
			{
				var resultId = client.SubmitEligibility("CPZ", "Smile$1250", 57034, 19, "35", "118186924601", "Rimma", "Lovka", "01/08/1987", false, true, "", "", "", false);
				var resultString = client.GetEligibilityResponse("CP2", "Smile$1250z", resultId, false);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex);
				Console.ReadLine();
			}
		}
	}
}
