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