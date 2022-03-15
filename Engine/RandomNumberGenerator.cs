using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Engine
{
    //complex Random Number Generator
    public static class RandomNumberGenerator
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static int NumberBetween(int minimumValue, int maximumValue)
        {
            byte[] randomNumber = new byte[1];

            _generator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            //Using Math.Max and subtracting 0.00000000001, to ensure multiplier will always be between 0.0 and .9999999999 otherwise it's possible for it to be 1 which causes problems in rounding

            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

            //Add one to the range, to allow for rounding done with Math.Floor
            int range = maximumValue - minimumValue +1;

            double randomValueinRange = Math.Floor(multiplier * range);

            return (int)(minimumValue + randomValueinRange);
        }

        //simple Number between

        //private static readonly Random _simpleGenerator = new Random();
        //public static int SimpleNumberBetween(int minimumValue, int maximumValue)
        //{
        //    return _simpleGenerator.Next(minimumValue, maximumValue);
        //}
    }
}
