using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NpiLibrary
{
    public class NpiEngine
    {

        // http://jsfiddle.net/alexdresko/cLNB6/
        public string GenerateNpi()
        {
            var randomizer = new Random();
            var randomNumber = Math.Floor((decimal)(randomizer.Next() * (999999999 - 100000000 + 1) + 100000000));

            var asdf = getNpiCheckDigit(randomNumber.ToString());

            return asdf.ToString();
        }

        public bool IsValidNpi(string npi)
        {
            return false;
        }

        private string getNpiCheckDigit(string npi9)
        {
            // var tmp;
            int sum = 0;

            var i = npi9.Length;
            if ((i == 14) && (npi9.IndexOf("80840", 0, 5) == 0))
            {
                sum = 0;
            }
            else if (i == 9)
            {
                sum = 24;
            }
            else
            {
                return "!";
            }

            int j = 1;
            while (j != 0)
            {

            }


            return string.Empty;
        }

        // http://www.touchoftechnology.com/npi-luhn-check-digit-calculation/
        private string getCheckDigit(string npi9)
        {
            string newNPI = string.Empty;

            string baseNpi = npi9;
            var count = 0;
            var newCount = 0;
            for (int i = baseNpi.Length - 1; i >= 0; i--)
            {
                if (count % 2 == 0)
                {
                    //var tempNum = baseNpi[0].GetTypeCode() * 2; //).charAt(i) * 2;
                    var tempNum = (int)baseNpi[0];
                    if (tempNum >= 10)
                    {
                        var tempRemainder = tempNum % 10;
                        newCount = newCount + tempRemainder + 1;
                    }
                    else
                    {
                        newCount = newCount + tempNum;
                    }
                }
                else
                {
                    newCount = newCount + baseNpi[i];  // parseInt(base.charAt(i));
                }
                count++;
            }

            newCount = newCount + 24;
            var newMod = (int)(newCount % 10);
            var checkDigit = (10 - newMod) % 10;
            newNPI = baseNpi + checkDigit;

            return newNPI;
        }
    }
}
