using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBaseUiWithLogin
    {
        [Test]
        public void GroupRemovalTest()
        {
            const int groupPositionToDelete = 4;
            app.GroupHelper.PrepareANumberOfGroups(groupPositionToDelete + 1);

            List<GroupData> groupListPrev = app.GroupHelper.GetGroupList();
            app.GroupHelper.RemoveFromTheListItemNumber(groupListPrev[groupPositionToDelete]);
            List<GroupData> groupListAfter = GroupData.GetAllGroups();

            List<GroupData> groupListExpected =
                groupListPrev.Where(g => g.Id != groupListPrev[groupPositionToDelete].Id).ToList();

            app.GroupHelper.CormpareGroupListsVisibleValues(
                    app.GroupHelper.Sort(groupListAfter),
                    app.GroupHelper.Sort(groupListExpected))
                .CheckTestResult();
        }
    }
}