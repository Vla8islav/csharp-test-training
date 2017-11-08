using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : TestBaseWithLogin
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData data = GroupFactory.GetGroupDataByInstanceNameFromJson("GroupForModification");
            int groupNumberToModify = 5;
            app.GroupHelper.PrepareANumberOfGroups(groupNumberToModify);

            List<GroupData> groupListPrev = app.GroupHelper.GetGroupList();
            data.Id = groupListPrev[groupNumberToModify].Id;
            app.GroupHelper.ModifyGroup(groupListPrev[groupNumberToModify], data);
            List<GroupData> groupListAfter = app.GroupHelper.GetGroupListDb();

            
            List<GroupData> groupListExpected =
                app.GroupHelper.ModifyGroupInList(groupListPrev, groupListPrev[groupNumberToModify], data);

            app.GroupHelper.CormpareGroupListsVisibleValues(
                    app.GroupHelper.Sort(groupListAfter),
                    app.GroupHelper.Sort(groupListExpected))
                .CheckTestResult();
        }
    }
}