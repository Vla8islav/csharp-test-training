using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupTest : TestBase
    {
        [Test]
        public void TheUntitledTest()
        {
            app.NavigationHelper.GoToGroupsPage()
                .OpenCreateGroupPage();
            GroupData data = new GroupData("Some new goup")
            {
                GroupHeader = "Some group header",
                GroupFooter = "Некоторый русский текст для разнообразия."
            };
            app.GroupHelper.FillGroupForm(data)
                .SubmitGroupForm();
        }
    }
}