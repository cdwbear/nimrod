using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Dictionary<int, object> dict = new Dictionary<int, object>();

            Console.WriteLine();
            Console.WriteLine();

            int count = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            do
            {
                HashSet<int> hs = new HashSet<int>();

                var countCollisions = 0;
                do
                {
                    var nextRnd = rnd.Next(1, 10);

                    countCollisions += hs.Add(nextRnd) ? 0 : 1;
                    Console.WriteLine(nextRnd);
                    //if (dict.ContainsKey(nextRnd) == false)
                    //{
                    //    hs.A
                    //    dict[nextRnd] = null;
                    //    Console.WriteLine(nextRnd);
                    //}

                } while (hs.Count < 9);

                foreach (var i in hs)
                {
                    Console.Write(i);
                }

                Console.WriteLine();

                Console.WriteLine($"Collisions: {countCollisions}");
                count++;

            //} while (Console.ReadKey().Key != ConsoleKey.A || count < 10);
			} while (count< 10);
            sw.Stop();

            var averageMs = sw.ElapsedMilliseconds / count;
            var averageTicks = sw.ElapsedTicks / count;

            Console.WriteLine($"Average ms per random set: {averageMs}, Average ticks: {averageTicks}");
            Console.ReadLine();

            Grid g = new Grid(3);
            g.Blocks[0, 0, 0].Cells[0, 0, 0].Value = 0;

            // g[0,0,0]


            //int[] rowOf9 = new int[9];
            //int tryCount = 0;
            //rnd = new Random();
            //for (int i = 1; i < 10; i++)
            //{
            //    while (true)
            //    {
            //        tryCount++;
            //        int nextInt = rnd.Next(0, 9);
            //        if (rowOf9[nextInt] == 0)
            //        {
            //            rowOf9[nextInt] = i;
            //            break;
            //        }
            //    }

            //}
        }
    }
}
