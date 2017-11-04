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

    }
}