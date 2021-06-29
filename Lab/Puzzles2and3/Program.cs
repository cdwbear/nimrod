using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles2and3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            do
            {
                Console.WriteLine("Enter 1 for Bubble Sort, or 2 for Number Digitizer or Enter to Quit:");
                var input = Console.ReadLine();

                switch (input)
                {

                    case "1":
                    {
                        bool case1Done = false;
                        int[] sortArray = new int[] { };
                        Console.WriteLine("Enter number for the array to sort, press Enter after each digit, and Enter to quit");
                        do
                        {
                            var stringInput = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(stringInput))
                            {
                                case1Done = true;
                            }
                            else
                            {
                                int inputtedValue = 0;
                                if (Int32.TryParse(stringInput, out inputtedValue))
                                {
                                    sortArray = sortArray.Append(inputtedValue).ToArray();
                                }
                            }
                        } while (!case1Done);

                        Console.WriteLine("The array to be sorted is:");
                        foreach (int j in sortArray)
                        {
                            Console.Write($"{j} ");
                        }

                        var sortedArray = bubbleSortArray(sortArray);
                        Console.WriteLine();
                        Console.WriteLine("The sorted array is:");
                        
                        foreach (var i in sortedArray)
                        {
                            Console.Write($"{i} ");
                        }
                    }
                        break;
                    case "2":
                    {
                        bool case2Done = false;
                        do
                        {
                            Console.WriteLine("Enter a positive or negative Integer value, or Enter to Quit:");
                            var stringInput = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(stringInput))
                            {
                                case2Done = true;
                            }
                            else
                            {
                                int inputtedValue = 0;
                                if (Int32.TryParse(stringInput, out inputtedValue))
                                {
                                    var recurseIt = new RecursiveNumberDigitizer(inputtedValue);
                                }
                            }

                        } while (!case2Done);

                    }
                        break;
                    case "":
                        done = true;
                        break;
                }

            } while (!done);

            Console.ReadLine();
            /*
             *
             public class Main {
    public static void main(String[] args) {
        RecursiveNumberDigitizer rnd = new RecursiveNumberDigitizer(-2345);
    }
}*
    /*
     *
     *
     */
            var digitizer = new RecursiveNumberDigitizer(-2345);
        }
        private static int[] bubbleSortArray(int[] arrayToSort)
        {

            // clone the original array
            int[] sortedArray = new int[arrayToSort.Length];
            arrayToSort.CopyTo(sortedArray, 0);

            // the outer loop will run as many times as there are elements in the array
            for (int i = 0; i < sortedArray.Length; i++)
            {
                // the inner loop reduces in size by one each traversal down the array since the last element will have been
                // sorted and doesn't need to be compared again in subsequent bubble sorts.
                for (int j = 0; j < sortedArray.Length - i; j++)
                {
                    // check if this is the last element; if so, do nothing; if not, compare and swap values if needed
                    if (j + 1 < sortedArray.Length)
                    {
                        if (sortedArray[j] > sortedArray[j + 1])
                        {
                            int swapTemp = sortedArray[j];
                            sortedArray[j] = sortedArray[j + 1];
                            sortedArray[j + 1] = swapTemp;
                        }
                    }
                }
            }
            return sortedArray;
        }
    }


    public class RecursiveNumberDigitizer
    {
        public RecursiveNumberDigitizer(int numberToDigitize)
        {

            // 1. Convert int to String
            string stringedInt = Convert.ToString(numberToDigitize);

            // 1. Handle negative sign up front.
            stringedInt = handleNegativeInt(stringedInt);

            // 2. Digitize the number.
            recursiveDigitizerPrinter(stringedInt);

        }

        private String handleNegativeInt(String numToCheckForNegativeValue)
        {
            if (numToCheckForNegativeValue.Substring(0, 1).Equals("-"))
            {
                Console.WriteLine("- ");
                return numToCheckForNegativeValue.Substring(1);
            }
            else
            {
                return numToCheckForNegativeValue;
            }
        }

        private void recursiveDigitizerPrinter(String stringedInt)
        {

            // A. Count digits in current number
            int digitCount = stringedInt.Length;

            // B. Recurse until last digit found
            if (stringedInt.Length > 1)
            {
                recursiveDigitizerPrinter(stringedInt.Substring(0, digitCount - 1));
            }

            // C. Find location of the last digit and set the value aside for printing later
            String lastChar = findLastDigit(stringedInt, digitCount);

            // D. Print the digit
            Console.WriteLine(lastChar + " ");

        }

        private String findLastDigit(String recursiveIntString, int digitCount)
        {
            String lastChar;
            if (digitCount == 1)
            {
                lastChar = recursiveIntString.Substring(0);
            }
            else
            {
                lastChar = recursiveIntString.Substring(digitCount - 1);
            }

            return lastChar;
        }
    }
}
