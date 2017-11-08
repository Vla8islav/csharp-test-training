using System;
using LinqToDB.Mapping;

namespace addressbook_web_tests
{
    [Table(Name = "group_list")]
    public class GroupData : ModelBase, IComparable<GroupData>
    {
        public GroupData()
        {
        }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public int? Id { get; set; } = null;

        [Column(Name = "group_name")]
        public string Name { get; set; } = null;

        [Column(Name = "group_header")]
        public string Header { get; set; } = null;

        [Column(Name = "group_footer")]
        public string Footer { get; set; } = null;

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
            retval &= CompareHelper.CompareValuesNullFriendly(otherGroupData.Id, Id);
            retval &= CompareHelper.CompareValuesNullFriendly(otherGroupData.Name, Name);
            retval &= CompareHelper.CompareValuesNullFriendly(otherGroupData.Header, Header);
            retval &= CompareHelper.CompareValuesNullFriendly(otherGroupData.Footer, Footer);
            return retval;
        }

        public CheckResult Compare(GroupData otherGroupData)
        {
            if (null == otherGroupData)
            {
                otherGroupData = new GroupData
                {
                    Footer = null,
                    Header = null
                };
            }

            CheckResult retval = new CheckResult();
            ObjectComparePrinter comparePrinter = new ObjectComparePrinter("GroupData");
            comparePrinter.AddPairOfValuesDiff("Id", otherGroupData.Id, Id);
            comparePrinter.AddPairOfValuesDiff("GroupName", otherGroupData.Name, Name);
            comparePrinter.AddPairOfValuesDiff("GroupHeader", otherGroupData.Header, Header);
            comparePrinter.AddPairOfValuesDiff("GroupFooter", otherGroupData.Footer, Footer);
            retval.Message = comparePrinter.PrintListOfPropertiesSideBySide();
            retval.Result = IsValidGroupDataEqual(otherGroupData);
            return retval;
        }

        public CheckResult CompareNames(GroupData otherGroupData)
        {
            if (null == otherGroupData)
            {
                otherGroupData = new GroupData
                {
                    Footer = null,
                    Header = null,
                    Name = null
                };
            }

            CheckResult retval = new CheckResult();
            ObjectComparePrinter comparePrinter = new ObjectComparePrinter("GroupData");
            comparePrinter.AddPairOfValuesDiff("GroupName", otherGroupData.Name, Name);
            retval.Message = comparePrinter.PrintListOfPropertiesSideBySide();
            retval.Result = CompareHelper.CompareValuesNullFriendly(otherGroupData.Name, Name);
            return retval;
        }


        public override int GetHashCode()
        {
            int retval = 0;
            if (Name != null)
            {
                retval += Name.GetHashCode();
            }
            if (Header != null)
            {
                retval += Header.GetHashCode();
            }
            if (Footer != null)
            {
                retval += Footer.GetHashCode();
            }
            if (Id != null)
            {
                retval += Id.GetHashCode();
            }
            return retval;
        }

        public int CompareTo(GroupData otherGroupData)
        {
            if (ReferenceEquals(otherGroupData, null))
            {
                return 1;
            }
            var i = Id - otherGroupData.Id;
            if (i != null) return (int) i;
            return 0;
        }
    }
}