using LinqToDB.Extensions;

namespace addressbook_web_tests
{
    public class CompareHelper
    {
        public static bool CompareValuesNullFriendly(string e1, string e2)
        {
            return CompareValuesNullFriendly<string>(e1, e2);
        }

        public static bool CompareValuesNullFriendly(int? e1, int? e2)
        {
            return CompareValuesNullFriendly<int?>(e1, e2);
        }

        public static bool CompareValuesNullFriendly<T>(T e1, T e2)
        {
            if (null == e1 || null == e2)
            {
                string e1StringEquivalent = "", e2StringEquivalent = "";
                if (e1 != null)
                {
                    e1StringEquivalent = e1.ToString();
                }
                if (e2 != null)
                {
                    e2StringEquivalent = e2.ToString();
                }

                return e1StringEquivalent == e2StringEquivalent;
            }

            return e1.Equals(e2);
        }
    }
}