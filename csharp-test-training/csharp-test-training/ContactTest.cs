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
            FillLoginForm(_accountFactory.GetAdminAccountData());
            SubmitLoginForm();

            GoToContactCreationPage();
            ContactData data = new ContactData("TestName");
            data.MiddleName = "TestMiddleName";
            data.LastName = "TestLastName";
            FillContactForm(data);
            SubmitContactData();
            Logout();

        }
    }
}