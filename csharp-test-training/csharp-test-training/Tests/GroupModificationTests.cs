using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : TestBaseWithLogin
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData data = new GroupData("Some new goup" + " modified")
            {
                GroupHeader = "Some group header" + " modified",
                GroupFooter = "Некоторый русский текст для разнообразия." + " modified"
            };

            int groupNumberToModify = 5;
            app.GroupHelper.PrepareANumberOfGroups(groupNumberToModify);
            app.NavigationHelper.OpenGroupsPage();
            app.GroupHelper.ModifyGroupNumber(groupNumberToModify, data);
        }

    }
}