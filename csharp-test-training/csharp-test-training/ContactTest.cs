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
            NavigationHelper.OpenMainPage();
            LoginHelper.FillLoginForm(AccountFactory.GetAdminAccountData());
            LoginHelper.SubmitLoginForm();

            NavigationHelper.GoToContactCreationPage();
            ContactData data = new ContactData("TestName");
            data.MiddleName = "TestMiddleName";
            data.LastName = "TestLastName";
            FillContactForm(data);
            SubmitContactData();
            LoginHelper.Logout();

        }
    }
}