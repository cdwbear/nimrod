using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Apex.OneTouchService;
using Apex.OneTouchWebserviceContracts.Eligibility.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Formatting = Newtonsoft.Json.Formatting;

namespace EligConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			string jsonPath = @"C:\Source\inpt_json.json";
			string xmlPath = @"C:\Source\eligXml.txt";
			var jsonText = File.ReadAllText(jsonPath);
			var xmlText = File.ReadAllText(xmlPath);
			XmlDocument xd = new XmlDocument();
			xd.Load(xmlPath);
			try
			{
				string json = JsonConvert.SerializeObject(xd, Formatting.Indented);
				jsonText = File.ReadAllText(@"D:\TestJSON.txt");
				var benefitRequest = JsonConvert.DeserializeObject<WsBenefitSubmitRequest>(json);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}
