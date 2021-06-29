using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ConsoleApp1.ProdServices;
using ConsoleApp1.SandBoxServices;
//using ConsoleApp1.LocalRef;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        private static OneTouchServicesClient client15 = new OneTouchServicesClient();
        static void Main(string[] args)
        {
            int a;

            for (a = 10; a <= 15; a++)
                while (Convert.ToBoolean(Convert.ToInt32(a)))
                {
                    do
                    {
                        Console.WriteLine(1);
                        if (Convert.ToBoolean(a >> 1))
                            continue;
                    } while (Convert.ToBoolean(0));

                    break;
                }

            int val = 1;
            switch (val << 2 + val)
            {
                default:
                    Console.WriteLine("First");
                    break;
                case 4:
                    Console.WriteLine("Second");
                    break;
                case 5:
                    Console.WriteLine("Third");
                    break;
                case 8:
                    Console.WriteLine("Fourth");
                    break;
                case 9:
                    Console.WriteLine("Fifth");
                    break;
            }

            Console.ReadLine();

            int i = 1, j = 1;
            while (++i <= 10)
            {
                j++;
            }

            Console.WriteLine(i + "   " + j);

            int num = 1234, r;
            while (num > 0)
            {
                r = num % 10;
                num = num / 10;
                Console.WriteLine(+r);
            }
            try
            {
                var payers = client15.GetPayers("TY0W3N04KSGKQQCPQ2J512UD", "BSXQZRCJC02ODZ5GI4F1B0DE", PayerType.Medical);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            //Console.WriteLine("Please enter path for files to harvest REF*D9* claim IDs:");
            //var path = Console.ReadLine();
            //if (Directory.Exists(path))
            //{
            //    Dictionary<string, List<string>> refD9ListByFileName = new Dictionary<string, List<string>>();
            //    try
            //    {
            //        var fileList = Directory.GetFiles(path);

            //        foreach (var f in fileList)
            //        {
            //            refD9ListByFileName.Add(f, new List<string>());
            //            Regex refD9Parser = new Regex("^REF.D9.(M|D)(?<cid>[0-9]+)~$");
            //            var allText = File.ReadAllText(f);
            //            allText = allText.Replace("~", "~\r\n");
            //            var lines = allText.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            //            foreach (string line in lines)
            //            {
            //                var matchCollection = refD9Parser.Matches(line);
            //                foreach (Match match in matchCollection)
            //                {
            //                    var groups = match.Groups;
            //                    if (!string.IsNullOrWhiteSpace(groups["cid"].Value))
            //                    {
            //                        refD9ListByFileName[f].Add(groups["cid"].Value);
            //                    }
            //                }
            //            }
            //        }
            //        var writePath = AppDomain.CurrentDomain.BaseDirectory;
            //        var fullWriteFilePath = Path.Combine(writePath, "RefD9s.txt");

            //        using (StreamWriter sw = new StreamWriter(fullWriteFilePath))
            //        {
            //            var memoryBytes = GC.GetTotalMemory(true);
            //            Console.WriteLine($"\r\n\r\n{memoryBytes}");

            //            foreach (KeyValuePair<string, List<string>> kvp in refD9ListByFileName)
            //            {
            //                sw.WriteLine(kvp.Key);
            //                sw.WriteLine(new String('-', 80));
            //                var count = kvp.Value.Count;
            //                kvp.Value.ForEach(cid => { sw.Write(string.Format("{0}{1}", cid, (--count > 0 ? "," : string.Empty))); });
            //                sw.WriteLine();
            //                sw.WriteLine();
            //            }
            //            sw.Flush();
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //    }
        }
    }
}
