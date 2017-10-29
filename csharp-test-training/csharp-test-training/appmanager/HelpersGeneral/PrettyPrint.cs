namespace addressbook_web_tests
{
    public class PrettyPrint
    {
        public static string PrintTwoNamedStrings(string elementName, string propertyValueFirst, string propertyValueSecond)
        {
            return $"{PrintWithNull(elementName)}:\t'{PrintWithNull(propertyValueFirst)}'\t'{PrintWithNull(propertyValueSecond)}'\n";
        }

        public static string PrintWithNull(string s)
        {
            if (null == s)
            {
                return "null";
            }
            return s;
        }
        
        public static string PrintWithNull<T>(T s)
        {
            if (null == s)
            {
                return "null";
            }
            return s.ToString();
        }

        public static string CleanSpecialCharacters(string s)
        {
            if (null == s)
            {
                return "";
            }
            return s.Replace("\n", "").Replace("\r", "");
        }
       
    }
}