using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmHomework.Helpers
{
    internal static class RNDNumbers
    {
        private static readonly Random _random = new Random();

        public static string Make_RND_Number(int length, StringType type)
        {
            string str = type switch
            {
                StringType.Numeric => "0123456789",
                StringType.Alpha => "abcdefghijklmnopqrstuvwxyz",
                _ => throw new Exception()
            };

            var result = string.Empty;
            for (int i = 0; i < length; i++)
            {
                result += str[_random.Next(0, str.Length)];
            }

            return result;
        }
    }
}
