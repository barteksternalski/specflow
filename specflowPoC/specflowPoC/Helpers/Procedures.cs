using System;
using System.Security.Cryptography;
using System.Text;

namespace specflowPoC.Helpers
{
    class Procedures
    {
        public static String GenerateRandomizedStringWithLength(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        public static double GetRandomNumber(double minimum, double maximum, int decimalPoints)
        {

            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[4];
            provider.GetBytes(byteArray);

            Random random = new Random(BitConverter.ToInt32(byteArray, 0));
            return System.Math.Round(random.NextDouble() * (maximum - minimum) + minimum, decimalPoints);
        }
    }
}
