using System;

namespace addressbook_web_tests
{
    public class ModelBase : IEquatable<GroupData>
    {
        public bool Equals(GroupData otherGroupData)
        {
            if (ReferenceEquals(otherGroupData, null))
            {
                return false;
            }
            if (ReferenceEquals(this, otherGroupData))
            {
                return true;
            }
            
            return true;
        }

        protected static bool CompareStringsNullFriendly(string firstString, string secondString)
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