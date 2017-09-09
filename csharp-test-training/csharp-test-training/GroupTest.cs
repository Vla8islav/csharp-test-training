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
            OpenMainPage();
            FillLoginForm(_accountFactory.GetAdminAccountData());
            SubmitLoginForm();
            GoToGroupsPage();
            OpenCreateGroupPage();
            GroupData data = new GroupData("Some new goup");
            data.GroupHeader = "Some group header";
            data.GroupFooter = "Некоторый русский текст для разнообразия.";
            FillGroupForm(data);
            SubmitGroupForm();
            Logout();
        }


        private void FillGroupForm(GroupData data)
        {
            _driver.FindElement(By.Name("group_name")).Clear();
            _driver.FindElement(By.Name("group_name")).SendKeys(data.GroupName);
            _driver.FindElement(By.Name("group_header")).Clear();
            _driver.FindElement(By.Name("group_header")).SendKeys(data.GroupHeader);
            _driver.FindElement(By.Name("group_footer")).Clear();
            _driver.FindElement(By.Name("group_footer")).SendKeys(data.GroupFooter);
        }

        private void SubmitGroupForm()
        {
            _driver.FindElement(By.Name("submit")).Click();
        }

        private void OpenCreateGroupPage()
        {
            _driver.FindElement(By.Name("new")).Click();
        }

        private void GoToGroupsPage()
        {
            _driver.FindElement(By.LinkText("groups")).Click();
        }

    }
}