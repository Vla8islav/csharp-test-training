using System;

namespace addressbook_web_tests
{
    public class GroupData : ModelBase, IComparable<GroupData>
    {

        public string GroupName { get; set; } = null;

        public string GroupHeader { get; set; } = null;

        public string GroupFooter { get; set; } = null;

        public new bool Equals(GroupData otherGroupData)
        {
            if (ReferenceEquals(otherGroupData, null))
            {
                return false;
            }
            if (ReferenceEquals(this, otherGroupData))
            {
                return true;
            }
            
            return IsValidGroupDataEqual(otherGroupData);
        }

        private bool IsValidGroupDataEqual(GroupData otherGroupData)
        {
            bool retval = true;
            retval &= CompareHelper.CompareValuesNullFriendly(otherGroupData.GroupName, GroupName);
            retval &= CompareHelper.CompareValuesNullFriendly(otherGroupData.GroupHeader, GroupHeader);
            retval &= CompareHelper.CompareValuesNullFriendly(otherGroupData.GroupFooter, GroupFooter);
            return retval;
        }

        public CheckResult Compare(GroupData otherGroupData)
        {
            if (null == otherGroupData)
            {
                otherGroupData = new GroupData
                {
                    GroupFooter = null,
                    GroupHeader = null,
                    GroupName = null
                };
            }

            CheckResult retval = new CheckResult();
            ObjectComparePrinter comparePrinter = new ObjectComparePrinter("GroupData");
            comparePrinter.AddPairOfValuesDiff("GroupName", otherGroupData.GroupName, GroupName);
            comparePrinter.AddPairOfValuesDiff("GroupHeader", otherGroupData.GroupHeader, GroupHeader);
            comparePrinter.AddPairOfValuesDiff("GroupFooter", otherGroupData.GroupFooter, GroupFooter);
            retval.Message = comparePrinter.PrintListOfPropertiesSideBySide();
            retval.Result = IsValidGroupDataEqual(otherGroupData);
            return retval;
        }

        public override int GetHashCode()
        {
            return GroupName.GetHashCode() + GroupHeader.GetHashCode() + GroupFooter.GetHashCode();
        }

        public int CompareTo(GroupData otherGroupData)
        {
            if (ReferenceEquals(otherGroupData, null))
            {
                return 1;
            }
            return String.Compare(GroupName, otherGroupData.GroupName, StringComparison.Ordinal);
        }
        
    }
}