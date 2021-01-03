using System;
using System.Linq;

namespace IQSoft.eCommerce.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string RandomString(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray()).ToLower();
        }
    }
}
