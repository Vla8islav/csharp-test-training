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
    }
}