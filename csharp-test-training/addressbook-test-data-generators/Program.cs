using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using addressbook_web_tests;
using CommandLine;
using CommandLine.Text;
using FileHelpers;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    class Options
    {
        [Option('v', "verbose", DefaultValue = true,
            HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [Option('t', "data-type", DefaultValue = "contacts",
            HelpText = "Data type to generate. May be either groups, contacts")]
        public string DataType { get; set; }

        [Option('f', "data-format", DefaultValue = "json",
            HelpText = "Format of the output data. xml, json")]
        public string DataFormat { get; set; }

        [Option('n', "generate-objects", DefaultValue = 10,
            HelpText = "Minimal number of objects to generate. Default number is 10")]
        public int ObjectNumberToGenerate { get; set; }

        [Option('a', "filename", DefaultValue = "",
            HelpText =
                "Absolute or relative name of the json file. Default is Contacts.json and Groups.json")]
        public string OutputFilename { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
                current => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var options = new Options();
            if (Parser.Default.ParseArguments(args, options))
            {
                int objectsToGenerate = options.ObjectNumberToGenerate;
                string dataFormat = options.DataFormat;
                string dataType = options.DataType;
                string filename = options.OutputFilename;
                if (String.IsNullOrEmpty(filename))
                {
                    switch (dataType)
                    {
                        case "groups":
                            filename = "Groups";
                            break;
                        case "contacts":
                            filename = "Contacts";
                            break;
                    }
                    filename += $".{dataFormat}";
                }

                switch (dataType)
                {
                    case "groups":
                        WritePregeneratedGroupData(dataFormat, objectsToGenerate, filename);
                        break;
                    case "contacts":
                        WritePregeneratedContactData(dataFormat, objectsToGenerate, filename);
                        break;
                }
            }

        }

        private static void WritePregeneratedGroupData(string dataFormat, int objectsToGenerate, string filename)
        {
            List<GroupData> groups = new List<GroupData>
            {
                new GroupData
                {
                    Name = "a'a",
                    Header = "Some group header",
                    Footer = "Некоторый русский текст для разнообразия.",
                    TestObjectInstanceName = "NameWith ' symbol"
                },
                new GroupData
                {
                    Name = "Some new goup",
                    Header = "Some group header",
                    Footer = null,
                    TestObjectInstanceName = "LeaveFooterIntact"
                },
                new GroupData
                {
                    Name = "",
                    Header = "",
                    Footer = "",
                    TestObjectInstanceName = "EmptyGroup"
                },
                new GroupData
                {
                    Name = "Some new goup" + " modified",
                    Header = "Some group header" + " modified",
                    Footer = "Некоторый русский текст для разнообразия." + " modified",
                    TestObjectInstanceName = "GroupForModification"
                }
            };

            for (int i = 0; groups.Count < objectsToGenerate; i++)
            {
                groups.Add(new GroupData
                {
                    Name = $"Some new goup {StringGenerator.RandomString()}",
                    Header = $"Some group header {StringGenerator.RandomString()}",
                    Footer = $"Некоторый русский текст для разнообразия. {StringGenerator.RandomString()}",
                    TestObjectInstanceName = $"RandomString_{i}"
                });
            }

            WriteDataOnDisk(dataFormat, groups, filename);
        }


        private static void WritePregeneratedContactData(string dataFormat, int objectsToGenerate, string filename)
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
                    FirstName = $"TestName {StringGenerator.RandomString()} {DateTime.Now}",
                    MiddleName = $"TestMiddleName {StringGenerator.RandomString()}",
                    LastName = $"TestLastName {StringGenerator.RandomString()} {DateTime.Now}",
                    Address = $"{StringGenerator.RandomString()}",
                    TelephoneHome = $"{StringGenerator.RandomString()}",
                    EMail = $"{StringGenerator.RandomString()} {DateTime.Now}",
                    TestObjectInstanceName = "Contact data with unique values"
                }
            };

            for (int i = 0; contacts.Count < objectsToGenerate; i++)
            {
                contacts.Add(new ContactData
                {
                    FirstName = $"TestName{StringGenerator.RandomString()}",
                    MiddleName = $"TestMiddleName{StringGenerator.RandomString()}",
                    LastName = $"TestLastName{StringGenerator.RandomString()}",
                    Address = $"{StringGenerator.RandomString()}",
                    TelephoneHome = $"{StringGenerator.RandomString()}",
                    EMail = $"{StringGenerator.RandomString()}",
                    TestObjectInstanceName = $"RandomContactData_{i}"
                });
            }

//            WriteToCsv("Contacts.csv", contacts);
            WriteDataOnDisk(dataFormat, contacts, filename);
        }

        private static void WriteDataOnDisk<T>(string dataFormat, List<T> contacts, string filename)
        {
            if (!Path.IsPathRooted(filename))
            {
                filename = HelperBase.GetDataFileFullPath(filename);
            }

            switch (dataFormat)
            {
                case "xml":
                    WriteToXml(filename, contacts);
                    break;
                case "json":
                    WriteToJson(filename, contacts);
                    break;
            }
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
                new StreamWriter(fileName))
            {
                new XmlSerializer(typeof(List<T>)).Serialize(writer, contacts);
            }
        }

        private static void WriteToJson<T>(string fileName, List<T> objects)
        {
            using (StreamWriter writer =
                new StreamWriter(fileName))
            {
                writer.Write(JsonHelper.PrettyPrintJson(JsonConvert.SerializeObject(objects)));
            }
        }
    }
}