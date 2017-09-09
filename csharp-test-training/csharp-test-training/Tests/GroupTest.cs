using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupTest : TestBase
    {

        [Test]
        public void TheUntitledTest()
        {
            ApplicationManager.NavigationHelper.OpenMainPage();
            ApplicationManager.LoginHelper.FillLoginForm(ApplicationManager.AccountFactory.GetAdminAccountData());
            ApplicationManager.LoginHelper.SubmitLoginForm();
            ApplicationManager.NavigationHelper.GoToGroupsPage();
            ApplicationManager.NavigationHelper.OpenCreateGroupPage();
            GroupData data = new GroupData("Some new goup");
            data.GroupHeader = "Some group header";
            data.GroupFooter = "Некоторый русский текст для разнообразия.";
            ApplicationManager.GroupHelper.FillGroupForm(data);
            ApplicationManager.GroupHelper.SubmitGroupForm();
            ApplicationManager.LoginHelper.Logout();
        }
    }
}