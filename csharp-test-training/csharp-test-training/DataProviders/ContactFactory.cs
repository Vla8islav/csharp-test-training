using System;
using System.Collections.Generic;
using System.Linq;
using FileHelpers;

namespace addressbook_web_tests
{
    public class ContactFactory
    {
        static private List<ContactDataCsv> _contactsFromFile;

        private static List<ContactDataCsv> GetContactsFromFile()
        {
            if (null == _contactsFromFile)
            {
                var engine = new FileHelperEngine<ContactDataCsv>();
                _contactsFromFile = new List<ContactDataCsv>(engine.ReadFile(HelperBase.GetDataFileFullPath("Contacts.csv")));
            }
            return _contactsFromFile;
        }

        public static ContactData GetSampleContactData()
        {
            return GetContactsFromFile().First(c => c.Nickname == "Default contact data").ContactData();
        }

        public static ContactData GetContactDataWithUniqueValues()
        {
            return GetContactsFromFile().First(c => c.Nickname == "Contact data with unique values").ContactData();
        }

        private static void WritePregeneratedContactData(string fileName)
        {
            var engine = new FileHelperEngine<ContactDataCsv>();

            List<ContactDataCsv> contacts = new List<ContactDataCsv>();
            contacts.Add(new ContactDataCsv
            {
                FirstName = $"TestName{StringGenerator.RandomString()}",
                MiddleName = $"TestMiddleName{StringGenerator.RandomString()}",
                LastName = $"TestLastName{StringGenerator.RandomString()}",
                Address = $"{StringGenerator.RandomString()}",
                TelephoneHome = $"{StringGenerator.RandomString()}",
                EMail = $"{StringGenerator.RandomString()}",
                Nickname = "Default contact data"
            });
            contacts.Add(new ContactDataCsv
            {
                FirstName = "TestName" + DateTime.Now,
                MiddleName = "TestMiddleName" + DateTime.Now,
                LastName = "TestLastName" + DateTime.Now,
                Address = "",
                TelephoneHome = "",
                EMail = "" + DateTime.Now,
                Nickname = "Contact data with unique values"
            });
            contacts.Add(new ContactDataCsv
            {
                FirstName = "FirstName",
                MiddleName = "MiddleName",
                LastName = "LastName",
                Nickname = "Nickname",
                Photo = "Photo",
                Title = "Title",
                Company = "Company",
                Address = "Address",
                TelephoneHome = "TelephoneHome",
                TelephoneMobile = "TelephoneMobile",
                TelephoneWork = "TelephoneWork",
                TelephoneFax = "TelephoneFax",
                EMail = "EMail",
                EMail2 = "EMail2",
                EMail3 = "EMail3",
                Homepage = "Homepage",
                Birthday = "Birthday",
                Anniversary = "Anniversary",
                Group = "Group",
                Secondary = "Secondary",
                SecondaryAddress = "SecondaryAddress",
                SecondaryHome = " SecondaryHome",
                Notes = "Notes",
                TestObjectInstanceName = "TestObjectInstanceName"
            });

            engine.WriteFile(HelperBase.GetDataFileFullPath(fileName), contacts);
        }
    }
}