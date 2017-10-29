using System;
using System.Linq;

namespace addressbook_web_tests
{
    public class StringGenerator
    {
        // From https://stackoverflow.com/a/1344242
        private static Random random = new Random();
        private const int RandomStringSaltDefaultLength = 5;
        
        public static string RandomString()
        {
            return RandomString(RandomStringSaltDefaultLength);
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}