
using System;
using System.Collections.Generic;
using addressbook_web_tests;
using FileHelpers;

namespace addressbook_test_data_generators
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WritePregeneratedContactData("Contacts.csv");
        }

                
        private static void WritePregeneratedContactData(string fileName)
        {
            var engine = new FileHelperEngine<ContactDataCsv>();

            List<ContactDataCsv> contacts
                = new List<ContactDataCsv>();
            contacts.Add(new ContactDataCsv
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

            engine.WriteFile(HelperBase.GetDataFileFullPath(fileName), contacts);
        }

    }
}