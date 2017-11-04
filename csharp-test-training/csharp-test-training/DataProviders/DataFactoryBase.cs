using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace addressbook_web_tests
{
    public class DataFactoryBase
    {
        protected static List<T> GetObjectFromFileJson<T>(string fileName)
        {
            List<T> retval = new List<T>();
            using (StreamReader reader =
                new StreamReader(HelperBase.GetDataFileFullPath(fileName)))
            {
                string jsonDataRaw = reader.ReadToEnd();
                JArray deserialisedJsonContactData = (JArray) JsonConvert.DeserializeObject(jsonDataRaw);
                foreach (var contactData in deserialisedJsonContactData)
                {
                    retval.Add(contactData.ToObject<T>());
                }
            }

            return retval;
        }

        protected static List<T> GetObjectFromFileXml<T>(string fileName)
        {
            List<T> retval = new List<T>();
            using (StreamReader reader =
                new StreamReader(HelperBase.GetDataFileFullPath(fileName)))
            {
                retval =
                    (List<T>) new XmlSerializer(typeof(List<T>)).Deserialize(reader);
            }
            return retval;
        }
    }
}