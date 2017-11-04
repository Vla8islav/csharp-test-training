using System;
using FileHelpers;

namespace addressbook_web_tests
{
    [DelimitedRecord(","), IgnoreFirst, IgnoreEmptyLines]
    public class ContactDataCsv
    {
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string TestObjectInstanceName { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Id { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string FirstName { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string MiddleName { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string LastName { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Nickname { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Photo { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Title { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Company { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Address { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string TelephoneHome { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string TelephoneMobile { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string TelephoneWork { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string TelephoneFax { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string EMail { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string EMail2 { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string EMail3 { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Homepage { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Birthday { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Anniversary { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Group { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Secondary { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string SecondaryAddress { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string SecondaryHome { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Notes { get; set; }

        public ContactDataCsv()
        {
        }

        public ContactDataCsv(ContactData c)
        {
            Id = c.Id.ToString();
            FirstName = c.FirstName;
            MiddleName = c.MiddleName;
            LastName = c.LastName;
            Nickname = c.Nickname;
            Photo = c.Photo;
            Title = c.Title;
            Company = c.Company;
            Address = c.Address;
            TelephoneHome = c.TelephoneHome;
            TelephoneMobile = c.TelephoneMobile;
            TelephoneWork = c.TelephoneWork;
            TelephoneFax = c.TelephoneFax;
            EMail = c.EMail;
            EMail2 = c.EMail2;
            EMail3 = c.EMail3;
            Homepage = c.Homepage;
            Birthday = c.Birthday;
            Anniversary = c.Anniversary;
            Group = c.Group;
            Secondary = c.Secondary;
            SecondaryAddress = c.SecondaryAddress;
            SecondaryHome = c.SecondaryHome;
            Notes = c.Notes;
            TestObjectInstanceName = c.TestObjectInstanceName;
        }

        public ContactData ContactData()
        {
            return new ContactData
            {
                Id = Int32.Parse(Id),
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                Nickname = Nickname,
                Photo = Photo,
                Title = Title,
                Company = Company,
                Address = Address,
                TelephoneHome = TelephoneHome,
                TelephoneMobile = TelephoneMobile,
                TelephoneWork = TelephoneWork,
                TelephoneFax = TelephoneFax,
                EMail = EMail,
                EMail2 = EMail2,
                EMail3 = EMail3,
                Homepage = Homepage,
                Birthday = Birthday,
                Anniversary = Anniversary,
                Group = Group,
                Secondary = Secondary,
                SecondaryAddress = SecondaryAddress,
                SecondaryHome = SecondaryHome,
                Notes = Notes,
                TestObjectInstanceName = TestObjectInstanceName
            };
        }
    }
}