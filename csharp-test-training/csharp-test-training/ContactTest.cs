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
            OpenMainPage();
            LoginHelper.FillLoginForm(_accountFactory.GetAdminAccountData());
            LoginHelper.SubmitLoginForm();

            GoToContactCreationPage();
            ContactData data = new ContactData("TestName");
            data.MiddleName = "TestMiddleName";
            data.LastName = "TestLastName";
            FillContactForm(data);
            SubmitContactData();
            LoginHelper.Logout();

        }
    }
}