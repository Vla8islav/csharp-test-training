using System;

namespace addressbook_web_tests
{
    public class ContactData : ModelBase, IComparable<ContactData>
    {
        public CheckResult Compare(ContactData otherContactData)
        {
            if (null == otherContactData)
            {
                otherContactData = new ContactData()
                {
                    FirstName = null,
                    MiddleName = null,
                    LastName = null,
                    Nickname = null,
                    Photo = null,
                    Title = null,
                    Company = null,
                    Address = null,
                    Telephone = null,
                    Home = null,
                    Mobile = null,
                    Work = null,
                    Fax = null,
                    EMail = null,
                    EMail2 = null,
                    EMail3 = null,
                    Homepage = null,
                    Birthday = null,
                    Anniversary = null,
                    Group = null,
                    Secondary = null,
                    SecondaryAddress = null,
                    SecondaryHome = null,
                    Notes = null,
                };
            }

            CheckResult retval = new CheckResult();
            ObjectComparePrinter comparePrinter = new ObjectComparePrinter("GroupData");

            comparePrinter.AddPairOfValues("FirstName", otherContactData.FirstName, FirstName);
            comparePrinter.AddPairOfValues("MiddleName", otherContactData.MiddleName, MiddleName);
            comparePrinter.AddPairOfValues("LastName", otherContactData.LastName, LastName);
            comparePrinter.AddPairOfValues("Nickname", otherContactData.Nickname, Nickname);
            comparePrinter.AddPairOfValues("Photo", otherContactData.Photo, Photo);
            comparePrinter.AddPairOfValues("Title", otherContactData.Title, Title);
            comparePrinter.AddPairOfValues("Company", otherContactData.Company, Company);
            comparePrinter.AddPairOfValues("Address", otherContactData.Address, Address);
            comparePrinter.AddPairOfValues("Telephone", otherContactData.Telephone, Telephone);
            comparePrinter.AddPairOfValues("Home", otherContactData.Home, Home);
            comparePrinter.AddPairOfValues("Mobile", otherContactData.Mobile, Mobile);
            comparePrinter.AddPairOfValues("Work", otherContactData.Work, Work);
            comparePrinter.AddPairOfValues("Fax", otherContactData.Fax, Fax);
            comparePrinter.AddPairOfValues("EMail", otherContactData.EMail, EMail);
            comparePrinter.AddPairOfValues("EMail2", otherContactData.EMail2, EMail2);
            comparePrinter.AddPairOfValues("EMail3", otherContactData.EMail3, EMail3);
            comparePrinter.AddPairOfValues("Homepage", otherContactData.Homepage, Homepage);
            comparePrinter.AddPairOfValues("Birthday", otherContactData.Birthday, Birthday);
            comparePrinter.AddPairOfValues("Anniversary", otherContactData.Anniversary, Anniversary);
            comparePrinter.AddPairOfValues("Group", otherContactData.Group, Group);
            comparePrinter.AddPairOfValues("Secondary", otherContactData.Secondary, Secondary);
            comparePrinter.AddPairOfValues("SecondaryAddress", otherContactData.SecondaryAddress, SecondaryAddress);
            comparePrinter.AddPairOfValues("SecondaryHome", otherContactData.SecondaryHome, SecondaryHome);
            comparePrinter.AddPairOfValues("Notes", otherContactData.Notes, Notes);

            retval.Message = comparePrinter.PrintListOfPropertiesSideBySide();
            retval.Result = IsValidContactDataEqual(otherContactData);
            return retval;
        }

        private bool IsValidContactDataEqual(ContactData otherContactData)
        {
            bool retval = true;

            retval &= CompareStringsNullFriendly(otherContactData.FirstName, FirstName);
//            retval &= CompareStringsNullFriendly(otherContactData.MiddleName, MiddleName);
            retval &= CompareStringsNullFriendly(otherContactData.LastName, LastName);
//            retval &= CompareStringsNullFriendly(otherContactData.Nickname, Nickname);
//            retval &= CompareStringsNullFriendly(otherContactData.Photo, Photo);
//            retval &= CompareStringsNullFriendly(otherContactData.Title, Title);
//            retval &= CompareStringsNullFriendly(otherContactData.Company, Company);
            retval &= CompareStringsNullFriendly(otherContactData.Address, Address);
            retval &= CompareStringsNullFriendly(otherContactData.Telephone, Telephone);
//            retval &= CompareStringsNullFriendly(otherContactData.Home, Home);
//            retval &= CompareStringsNullFriendly(otherContactData.Mobile, Mobile);
//            retval &= CompareStringsNullFriendly(otherContactData.Work, Work);
//            retval &= CompareStringsNullFriendly(otherContactData.Fax, Fax);
            retval &= CompareStringsNullFriendly(otherContactData.EMail, EMail);
//            retval &= CompareStringsNullFriendly(otherContactData.EMail2, EMail2);
//            retval &= CompareStringsNullFriendly(otherContactData.EMail3, EMail3);
//            retval &= CompareStringsNullFriendly(otherContactData.Homepage, Homepage);
//            retval &= CompareStringsNullFriendly(otherContactData.Birthday, Birthday);
//            retval &= CompareStringsNullFriendly(otherContactData.Anniversary, Anniversary);
//            retval &= CompareStringsNullFriendly(otherContactData.Group, Group);
//            retval &= CompareStringsNullFriendly(otherContactData.Secondary, Secondary);
//            retval &= CompareStringsNullFriendly(otherContactData.SecondaryAddress, SecondaryAddress);
//            retval &= CompareStringsNullFriendly(otherContactData.SecondaryHome, SecondaryHome);
//            retval &= CompareStringsNullFriendly(otherContactData.Notes, Notes);
              
            return retval;
        }
        
        public int CompareTo(ContactData otherContactData)
        {
            if (ReferenceEquals(otherContactData, null))
            {
                return 1;
            }
            int firstNameComparsion = String.Compare(FirstName, otherContactData.FirstName, StringComparison.Ordinal);
            if (firstNameComparsion != 0)
            {
                return firstNameComparsion;
            }
            
            int lastNameComparsion = String.Compare(LastName, otherContactData.LastName, StringComparison.Ordinal);
            if (lastNameComparsion != 0)
            {
                return lastNameComparsion;
            }
            
            
            return String.Compare(EMail, otherContactData.EMail, StringComparison.Ordinal);;
        }
        
        public new bool Equals(ContactData otherContactData)
        {
            if (ReferenceEquals(otherContactData, null))
            {
                return false;
            }
            if (ReferenceEquals(this, otherContactData))
            {
                return true;
            }
            
            return IsValidContactDataEqual(otherContactData);
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Fax { get; set; }
        public string EMail { get; set; }
        public string EMail2 { get; set; }
        public string EMail3 { get; set; }
        public string Homepage { get; set; }
        public string Birthday { get; set; }
        public string Anniversary { get; set; }
        public string Group { get; set; }
        public string Secondary { get; set; }
        public string SecondaryAddress { get; set; }
        public string SecondaryHome { get; set; }
        public string Notes { get; set; }
    }
}