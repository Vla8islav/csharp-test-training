using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupTest : TestBase
    {

        [Test]
        public void TheUntitledTest()
        {
            app.NavigationHelper.OpenMainPage();
            app.LoginHelper.FillLoginForm(app.AccountFactory.GetAdminAccountData());
            app.LoginHelper.SubmitLoginForm();
            app.NavigationHelper.GoToGroupsPage();
            app.NavigationHelper.OpenCreateGroupPage();
            GroupData data = new GroupData("Some new goup");
            data.GroupHeader = "Some group header";
            data.GroupFooter = "Некоторый русский текст для разнообразия.";
            app.GroupHelper.FillGroupForm(data);
            app.GroupHelper.SubmitGroupForm();
            app.LoginHelper.Logout();
        }
    }
}