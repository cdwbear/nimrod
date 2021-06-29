using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Web;

namespace ConsoleLab
{
    public class Foo
    {
        public class Feba
        {

        }
    }

    public abstract class MyAbstract
    {
        public string WhoAmI()
        {
            return this.GetType().Name;
        }
    }

    public class MyDerived1 : MyAbstract
    {

    }

    public class TryIt
    {
        public string A { get; set; }
        public string B { get; set; }
    }

    class Program
    {
        static void ReferenceTest(out List<string> myList)
        {
            myList = new List<string>();
            myList.AddRange(new string[]{"one", "two", "three", "four"});
        }

        static void ReferenceTest2(List<string> myList)
        {
            if (null == myList)
            {
                myList = new List<string>();
            }

            myList.AddRange(new string[]{"1", "2", "3", "4"});
        }
        private static int? MyNullInt { get; set; }

        private static string _backString = string.Empty;
        private static string myGoofString
        {
            get { return _backString ?? string.Empty; }
            set { _backString = value ?? string.Empty; }
        }

        private static List<long> TimeDbAccess(int max, bool disposable)
        {
            int iterMax = max;
            List<long> times = new List<long>(iterMax);

            int iterCount = 0;

            //Console.ReadKey();

            //iterCount = 0;
            //for (int idx = 0; idx < times.Count; idx += 2)
            //{
            //    Console.WriteLine("{0}: {1}\t {2}: {3}", ++iterCount, times[idx], ++iterCount, times[idx + 1]);
            //}

            //Console.ReadKey();

            return times;

        }

        public enum WhatA
        {
            FUNNY,
            STRANGE
        }

        static void GetOutput(string p, string q, ref string outputID)
        {
            if (string.IsNullOrWhiteSpace(outputID))
                outputID = "forte";
            else
            {
                outputID = null;
            }
        }

        static string FigureString(string phStr)
        {
            Regex regexObj = new Regex(@"[^\d]");
            var resultString = regexObj.Replace(phStr, "");

            int diff = resultString.Length - 10;

            char firstChar;

            if (diff > 0)
            {
                resultString = DoFirstChar(resultString, false);

                resultString = resultString.Substring(0, 10);

                // see if there are any more 0's or 1's in this 10 digit number

                resultString = DoFirstChar(resultString, true);
            }
            else if (diff < 0)
            {
                string prePadString = new string('9', diff * -1);

                resultString = prePadString + resultString;
            }
            else
            {
                resultString = DoFirstChar(resultString, true);
            }

            return resultString;
        }

        static string DoFirstChar(string s, bool replaceWith9)
        {
            string retString = s;

            if (!string.IsNullOrWhiteSpace(s) && s.Length > 1)
            {
                char firstChar = s[0];
                if (firstChar == '0' || firstChar == '1')
                {
                    retString = s.Substring(1);
                    if (replaceWith9)
                        retString = '9' + retString;
                }
            }
            return retString;
        }

        public class classA
        {
            public virtual string Print()
            {
                return "classA";
            }
        }

        public class classB : classA
        {
            public override string Print()
            {
                return "classB";
            }
        }

        public class classC : classB
        {
            public new string Print()
            {
                return "ClassC";
            }
        }

		public class Orb1
		{
			public string Orb1Name { get; set; }

			public int OrbId { get; set; }

			public Orb2 orb2 { get; set; }
		}

		public class Orb2
		{
			public string Orb2Name { get; set; }

			public Orb3 orb3 { get; set; }
		}

		public class Orb3
		{
			public string Orb3Name { get; set; }

            public string IsIt = null;
        }

		private static void TestString(string qerj)
		{
			qerj = "what now";
		}

        static Dictionary<string, string> SettingDict { get; set; }

        static string MyFavoriteString { get; set; }

        static string getSubmitterId(string payerID, string eSubId)
        {
            string idCode = string.Empty;
            if (payerID != null && eSubId != null)
            {
                foreach (string singleESubId in eSubId.Split('|'))
                {
                    if (singleESubId.Contains(payerID + '-'))
                    {
                        idCode = singleESubId.Split('-')[1];
                    }
                }
            }

            return idCode;
        }

