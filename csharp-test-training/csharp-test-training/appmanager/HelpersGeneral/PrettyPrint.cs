namespace addressbook_web_tests
{
    public class PrettyPrint
    {
        public static string printTwoNamedStrings(string elementName, string propertyValueFirst, string propertyValueSecond)
        {
            return $"{printWithNull(elementName)}:\t'{printWithNull(propertyValueFirst)}'\t'{printWithNull(propertyValueSecond)}'\n";
        }

        public static string printWithNull(string s)
        {
            if (null == s)
            {
                return "null";
            }
            return s;
        }

        public static bool CompareStringsNullFriendly(string firstString, string secondString)
        {
            if (null == firstString || null == secondString)
            {
                if (null == firstString && null == secondString)
                    // TODO: This looks like a bad workaround, but let it suffice for a while. Don't know != Don't know
                {
                    return true;
                }
                return false;
            }

            return firstString.Equals(secondString);
        }
    }
}