using System;
using System.Collections.Generic;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { };
            List<int> nums = new List<int>();
            Console.WriteLine("Enter integers, just press Enter when done:");
            bool bDone = false;
            do
            {
                string entry = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(entry))
                {
                    bDone = true;
                }
                else
                {
                    int number;
                    if (Int32.TryParse(entry, out number))
                    {
                        nums.Add(number);
                    }
                }

            } while (!bDone);

            if (nums.Count > 0)
            {
                Console.WriteLine("Array before sorting:");
                nums.ForEach(x => Console.Write($"{x} "));
                Console.WriteLine("");

                arr = nums.ToArray();
                var arrLen = arr.Length;

                while (arrLen > 0)
                {
                    for (int i = 0, j = 1; j < arrLen; i++, j++)
                    {
                        if (arr[i] > arr[j])
                        {
                            int tmp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = tmp;
                        }
                    }

                    arrLen--;
                }

                Console.WriteLine("Array after sorting:");
                foreach (int i in arr)
                {
                    Console.Write($"{i} ");
                }
            }

            Console.ReadLine();
        }
    }
}
