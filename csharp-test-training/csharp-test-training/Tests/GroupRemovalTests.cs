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
            const int groupPositionToDelete = 4;
            app.GroupHelper.PrepareANumberOfGroups(groupPositionToDelete + 1);
            
            List<GroupData> groupListPrev = app.GroupHelper.GetGroupList();
            app.GroupHelper.RemoveFromTheListItemNumber(groupPositionToDelete);
            List<GroupData> groupListAfter = app.GroupHelper.GetGroupList();

            groupListPrev.RemoveAt(groupPositionToDelete);
            Assert.AreEqual(groupListPrev, groupListAfter);
        }
    }
}