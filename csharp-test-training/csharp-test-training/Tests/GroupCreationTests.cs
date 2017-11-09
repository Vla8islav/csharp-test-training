using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBaseUiWithLogin
    {

        [Test, TestCaseSource(nameof(GroupDataProvider))]
        public void GroupCreationTest(Tuple<GroupData,string> dataTuple)
        {
            GroupData data = dataTuple.Item1;
            List<GroupData> groupListPrev = GroupData.GetAllGroups();
            app.GroupHelper.Create(data);
            List<GroupData> groupListAfter = GroupData.GetAllGroups();
            
            data.Id = ContactHelper.GuessIdOfNewElement(new List<ModelWithId>(groupListPrev), new List<ModelWithId>(groupListAfter));
            groupListPrev.Add(data);
            app.GroupHelper.CormpareGroupLists(
                app.GroupHelper.Sort(groupListPrev), 
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