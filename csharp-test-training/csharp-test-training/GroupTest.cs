using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupTest : TestBase
    {

        [Test]
        public void TheUntitledTest()
        {
            NavigationHelper.OpenMainPage();
            LoginHelper.FillLoginForm(AccountFactory.GetAdminAccountData());
            LoginHelper.SubmitLoginForm();
            NavigationHelper.GoToGroupsPage();
            NavigationHelper.OpenCreateGroupPage();
            GroupData data = new GroupData("Some new goup");
            data.GroupHeader = "Some group header";
            data.GroupFooter = "Некоторый русский текст для разнообразия.";
            FillGroupForm(data);
            SubmitGroupForm();
            LoginHelper.Logout();
        }
    }
}