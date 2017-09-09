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

        private void SubmitContactData()
        {
            _driver.FindElement(By.Name("submit")).Click();
        }

        private void FillContactForm(ContactData data)
        {
            _driver.FindElement(By.Name("firstname")).Clear();
            _driver.FindElement(By.Name("firstname")).SendKeys(data.FirstName);
            _driver.FindElement(By.Name("middlename")).Clear();
            _driver.FindElement(By.Name("middlename")).SendKeys(data.MiddleName);
            _driver.FindElement(By.Name("lastname")).Clear();
            _driver.FindElement(By.Name("lastname")).SendKeys(data.LastName);
        }
    }
}