        static void Main(string[] args)
        {
            string machineName = System.Environment.MachineName;
            string userName = System.Environment.UserName;

            List<string> myEnumerableStrings = new List<string>(){"one", "two", "three"};
            List<string> myEnumerableStrings2 = new List<string>(){"three", "four", "five"};

            var csvList = new List<string[]>();

            var csText = "one, two, three ,four , five";

            string[] csSplitString = csText.Split(new []{','}, StringSplitOptions.RemoveEmptyEntries);


            // string jsonString = new System.Web.Script.


            //myEnumerableStrings.

            // var bytes = Convert.FromBase64String("IDPqAgB6SRCwlg92Eblhmf9o0gARSmMuD70dbbmV1O8=");
            var returnedECode = getSubmitterId("blahblah", " ");

            string product4 = $"this is a {(DateTime.Today.Month < 3 ? "test1" : "test2")}";

            var newOrb = new Orb3 {IsIt = null};

            List<Orb3> orbList = new List<Orb3>();

            orbList.AddRange(new []{new Orb3{IsIt = "True", Orb3Name = "True"}, new Orb3{Orb3Name = "Hello2"}, null});

            var parseThis = string.Empty;
            parseThis = null;

            var resultThis = bool.Parse(parseThis ?? "False");

            parseThis = "False";
            resultThis = bool.Parse(parseThis ?? "False");

            parseThis = "True";
            resultThis = bool.Parse(parseThis ?? "False");

            resultThis = bool.Parse(orbList[0]?.IsIt ?? "False");

            var whatNow = orbList[2]?.IsIt;

            foreach (var orb in orbList)
            {
                if (!bool.TryParse(orb?.IsIt, out bool parsedValue) || parsedValue == false)
                {
                    continue;
                }
                //if (!bool.Parse(orb.IsIt ?? "blah blah"))
                //{
                //    continue;
                //}
            }

            newOrb = null;

            if (!bool.Parse(newOrb?.IsIt))
            {

            }
            string dateStringA = "2020-04-30";
            CultureInfo enUS = new CultureInfo("en-US");

            if (DateTime.TryParseExact(dateStringA, new[] {"yyyy-mm-dd"}, enUS, DateTimeStyles.None,
                out DateTime outDate))
            {

            }

            DateTime datNowLocal = DateTime.Now;
            Console.WriteLine("Converting {0}, Kind {1}:", datNowLocal, datNowLocal.Kind);
            Console.WriteLine("   ConvertTimeToUtc: {0}, Kind {1}", TimeZoneInfo.ConvertTimeToUtc(datNowLocal), TimeZoneInfo.ConvertTimeToUtc(datNowLocal).Kind);
            Console.WriteLine();

            DateTime datNowUtc = DateTime.UtcNow;
            Console.WriteLine("Converting {0}, Kind {1}", datNowUtc, datNowUtc.Kind);
            Console.WriteLine("   ConvertTimeToUtc: {0}, Kind {1}", TimeZoneInfo.ConvertTimeToUtc(datNowUtc), TimeZoneInfo.ConvertTimeToUtc(datNowUtc).Kind);
            Console.WriteLine();

            DateTime datNow = new DateTime(2007, 10, 26, 13, 32, 00);
            Console.WriteLine("Converting {0}, Kind {1}", datNow, datNow.Kind);
            Console.WriteLine("   ConvertTimeToUtc: {0}, Kind {1}", TimeZoneInfo.ConvertTimeToUtc(datNow), TimeZoneInfo.ConvertTimeToUtc(datNow).Kind);
            Console.WriteLine();

            DateTime datAmbiguous = new DateTime(2007, 11, 4, 1, 30, 00);
            Console.WriteLine("Converting {0}, Kind {1}, Ambiguous {2}", datAmbiguous, datAmbiguous.Kind, TimeZoneInfo.Local.IsAmbiguousTime(datAmbiguous));
            Console.WriteLine("   ConvertTimeToUtc: {0}, Kind {1}", TimeZoneInfo.ConvertTimeToUtc(datAmbiguous), TimeZoneInfo.ConvertTimeToUtc(datAmbiguous).Kind);
            Console.WriteLine();

            DateTime datInvalid = new DateTime(2007, 3, 11, 02, 30, 00);
            Console.WriteLine("Converting {0}, Kind {1}, Invalid {2}", datInvalid, datInvalid.Kind, TimeZoneInfo.Local.IsInvalidTime(datInvalid));
            try
            {
                Console.WriteLine("   ConvertTimeToUtc: {0}, Kind {1}", TimeZoneInfo.ConvertTimeToUtc(datInvalid), TimeZoneInfo.ConvertTimeToUtc(datInvalid).Kind);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("   {0}: Cannot convert {1} to UTC.", e.GetType().Name, datInvalid);
            }
            Console.WriteLine();

            DateTime datNearMax = new DateTime(9999, 12, 31, 22, 00, 00);
            Console.WriteLine("Converting {0}, Kind {1}", datNearMax, datNearMax.Kind);
            Console.WriteLine("   ConvertTimeToUtc: {0}, Kind {1}", TimeZoneInfo.ConvertTimeToUtc(datNearMax), TimeZoneInfo.ConvertTimeToUtc(datNearMax).Kind);
            Console.WriteLine();
            //
            // This example produces the following output if the local time zone 
            // is Pacific Standard Time:
            //
            //    Converting 8/31/2007 2:26:28 PM, Kind Local:
            //       ConvertTimeToUtc: 8/31/2007 9:26:28 PM, Kind Utc
            //    
            //    Converting 8/31/2007 9:26:28 PM, Kind Utc
            //       ConvertTimeToUtc: 8/31/2007 9:26:28 PM, Kind Utc
            //    
            //    Converting 10/26/2007 1:32:00 PM, Kind Unspecified
            //       ConvertTimeToUtc: 10/26/2007 8:32:00 PM, Kind Utc
            //    
            //    Converting 11/4/2007 1:30:00 AM, Kind Unspecified, Ambiguous True
            //       ConvertTimeToUtc: 11/4/2007 9:30:00 AM, Kind Utc
            //    
            //    Converting 3/11/2007 2:30:00 AM, Kind Unspecified, Invalid True
            //       ArgumentException: Cannot convert 3/11/2007 2:30:00 AM to UTC.
            //    
            //    Converting 12/31/9999 10:00:00 PM, Kind Unspecified
            //       ConvertTimeToUtc: 12/31/9999 11:59:59 PM, Kind Utc
            //            


            var dt1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 2, 0, 0).AddMonths(1);
            var dt2 = DateTime.Now.AddMonths(1);
            var comp = DateTime.Compare(dt1, dt2);

