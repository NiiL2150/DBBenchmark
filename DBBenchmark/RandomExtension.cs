using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBenchmark
{
    internal static class RandomExtension
    {
        public static string NextString(this Random random, int minLength = 5, int maxLength = 10)
        {
            int length = random.Next(minLength, maxLength);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static DateTime NextDateTime(this Random random)
        {
            DateTime today = DateTime.Now;
            int randomYear = random.Next(1980, today.Year);
            int randomMonth = random.Next(1, 12);
            int randomDay = random.Next(1, 28);
            return new DateTime(randomYear, randomMonth, randomDay);
        }
    }
}
