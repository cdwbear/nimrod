using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIstDigitsOfNumericInput
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            Console.WriteLine("Enter an integer, press Enter by itself to Quit");
            bool bDone = false;
            bool negative = false;
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
                        negative = number < 0;
                        input = negative ? Math.Abs(number) : number;
                        bDone = true;
                    }
                }

            } while (!bDone);

            Stack<int> digitStack = new Stack<int>();

            CollectDigits(digitStack, input);

            Console.WriteLine("The digits of the inputted number are:");
            if (negative)
            {
                Console.Write("- ");
            }

            while(digitStack.Count > 0)
            {
                Console.Write($"{digitStack.Pop()} ");
            }

            Console.ReadLine();
        }

        static void CollectDigits(Stack<int> digits, int input)
        {
            int modResult = input % 10;
            digits.Push(modResult);

            if (input < 10)
                return;

            CollectDigits(digits, input / 10);
        }
    }
}