            if(MyFavoriteString == null)
                Console.WriteLine("It IS null!!");

            if (SettingDict == null)
            {
                SettingDict = new Dictionary<string, string>();
            }

            bool isNotNull = SettingDict == null;
            string mainPath = AppDomain.CurrentDomain.BaseDirectory;

            Regex regex99 = new Regex(@"^(?<Prefix>(([^:/?#]+):)?)(//([^/?#]*))?([^?#]*)(\?([^#]*))?(#(.*))?");
            Regex regex100 = new Regex(@"^(?<Prefix>(([^:/?#]+):)?)(?<Domain>(//([^/?#]*)))?([^?#]*)(\?([^#]*))?(#(.*))?");

            var matches99 = regex99.Matches("https://onetouch.apexedi.com/V1/onetouch");
            var matches100 = regex100.Matches("https://onetouch.apexedi.com/V1/onetouch");

            if (matches100.Count > 0)
            {
                string url = $"{matches100[0].Groups["Prefix"]}{matches100[0].Groups["Domain"]}/api/V3/";
            }
            int cents = 3450;

            decimal goo = (decimal)cents / 100;

            Console.WriteLine($"goo = {goo:N2}");
			Orb1 ob1 = null;
			Orb1 ob2 = new Orb1() { OrbId = 1 };

			int? myNint = null;

			myNint = ob1 == null ? (int?)null : ob1.OrbId;


			bool doesit = EventLog.SourceExists("ApexServicesEventSource");


			var elemSep = "*";
			var rgx49 = new Regex(@"~REF" + elemSep+ "6R" + elemSep + @"(?<refID>APEXZZ[\S]{1,44})~");

			string myRef6R = "~REF*6R*APEXZZ123456~";

			var matches = rgx49.Matches(myRef6R);
			if(matches.Count > 0)
			{
				foreach(Match m in matches)
				{
					var goobah = m.Groups["refIeD"].Value;
				}
			}

			string ssss = "nothing";
			TestString(ssss);
			List<Orb1> o1 = new List<Orb1>();
			List<Orb2> o2 = new List<Orb2>();
			List<Orb3> o3 = new List<Orb3>();

			o3.Add(new Orb3() { Orb3Name = "Orb3A" });
			o3.Add(new Orb3() { Orb3Name = "Orb3B" });

			o2.Add(new Orb2() { Orb2Name = "Orb2A" });
			o2.Add(new Orb2() { Orb2Name = "Orb2B" });
			o2[0].orb3 = o3[0];

			o1.Add(new Orb1 { Orb1Name = "Orb1A", orb2 = o2[0], });

			Orb2 o2Z = o2[0];
			o2Z.Orb2Name = "Johnny";


			List<TryIt> tryItList = new List<TryIt>();

