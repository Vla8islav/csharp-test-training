using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class ContactTest : TestBase
    {

        [Test]
        public void CreateContactTest()
        {
            ApplicationManager.NavigationHelper.OpenMainPage();
            ApplicationManager.LoginHelper.FillLoginForm(ApplicationManager.AccountFactory.GetAdminAccountData());
            ApplicationManager.LoginHelper.SubmitLoginForm();

            ApplicationManager.NavigationHelper.GoToContactCreationPage();
            ContactData data = new ContactData("TestName");
            data.MiddleName = "TestMiddleName";
            data.LastName = "TestLastName";
            ApplicationManager.ContactHelper.FillContactForm(data);
            ApplicationManager.ContactHelper.SubmitContactData();
            ApplicationManager.LoginHelper.Logout();

        }
    }
}