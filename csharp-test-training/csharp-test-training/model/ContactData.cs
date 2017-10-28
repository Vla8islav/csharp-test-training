using System;
using System.Collections.Generic;

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
                    Id = null,
                    FirstName = null,
                    MiddleName = null,
                    LastName = null,
                    Nickname = null,
                    Photo = null,
                    Title = null,
                    Company = null,
                    Address = null,
                    TelephoneHome = null,
                    TelephoneMobile = null,
                    TelephoneWork = null,
                    TelephoneFax = null,
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

            comparePrinter.AddPairOfValuesDiff("Id", otherContactData.Id, Id);
            comparePrinter.AddPairOfValuesDiff("FirstName", otherContactData.FirstName, FirstName);
            comparePrinter.AddPairOfValuesDiff("MiddleName", otherContactData.MiddleName, MiddleName);
            comparePrinter.AddPairOfValuesDiff("LastName", otherContactData.LastName, LastName);
            comparePrinter.AddPairOfValuesDiff("Nickname", otherContactData.Nickname, Nickname);
            comparePrinter.AddPairOfValuesDiff("Photo", otherContactData.Photo, Photo);
            comparePrinter.AddPairOfValuesDiff("Title", otherContactData.Title, Title);
            comparePrinter.AddPairOfValuesDiff("Company", otherContactData.Company, Company);
            comparePrinter.AddPairOfValuesDiff("Address", otherContactData.Address, Address);
            comparePrinter.AddPairOfValuesDiff("TelephoneString", otherContactData.TelephoneString, TelephoneString);
//            comparePrinter.AddPairOfValuesDiff("TelephoneHome", otherContactData.TelephoneHome, TelephoneHome);
//            comparePrinter.AddPairOfValuesDiff("TelephoneMobile", otherContactData.TelephoneMobile, TelephoneMobile);
//            comparePrinter.AddPairOfValuesDiff("TelephoneWork", otherContactData.TelephoneWork, TelephoneWork);
            comparePrinter.AddPairOfValuesDiff("TelephoneFax", otherContactData.TelephoneFax, TelephoneFax);
            comparePrinter.AddPairOfValuesDiff("EMailString", otherContactData.EMailString, EMailString);
//            comparePrinter.AddPairOfValuesDiff("EMail", otherContactData.EMail, EMail);
//            comparePrinter.AddPairOfValuesDiff("EMail2", otherContactData.EMail2, EMail2);
//            comparePrinter.AddPairOfValuesDiff("EMail3", otherContactData.EMail3, EMail3);
            comparePrinter.AddPairOfValuesDiff("Homepage", otherContactData.Homepage, Homepage);
            comparePrinter.AddPairOfValuesDiff("Birthday", otherContactData.Birthday, Birthday);
            comparePrinter.AddPairOfValuesDiff("Anniversary", otherContactData.Anniversary, Anniversary);
            comparePrinter.AddPairOfValuesDiff("Group", otherContactData.Group, Group);
            comparePrinter.AddPairOfValuesDiff("Secondary", otherContactData.Secondary, Secondary);
            comparePrinter.AddPairOfValuesDiff("SecondaryAddress", otherContactData.SecondaryAddress, SecondaryAddress);
            comparePrinter.AddPairOfValuesDiff("SecondaryHome", otherContactData.SecondaryHome, SecondaryHome);
            comparePrinter.AddPairOfValuesDiff("Notes", otherContactData.Notes, Notes);

            retval.Message = comparePrinter.PrintListOfPropertiesSideBySide();
            retval.Result = IsValidContactDataEqual(otherContactData);
            if (!retval.Result)
            {
                int i = 0;
                i++;
            }
            return retval;
        }

        private bool IsValidContactDataEqual(ContactData otherContactData)
        {
            bool retval = true;

            retval &= CompareHelper.CompareValuesNullFriendly(otherContactData.Id, Id);
            retval &= CompareHelper.CompareValuesNullFriendly(otherContactData.FirstName, FirstName);
//            retval &= CompareStringsNullFriendly(otherContactData.MiddleName, MiddleName);
            retval &= CompareHelper.CompareValuesNullFriendly(otherContactData.LastName, LastName);
//            retval &= CompareStringsNullFriendly(otherContactData.Nickname, Nickname);
//            retval &= CompareStringsNullFriendly(otherContactData.Photo, Photo);
//            retval &= CompareStringsNullFriendly(otherContactData.Title, Title);
//            retval &= CompareStringsNullFriendly(otherContactData.Company, Company);
            retval &= CompareHelper.CompareValuesNullFriendly(otherContactData.Address, Address);
            retval &= CompareHelper.CompareValuesNullFriendly(otherContactData.TelephoneString, TelephoneString);
//            retval &= CompareStringsNullFriendly(otherContactData.Home, Home);
//            retval &= CompareStringsNullFriendly(otherContactData.Mobile, Mobile);
//            retval &= CompareStringsNullFriendly(otherContactData.Work, Work);
//            retval &= CompareStringsNullFriendly(otherContactData.Fax, Fax);
            retval &= CompareHelper.CompareValuesNullFriendly(otherContactData.EMailString, EMailString);
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

            if (Id.HasValue && otherContactData.Id.HasValue)
            {
                return Id.Value - otherContactData.Id.Value;
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


            return String.Compare(EMail, otherContactData.EMail, StringComparison.Ordinal);
            ;
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

        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        private string _telephoneString;

        public string TelephoneString
        {
            get
            {
                if (null == _telephoneString)
                {
                    _telephoneString = ConcatenanateStringsNewline(new List<string>
                    {
                        TelephoneHome,
                        TelephoneMobile,
                        TelephoneWork
                    });
                }
                return _telephoneString;
            }
            set { _telephoneString = value.Trim().Trim('\r').Trim('\n'); }
        }

        public string TelephoneHome { get; set; }
        public string TelephoneMobile { get; set; }
        public string TelephoneWork { get; set; }
        public string TelephoneFax { get; set; }
        private string _eMailString = null;

        public string EMailString
        {
            get
            {
                if (null == _eMailString)
                {
                    _eMailString = ConcatenanateStringsNewline(new List<string>
                    {
                        EMail,
                        EMail2,
                        EMail3
                    });
                }
                return _eMailString;
            }
            set { _eMailString = value.Trim().Trim('\r').Trim('\n'); }
        }

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

        private static string ConcatenanateStringsNewline(List<string> list)
        {
            string retval = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (!String.IsNullOrWhiteSpace(list[i]))
                {
                    retval += list[i].Trim();
                    retval += "\r\n";
                }
            }
            return retval.Trim('\n', '\r');

        }
    }
}