using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using LinqToDB;
using LinqToDB.Mapping;
using LinqToDB.SqlQuery;

namespace addressbook_web_tests
{
    [Table(Name = "addressbook")]
    public class ContactData : ModelWithId, IComparable<ContactData>
    {
        public List<GroupData> GetGroups()
        {
            using (AddressBookDb aBookDb = new AddressBookDb())
            {
                return (from g in aBookDb.Groups
                    from gcr in aBookDb.Gcr.Where(p => p.ContactId == Id && p.GroupId == g.Id)
                    select g).ToList();
            }
        }

        public static List<ContactData> GetAllContacts()
        {
            AddressBookDb db = new AddressBookDb();
            return (from c in db.Contacts
                select c).ToList();
        }

        public static List<ContactData> GetAllActiveContacts()
        {
            DateTime nullEquivalentOfDateTime = new DateTime();
            return GetAllContacts().FindAll(c => c.Deprecated == nullEquivalentOfDateTime);
        }

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

        public string ViewFormString
        {
            get
            {
                string displayedName = FirstName;
                if (!string.IsNullOrEmpty(MiddleName))
                {
                    displayedName += $" {MiddleName}";
                }
                if (!string.IsNullOrEmpty(LastName))
                {
                    displayedName += $" {LastName}";
                }

                displayedName = ConcatenanateStringsNewline(new List<string>
                {
                    displayedName,
                    Nickname,
                    Title,
                    Company,
                    Address,
                    String.IsNullOrEmpty(TelephoneHome) ? null : $"H: {TelephoneHome}",
                    String.IsNullOrEmpty(TelephoneMobile) ? null : $"M: {TelephoneMobile}",
                    String.IsNullOrEmpty(TelephoneWork) ? null : $"W: {TelephoneWork}",
                    String.IsNullOrEmpty(TelephoneFax) ? null : $"F: {TelephoneFax}",
                    EMailString,
                    String.IsNullOrEmpty(Homepage) ? null : "Homepage:",
                    Homepage
                });

                var currentContactGroups = GetGroups();
                if (currentContactGroups != null && currentContactGroups.Count > 0)
                {
                    displayedName += "Member of: ";
                    foreach (var group in currentContactGroups)
                    {
                        displayedName += group.Name;
                    }
                }

                return displayedName;
            }
        }

        [Column(Name = "id"), PrimaryKey, Identity]
        public override int? Id { get; set; }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "middlename")]
        public string MiddleName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        public string Nickname { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }
        private string _telephoneString;
        private string _telephoneHome;
        private string _telephoneMobile;
        private string _telephoneWork;
        private string _telephoneFax;

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

        [Column(Name = "home")]
        public string TelephoneHome
        {
            get { return _telephoneHome; }
            set
            {
                _telephoneString = null;
                _telephoneHome = value;
            }
        }

        [Column(Name = "mobile")]
        public string TelephoneMobile
        {
            get { return _telephoneMobile; }
            set
            {
                _telephoneString = null;
                _telephoneMobile = value;
            }
        }

        [Column(Name = "work")]
        public string TelephoneWork
        {
            get { return _telephoneWork; }
            set
            {
                _telephoneString = null;
                _telephoneWork = value;
            }
        }

        [Column(Name = "fax")]
        public string TelephoneFax
        {
            get { return _telephoneFax; }
            set
            {
                _telephoneString = null;
                _telephoneFax = value;
            }
        }

        private string _eMailString = null;
        private string _eMail = null;
        private string _eMail2 = null;
        private string _eMail3 = null;

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

        [Column(Name = "email")]
        public string EMail
        {
            get { return _eMail; }
            set
            {
                _eMailString = null;
                _eMail = value;
            }
        }

        [Column(Name = "email2")]
        public string EMail2
        {
            get { return _eMail2; }
            set
            {
                _eMailString = null;
                _eMail2 = value;
            }
        }

        [Column(Name = "email3")]
        public string EMail3
        {
            get { return _eMail3; }
            set
            {
                _eMailString = null;
                _eMail3 = value;
            }
        }

        public string Homepage { get; set; }
        public string Birthday { get; set; }
        public string Anniversary { get; set; }
        public string Group { get; set; }
        public string Secondary { get; set; }
        public string SecondaryAddress { get; set; }
        public string SecondaryHome { get; set; }
        public string Notes { get; set; }

        [Column(Name = "deprecated")]
        public DateTime? Deprecated { get; set; }


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