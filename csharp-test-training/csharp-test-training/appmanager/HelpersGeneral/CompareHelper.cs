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
                if (null == e1 && null == e2)
                    // TODO: This looks like a bad workaround, but let it suffice for a while. Don't know != Don't know
                {
                    return true;
                }
                return false;
            }

            return e1.Equals(e2);
        }
    }
}