using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : TestBaseWithLogin
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData data = new GroupData
            {
                GroupName = "Some new goup" + " modified",
                GroupHeader = "Some group header" + " modified",
                GroupFooter = "Некоторый русский текст для разнообразия." + " modified"
            };

            int groupNumberToModify = 5;
            app.GroupHelper.PrepareANumberOfGroups(groupNumberToModify);

            List<GroupData> groupListPrev = app.GroupHelper.GetGroupList();
            app.GroupHelper.ModifyGroupNumber(groupNumberToModify, data);
            List<GroupData> groupListAfter = app.GroupHelper.GetGroupList();

            List<GroupData> groupListExpected =
                app.GroupHelper.ModifyGroupNumberInList(groupListPrev, groupNumberToModify, data);

            app.GroupHelper.CormpareTwoGroupLists(
                    app.GroupHelper.Sort(groupListAfter),
                    app.GroupHelper.Sort(groupListExpected))
                .CheckTestResult();
        }
    }
}