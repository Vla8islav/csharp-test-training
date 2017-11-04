using FileHelpers;

namespace addressbook_web_tests
{
    [DelimitedRecord(","), IgnoreFirst, IgnoreEmptyLines]
    public class ContactDataCsv
    {
        public int? Id { get; set; }
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
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string TestObjectInstanceName { get; set; }

        public ContactData ContactData()
        {
            return new ContactData
            {
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