using System;
using System.Collections.Generic;
using System.Linq;

namespace addressbook_web_tests
{
    public class GroupFactory : DataFactoryBase
    {
        public static GroupData GetSampleGroupData()
        {
            return GetGroupDataByInstanceNameFromJson("SampleGroupData");
        }

        public static Tuple<GroupData, string> GetGroupFactoryTupleByName(string instanceName)
        {
            return new Tuple<GroupData, string>(GetGroupDataByInstanceNameFromJson(instanceName),
                instanceName);
        }

        private static List<GroupData> _groupsFromFile;

        public static GroupData GetGroupDataByInstanceNameFromXml(string instanceName)
        {
            return GetGroupsFromFileXml().First(c => c.TestObjectInstanceName == instanceName);
        }

        public static GroupData GetGroupDataByInstanceNameFromJson(string instanceName)
        {
            return GetGroupsFromFileJson().First(c => c.TestObjectInstanceName == instanceName);
        }
        

        private static List<GroupData> GetGroupsFromFileXml()
        {
            if (null == _groupsFromFile)
            {
                _groupsFromFile = GetObjectFromFileXml<GroupData>("Groups.xml");
            }
            return _groupsFromFile;
        }

        private static List<GroupData> GetGroupsFromFileJson()
        {
            if (null == _groupsFromFile)
            {
                _groupsFromFile = GetObjectFromFileJson<GroupData>("Groups.json");
            }
            return _groupsFromFile;
        }


        public static IEnumerable<Tuple<GroupData,string>> GroupDataProvider()
        {
            var retval = new List<Tuple<GroupData,string>>();
            retval.Add(GroupFactory.GetGroupFactoryTupleByName("NameWith ' symbol"));
            retval.Add(GroupFactory.GetGroupFactoryTupleByName("LeaveFooterIntact"));
            retval.Add(GroupFactory.GetGroupFactoryTupleByName("EmptyGroup"));
            for (int i = 0; i < 3; i++)
            {
                retval.Add(GroupFactory.GetGroupFactoryTupleByName($"RandomString_{i}"));
            }
            return retval;
        }
    }
}