
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
            WritePregeneratedGroupData();
        }

        private static void WritePregeneratedGroupData()
        {
            List<GroupData> groups = new List<GroupData>
            {
                new GroupData
                {
                    GroupName = "a'a",
                    GroupHeader = "Some group header",
                    GroupFooter = "Некоторый русский текст для разнообразия.",
                    TestObjectInstanceName = "NameWith ' symbol"
                },
                new GroupData
                {
                    GroupName = "Some new goup",
                    GroupHeader = "Some group header",
                    GroupFooter = null,
                    TestObjectInstanceName = "LeaveFooterIntact"
                },
                new GroupData
                {
                    GroupName = "",
                    GroupHeader = "",
                    GroupFooter = "",
                    TestObjectInstanceName = "EmptyGroup"
                },
                new GroupData
                {
                    GroupName = "Some new goup" + " modified",
                    GroupHeader = "Some group header" + " modified",
                    GroupFooter = "Некоторый русский текст для разнообразия." + " modified",
                    TestObjectInstanceName = "GroupForModification"
                              
                }
                
            };
            
            for (int i = 0; i < 3; i++)
            {
                groups.Add(new GroupData
                    {
                        GroupName = $"Some new goup {StringGenerator.RandomString()}",
                        GroupHeader = $"Some group header {StringGenerator.RandomString()}",
                        GroupFooter = $"Некоторый русский текст для разнообразия. {StringGenerator.RandomString()}",
                        TestObjectInstanceName = $"RandomString_{i}"
                    });  
            }
            
            WriteToJson("Groups.json", groups);
            WriteToXml<GroupData>("Groups.xml", groups);
        }


        private static void WritePregeneratedContactData()
        {

            List<ContactData> contacts = new List<ContactData>
            {
                new ContactData
                {
                    FirstName = $"TestName{StringGenerator.RandomString()}",
                    MiddleName = $"TestMiddleName{StringGenerator.RandomString()}",
                    LastName = $"TestLastName{StringGenerator.RandomString()}",
                    Address = $"{StringGenerator.RandomString()}",
                    TelephoneHome = $"{StringGenerator.RandomString()}",
                    EMail = $"{StringGenerator.RandomString()}",
                    TestObjectInstanceName = "Default contact data"
                },
                new ContactData
                {
                    FirstName = "TestName" + DateTime.Now,
                    MiddleName = "TestMiddleName" + DateTime.Now,
                    LastName = "TestLastName" + DateTime.Now,
                    Address = "",
                    TelephoneHome = "",
                    EMail = DateTime.Now.ToString(),
                    TestObjectInstanceName = "Contact data with unique values"
                }
            };

            WriteToCsv("Contacts.csv", contacts);
            WriteToXml<ContactData>("Contacts.xml", contacts);
            WriteToJson<ContactData>("Contacts.json", contacts);
        }

        private static void WriteToCsv(string fileName, List<ContactData> contacts)
        {
            List<ContactDataCsv> contactsCsv = new List<ContactDataCsv>();
            foreach (var contact in contacts)
            {
                contactsCsv.Add(new ContactDataCsv(contact));
            }
            WriteToCsv(fileName, contactsCsv);
        }
        
        private static void WriteToCsv(string fileName, List<ContactDataCsv> contacts)
        {
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
        
        private static void WriteToXml<T>(string fileName, List<T> contacts)
        {
            using (StreamWriter writer =
                new StreamWriter(HelperBase.GetDataFileFullPath(fileName)))
            {
                new XmlSerializer(typeof(List<T>)).Serialize(writer, contacts);
            }
        }
        
        private static void WriteToJson<T>(string fileName, List<T> objects)
        {
            using (StreamWriter writer =
                new StreamWriter(HelperBase.GetDataFileFullPath(fileName)))
            {
                writer.Write(JsonHelper.PrettyPrintJson(JsonConvert.SerializeObject(objects)));
            }
        }
    }
}