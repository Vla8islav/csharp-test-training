using System;

namespace addressbook_web_tests
{
    public class GroupData : IEquatable<GroupData>
    {

        public string GroupName { get; set; } = null;

        public string GroupHeader { get; set; } = null;

        public string GroupFooter { get; set; } = null;

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
            
            bool retval = true;

            retval &= otherGroupData.GroupName.Equals(GroupName);
//            retval &= otherGroupData.GroupHeader.Equals(GroupHeader);
//            retval &= otherGroupData.GroupFooter.Equals(GroupFooter);

            return retval;
        }
    }
}