			TryIt ti1 = new TryIt() { A = "test" };

			tryItList.Add(ti1);

			ti1 = new TryIt();
			ti1.A = "tested";

			tryItList.ForEach(x => Console.WriteLine(x.A));

            List<int> rNums = new List<int>() {1, 22, 14, 8, 5, 3, 4, 10, 9, 7};

            var evenNums = rNums.Where(x => x % 2 == 0).Take(3).ToList();

            classA A = new classC();
            Console.WriteLine(A.Print());

            var cMong = new classC();
            Console.WriteLine(cMong.Print());

            var bogusDirExists = Directory.Exists(@"C:\Bugaboo");
            var fileExists = File.Exists(@"C:\Bugaboo\MyBugabooFile.text");
            List<int> myIntList = new List<int>() {1, 2, 3, 4, 5, 6, 7};

            var doesIt = myIntList.Any(q =>
            {
                return (q / 2 == 2);
            });

            var rgx = new Regex("[:alnum:]");
            bool isItAMatch = rgx.IsMatch("MyFriend123451234asdf");
            //isItAMatch = rgx.IsMatch(";;;ABC123");
            //isItAMatch = rgx.IsMatch("0123456789AAAAAAAAAA///");
            //rgx = new Regex("^[A-Za-z0-9]+$");
            //isItAMatch = rgx.IsMatch("MyFriend123451234asdf");
            //isItAMatch = rgx.IsMatch(";;;ABC123");
            //isItAMatch = rgx.IsMatch("0123456789AAAAAAAAAA///");
            //var phStr1 = "18012229758";
            //var phStr2 = "1 8012229758 x123";
            //var phStr3 = "2229758";

            rgx = new Regex("^9{5,}|0{5,}$");

            isItAMatch = rgx.IsMatch("99999");
            isItAMatch = rgx.IsMatch("00000");
            isItAMatch = rgx.IsMatch("9999");

            List<string> phStringsList = new List<string>()
            {
                "18012229758","1 8012229758 x123","2229758", "", "A1B0C8GarbageInAHand234basket5423"
            };

            List<string> phListResult = new List<string>();

            phStringsList.ForEach(ph => phListResult.Add(FigureString(ph)));

            //var resultString = FigureString(phStr1);
            //resultString = FigureString(phStr2);
            //resultString = FigureString(phStr3);

            var myDggo = "12345";


            var whatIsThisTypeCode = myDggo[0];

            var whatMore = (int) whatIsThisTypeCode;

            TryIt t = new TryIt();

            t.A = "test";

            TryIt t2 = null;

            (t2 ?? (t2 = new TryIt())).B = "test2";

            string dre = "";
            string dr32 = dre.Substring(0, 0);
            List<MyDerived1> myDerived1s = new List<MyDerived1>();

            myDerived1s.Add(null);

            int myderdCount = myDerived1s.Count;

            string outputID = null;

            GetOutput("test", "this", ref outputID);
            GetOutput("test", "this", ref outputID);



            DateTime d1 = new DateTime(2018, 4, 2, 14, 24, 00);
            DateTime d2 = new DateTime(2018, 4, 2, 14, 56, 5);
            DateTime d3 = DateTime.Now.AddHours(-3);

            Console.WriteLine(DateTime.Now.Subtract(d3).ToString("hh\\:mm\\:ss"));

            MyDerived1 md1 = new MyDerived1();

            Console.WriteLine(md1.WhoAmI());

            string dtString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime myDate = DateTime.Today;
            myDate = new DateTime(myDate.AddMonths(-24).Year, myDate.Month, 1, 0, 0, 0);
            
            Dictionary<string, int> SomeWeirdDict = new Dictionary<string, int>();

            if (!SomeWeirdDict.ContainsKey(""))
            {
                SomeWeirdDict.Add("", 42);
                if (!SomeWeirdDict.ContainsKey(""))
                {
                    SomeWeirdDict.Add("", 56);
                }
            }


            var whatIsIt = WhatA.FUNNY.ToString();


            Stopwatch swD = new Stopwatch();
            Stopwatch swO = new Stopwatch();
            swD.Start();
            var timesDisp = TimeDbAccess(200, true);
            swD.Stop();
            swO.Start();
            var timesOpen = TimeDbAccess(200, false);
            swO.Stop();

            Console.WriteLine("Disp Time: {0}", swD.ElapsedMilliseconds);
            Console.WriteLine("Open Elabpsed: {0}", swO.ElapsedMilliseconds);

            int count = 0;

