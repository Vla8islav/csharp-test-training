using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBaseWithLogin
    {
        [Test]
        public void GroupRemovalTest()
        {
            const int groupNumberToDelete = 5;
            app.GroupHelper.PrepareANumberOfGroups(groupNumberToDelete);
            
            List<GroupData> groupListPrev = app.GroupHelper.GetGroupList();
            app.GroupHelper.RemoveFromTheListItemNumber(groupNumberToDelete);
            List<GroupData> groupListAfter = app.GroupHelper.GetGroupList();
            Assert.AreEqual(groupListAfter.Count, groupListPrev.Count - 1,
                $"Expected group count on a page {app.Driver.Url} is {groupListPrev.Count - 1} actual count {groupListAfter.Count}");

            
        }
    }
}