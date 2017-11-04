using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using FileHelpers;
using Newtonsoft.Json;
using NUnit.Framework.Constraints;

namespace addressbook_web_tests
{
    public class ContactFactory
    {

        public static ContactData GetSampleContactData()
        {
            return GetContactDataByInstanceNameFromJson("Default contact data");
        }

        public static ContactData GetContactDataWithUniqueValues()
        {
            return GetContactDataByInstanceNameFromJson("Contact data with unique values");
        }

        private static ContactData GetContactDataByInstanceNameFromXml(string instanceName)
        {
            return GetContactsFromFileXml().First(c => c.TestObjectInstanceName == instanceName);
        }
        
        private static ContactData GetContactDataByInstanceNameFromJson(string instanceName)
        {
            return GetContactsFromFileJson().First(c => c.TestObjectInstanceName == instanceName);
        }
        
        static private List<ContactData> _contactsFromFile;

        private static List<ContactData> GetContactsFromFileCsv()
        {
            if (null == _contactsFromFile)
            {
                _contactsFromFile = new List<ContactData>();
                var engine = new FileHelperEngine<ContactDataCsv>();
                var contactsFromFileCsv = new List<ContactDataCsv>(engine.ReadFile(HelperBase.GetDataFileFullPath("Contacts.csv")));
                foreach (var contactDataCsv in contactsFromFileCsv)
                {
                    _contactsFromFile.Add(contactDataCsv.ContactData()); 
                }
            }
            
            return _contactsFromFile;
        }
        
        private static List<ContactData> GetContactsFromFileXml()
        {
            if (null == _contactsFromFile)
            {
                _contactsFromFile = new List<ContactData>();
                using (StreamReader reader =
                    new StreamReader(HelperBase.GetDataFileFullPath("Contacts.xml")))
                {
                    _contactsFromFile = (List<ContactData>) new XmlSerializer(typeof(List<ContactData>)).Deserialize(reader);
                }                    
            }
            
            return _contactsFromFile;
        }

        private static List<ContactData> GetContactsFromFileJson()
        {
            if (null == _contactsFromFile)
            {
                _contactsFromFile = new List<ContactData>();
                using (StreamReader reader =
                    new StreamReader(HelperBase.GetDataFileFullPath("Contacts.json")))
                {
                    _contactsFromFile = (List<ContactData>) JsonConvert.DeserializeObject(reader.ReadToEnd());
                }                    
            }
            
            return _contactsFromFile;
        }
    }
}