using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using FileHelpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace addressbook_web_tests
{
    public class ContactFactory : DataFactoryBase
    {
        public static ContactData GetSampleContactData()
        {
            return GetContactDataByInstanceNameFromJson("Default contact data");
        }

        public static ContactData GetContactDataWithUniqueValues()
        {
            return GetContactDataByInstanceNameFromJson("Contact data with unique values");
        }

        private static List<ContactData> _contactsFromFile;

        private static ContactData GetContactDataByInstanceNameFromXml(string instanceName)
        {
            return GetContactsFromFileXml().First(c => c.TestObjectInstanceName == instanceName);
        }

        private static ContactData GetContactDataByInstanceNameFromJson(string instanceName)
        {
            return GetContactsFromFileJson().First(c => c.TestObjectInstanceName == instanceName);
        }
        
        private static ContactData GetContactDataByInstanceNameFromCsv(string instanceName)
        {
            return GetContactsFromFileCsv().First(c => c.TestObjectInstanceName == instanceName);
        }

        private static List<ContactData> GetContactsFromFileXml()
        {
            if (null == _contactsFromFile)
            {
                _contactsFromFile = GetObjectFromFileXml<ContactData>("Contacts.xml");
            }
            return _contactsFromFile;
        }

        private static List<ContactData> GetContactsFromFileJson()
        {
            if (null == _contactsFromFile)
            {
                _contactsFromFile = GetObjectFromFileJson<ContactData>("Contacts.json");
            }
            return _contactsFromFile;
        }
        
        private static List<ContactData> GetContactsFromFileCsv()
        {
            if (null == _contactsFromFile)
            {
                _contactsFromFile = new List<ContactData>();
                var engine = new FileHelperEngine<ContactDataCsv>();
                var contactsFromFileCsv =
                    new List<ContactDataCsv>(engine.ReadFile(HelperBase.GetDataFileFullPath("Contacts.csv")));
                foreach (var contactDataCsv in contactsFromFileCsv)
                {
                    _contactsFromFile.Add(contactDataCsv.ContactData());
                }
            }
            return _contactsFromFile;
        }
    }
}