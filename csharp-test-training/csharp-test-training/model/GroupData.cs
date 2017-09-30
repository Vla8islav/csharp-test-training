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
            retval &= CompareStringsNullFriendly(otherGroupData.GroupName, GroupName);
            retval &= CompareStringsNullFriendly(otherGroupData.GroupHeader, GroupHeader);
            retval &= CompareStringsNullFriendly(otherGroupData.GroupFooter, GroupFooter);
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
            retval.Message += PrintElements("GroupName", otherGroupData.GroupName, GroupName);
            retval.Message += PrintElements("GroupHeader", otherGroupData.GroupHeader, GroupHeader);
            retval.Message += PrintElements("GroupFooter", otherGroupData.GroupFooter, GroupFooter);
            retval.Result = IsValidGroupDataEqual(otherGroupData);
            return retval;
        }

        private string PrintElements(string elementName, string propertyValueFirst, string propertyValueSecond)
        {
            return $"{printWithNull(elementName)}:\t'{printWithNull(propertyValueFirst)}'\t'{printWithNull(propertyValueSecond)}'\n";
        }

        private bool CompareStringsNullFriendly(string firstString, string secondString)
        {
            if (null == firstString || null == secondString)
            {
                return false;
            }

            return firstString.Equals(secondString);
        }

        private string printObjectData()
        {
            string retval = "";
            retval += $"Group name is '{printWithNull(GroupName)}'\n";
            retval += $"Group header is '{printWithNull(GroupHeader)}'\n";
            retval += $"Group footer is '{printWithNull(GroupFooter)}'\n";
            return retval;
        }

        private string printWithNull(string s)
        {
            if (null == s)
            {
                return "null";
            }
            else
            {
                return s;
            }
        }
    }
}