
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using addressbook_web_tests;
using FileHelpers;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WritePregeneratedContactData();
        }

                
        private static void WritePregeneratedContactData()
        {

            List<ContactData> contacts
                = new List<ContactData>();
           
            contacts.Add(new ContactData
            {
                FirstName = $"TestName{StringGenerator.RandomString()}",
                MiddleName = $"TestMiddleName{StringGenerator.RandomString()}",
                LastName = $"TestLastName{StringGenerator.RandomString()}",
                Address = $"{StringGenerator.RandomString()}",
                TelephoneHome = $"{StringGenerator.RandomString()}",
                EMail = $"{StringGenerator.RandomString()}",
                TestObjectInstanceName = "Default contact data"
            });
            contacts.Add(new ContactData
            {
                FirstName = "TestName" + DateTime.Now,
                MiddleName = "TestMiddleName" + DateTime.Now,
                LastName = "TestLastName" + DateTime.Now,
                Address = "",
                TelephoneHome = "",
                EMail = DateTime.Now.ToString(),
                TestObjectInstanceName = "Contact data with unique values"
            });
           
            WriteToCsv(contacts);
            WriteToXml(contacts);
            WriteToJson(contacts);
        }

        private static void WriteToCsv(List<ContactData> contacts)
        {
            List<ContactDataCsv> contactsCsv = new List<ContactDataCsv>();
            foreach (var contact in contacts)
            {
                contactsCsv.Add(new ContactDataCsv(contact));
            }
            WriteToCsv(contactsCsv);
        }
        
        private static void WriteToCsv(List<ContactDataCsv> contacts)
        {
            string fileName = "Contacts.csv";
            contacts.Insert(0, new ContactDataCsv
            {
                Id = "Id",
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
            

            var engine = new FileHelperEngine<ContactDataCsv>();
            engine.WriteFile(HelperBase.GetDataFileFullPath(fileName), contacts);
        }
        
        private static void WriteToXml(List<ContactData> contacts)
        {
            using (StreamWriter writer =
                new StreamWriter(HelperBase.GetDataFileFullPath("Contacts.xml")))
            {
                new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
            }
        }
        
        private static void WriteToJson(List<ContactData> contacts)
        {
            using (StreamWriter writer =
                new StreamWriter(HelperBase.GetDataFileFullPath("Contacts.json")))
            {
                writer.Write(JsonHelper.PrettyPrintJson(JsonConvert.SerializeObject(contacts)));
            }
        }
    }
}