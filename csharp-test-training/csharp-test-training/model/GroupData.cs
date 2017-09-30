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
            
            return IsValidGroupDataEqual(otherGroupData);
        }

        private bool IsValidGroupDataEqual(GroupData otherGroupData)
        {
            bool retval = true;
            retval &= PrettyPrint.CompareStringsNullFriendly(otherGroupData.GroupName, GroupName);
            retval &= PrettyPrint.CompareStringsNullFriendly(otherGroupData.GroupHeader, GroupHeader);
            retval &= PrettyPrint.CompareStringsNullFriendly(otherGroupData.GroupFooter, GroupFooter);
            return retval;
        }

        public CheckResult Compare(GroupData otherGroupData)
        {
            CheckResult retval = new CheckResult();
            if (ReferenceEquals(otherGroupData, null))
            {
                retval.Message = "Current object " + printObjectData();
                retval.Result = false;
                retval.Message += "You're trying to compare GroupData to null \n";
                return retval;
            }
            if (ReferenceEquals(this, otherGroupData))
            {
                retval.Message = "Current object " + printObjectData();
                retval.Result = true;
                retval.Message += "You're trying to compare GroupData to itself \n";
                return retval;
            }
            retval.Message += PrettyPrint.printTwoNamedStrings("GroupName", otherGroupData.GroupName, GroupName);
            retval.Message += PrettyPrint.printTwoNamedStrings("GroupHeader", otherGroupData.GroupHeader, GroupHeader);
            retval.Message += PrettyPrint.printTwoNamedStrings("GroupFooter", otherGroupData.GroupFooter, GroupFooter);
            retval.Result = IsValidGroupDataEqual(otherGroupData);
            return retval;
        }

        private string printObjectData()
        {
            string retval = "";
            retval += $"Group name is '{PrettyPrint.printWithNull(GroupName)}'\n";
            retval += $"Group header is '{PrettyPrint.printWithNull(GroupHeader)}'\n";
            retval += $"Group footer is '{PrettyPrint.printWithNull(GroupFooter)}'\n";
            return retval;
        }

        public override int GetHashCode()
        {
            return GroupName.GetHashCode() + GroupHeader.GetHashCode() + GroupFooter.GetHashCode();
        }
    }
}