            Console.WriteLine("Times for Disposable");
            foreach (var lapse in timesDisp)
            {
                Console.WriteLine("Time Sample {0}: {1}", ++count, lapse);
            }

            Console.ReadKey();

            count = 0;
            Console.WriteLine("Times for Continuous Open");
            foreach (var lapse in timesOpen)
            {
                Console.WriteLine("Time Sample {0}: {1}", ++count, lapse);
            }

            Console.ReadKey();

            Dictionary<string, List<int>> myDicta = new Dictionary<string, List<int>>();

            if(!myDicta.ContainsKey("Test"))
            {
                myDicta["Test"] = new List<int>(new[]{4});
            }

            var isMyNullIntNull = MyNullInt;
            var isThere = EventLog.SourceExists("Blah Blah");

            myGoofString = null;
            var mygoogoo = myGoofString;
            //var ctxCw = new ModelCw
            // 209985


            var myObject = new object();

            myObject = null;
            string textStr = string.Format("This is a test {0}", myObject);

            var apex1ConnectionString =
                "Data Source=Apexdb1;Initial Catalog=Claimstaker;Persist Security Info=True;User ID=webserver; Password=EDIOnTheWeb1;Connection Timeout=3600";
            // "Data Source=CW2012\\CWDB;Initial Catalog=Claimstaker;Persist Security Info=True;User ID=sa; Password=Apexedi1!;Connection Timeout=3600";


            // string queryString = "SELECT tPatCulIntPatIDPk, tPatSFirstname, tPatSName, tPatDBirthday  FROM  [dbo].[TPatientRaw] WHERE tPatSName = @tPatSName";
            // string queryString = "SELECT TOP 10 * FROM PayerReportRaw_T WHERE PayerReportType_ID = 3 AND (PayerReportParseStatus_ID IS NULL OR PayerReportParseStatus_ID = 0)";
            string queryString = "SELECT * FROM PayerReportRaw_T WHERE PayerReportType_ID = 3 AND (PayerReportParseStatus_ID IS NULL OR PayerReportParseStatus_ID = 0)";
            string connectionString = apex1ConnectionString;      // "Server=.\\PDATA_SQLEXPRESS;Database=;User Id=sa;Password=2BeChanged!;";

            while (true)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    // command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        int rowCount = 0;
                        while (reader.Read())
                        {
                            //Dictionary<int, string> colDict = new Dictionary<int, string>();
                            //for (int i = 0; i < reader.FieldCount; i++)
                            //{
                            //    colDict[i] = reader.GetName(i);
                            //    Console.WriteLine(i + ": " + reader.GetName(i));
                            //}

                            ////Console.WriteLine(String.Format("{0}, {1}",
                            ////    reader["PayerReportRaw_ID"], reader["CreatedDate_DT"]));// etc

                            //Console.WriteLine((long) reader["PayerReportRaw_ID"]);
                            //Console.WriteLine((int) reader["Output_ID"]);
                            //Console.WriteLine((int) reader["PayerReportType_ID"]);
                            //Console.WriteLine((string) reader["PayerReportFileName_VC"]);
                            //Console.WriteLine((string) reader["PayerReportFileContents_MX"]);
                            //Console.WriteLine((string) reader["PayerReportFileName_VC"]);

                            //if (reader.IsDBNull(6))
                            //{
                            //    Console.WriteLine("");
                            //}
                            //else
                            //{
                            //    Console.WriteLine((DateTime) reader["CreatedDate_DT"]);
                            //}

                            //if (reader.IsDBNull(7))
                            //{
                            //    Console.WriteLine("");
                            //}
                            //else
                            //{
                            //    Console.WriteLine((DateTime?) reader["LastUpdate_DT"]);

                            //}

                            //Console.WriteLine(!reader.IsDBNull(8) ? reader["PayerReportParseStatus_ID"] : string.Empty);
                            //Console.WriteLine(!reader.IsDBNull(9) ? reader["ClaimCount_IN"] : string.Empty);
                            //Console.WriteLine(!reader.IsDBNull(10) ? reader["VendorReportCreated"] : false);
                            //Console.WriteLine("===========================================================================");
                            rowCount++;
                        }

                        Console.WriteLine(string.Format("{0} Rows Read", rowCount));
                        System.Threading.Thread.Sleep(600000);
                    }
                    finally
                    {
                        // Always call Close when done reading.
                        reader.Close();
                    }
                }
            }


            var myPreList = new List<string>();
            ReferenceTest(out myPreList);
            ReferenceTest2(new List<string>());

            Foo.Feba bo = new Foo.Feba();
        }
    }
}
