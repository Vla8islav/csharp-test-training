using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBaseWithLogin
    {

        [Test, TestCaseSource(nameof(GroupDataProvider))]
        public void GroupCreationTest(Tuple<GroupData,string> dataTuple)
        {
            GroupData data = dataTuple.Item1;
            List<GroupData> groupListPrev = app.GroupHelper.GetGroupList();
            app.GroupHelper.Create(data);
            List<GroupData> groupListAfter = app.GroupHelper.GetGroupList();
            
            app.GroupHelper.CormpareTwoGroupLists(
                    app.GroupHelper.AddAndSort(groupListPrev, data), 
                    app.GroupHelper.Sort(groupListAfter))
                .CheckTestResult();
        }

        public static IEnumerable<Tuple<GroupData,string>> GroupDataProvider()
        {
            var retval = new List<Tuple<GroupData,string>>();
            
            retval.Add(new Tuple<GroupData, string>(new GroupData
                {
                    GroupName = "a'a",
                    GroupHeader = "Some group header",
                    GroupFooter = "Некоторый русский текст для разнообразия."
                },
                "NameWith ' symbol"));
            
            retval.Add(new Tuple<GroupData, string>(new GroupData
                {
                    GroupName = "Some new goup",
                    GroupHeader = "Some group header",
                    GroupFooter = null
                },
                "LeaveFooterIntact"));
            
            retval.Add(new Tuple<GroupData, string>(new GroupData
                {
                    GroupName = "",
                    GroupHeader = "",
                    GroupFooter = ""
                },
                "EmptyGroup"));
            

            for (int i = 0; i < 3; i++)
            {
                Tuple<GroupData,string> currentTuple = new Tuple<GroupData, string>(new GroupData
                {
                    GroupName = $"Some new goup {StringGenerator.RandomString()}",
                    GroupHeader = $"Some group header {StringGenerator.RandomString()}",
                    GroupFooter = $"Некоторый русский текст для разнообразия. {StringGenerator.RandomString()}"
                },
                    "RandomString");  
                retval.Add(currentTuple);
            }
            return retval;
        }

    }
}