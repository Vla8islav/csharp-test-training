using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupTest : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.NavigationHelper
                .GoToGroupsPage()
                .OpenCreateGroupPage();
            GroupData data = new GroupData("Some new goup")
            {
                GroupHeader = "Some group header",
                GroupFooter = "Некоторый русский текст для разнообразия."
            };
            app.GroupHelper.Create(data);
        }

        [Test]
        public void EmptyGroupCrationTest()
        {
            app.NavigationHelper
                .GoToGroupsPage()
                .OpenCreateGroupPage();
            GroupData data = new GroupData("")
            {
                GroupHeader = "",
                GroupFooter = ""
            };
            app.GroupHelper.Create(data);
        }
    }
}