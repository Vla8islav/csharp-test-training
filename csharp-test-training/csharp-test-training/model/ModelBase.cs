using System;

namespace addressbook_web_tests
{
    public class ModelBase : IEquatable<GroupData>
    {
        public string InstanceAlias { get; set; } = null;
        public new string ToString()
        {
            return InstanceAlias;
        }

        
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