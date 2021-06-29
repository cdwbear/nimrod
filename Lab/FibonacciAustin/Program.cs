using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciAustin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an integer value > 0:  ");
            var inputV = Console.ReadLine();
            int fNumber = 0;
            //if (Int32.TryParse(args[0], out fNumber))
            if (Int32.TryParse(inputV, out fNumber))
            {
                    FibRunner fr = new FibRunner(fNumber);
                    
                    Console.WriteLine("The " + fNumber + fr.getnSuffix() + " value in the Fibonacci series is " +
                                  fr.getNthValue() + ".");
            }
        }
    }

}

public class FibRunner
{
    private int n;
    private int nthValue;
    private string nSuffix;

    public FibRunner(int n)
    {
        this.n = n;
        this.nthValue = fibFinder(n);
        this.nSuffix = nSuffixFinder(n);
    }

    private int fibFinder(int placeToFind)
    {
        if (placeToFind == 1)
        {
            return 0;
        }
        else
        {
            return fibRecurser(0, 1, 2);
        }
    }

    private int fibRecurser(int a, int b, int currPlace)
    {
        if (currPlace == this.n)
        {
            return b;
        }
        else
        {
            return fibRecurser(b, a + b, currPlace + 1);
        }
    }

    private string nSuffixFinder(int n)
    {
        var nString = n.ToString();
        var lastDigit = nString.Substring((nString.Length - 1));
        switch (lastDigit)
        {
            case "1":
                return "st";
            case "2":
                return "rd";
            default:
                return "th";
        }
    }

    public int getNthValue()
    {
        return nthValue;
    }

    public string getnSuffix()
    {
        return nSuffix;
    }

}
