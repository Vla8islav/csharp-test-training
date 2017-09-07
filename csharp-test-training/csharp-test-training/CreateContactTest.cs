using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class CreateContactTest
    {
        private IWebDriver _driver;
        private StringBuilder _verificationErrors;
        private string _baseUrl;

        [SetUp]
        public void SetupTest()
        {
            FirefoxDriverFactory driverFactory = new FirefoxDriverFactory();
            TestingEnvironment environment = new TestingEnvironment();

            _driver = driverFactory.GetFirefoxDriver();
            _baseUrl = environment.BaseUrl;
            _verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                _driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", _verificationErrors.ToString());
        }

        [Test]
        public void TheUntitledTest()
        {
            OpenMainPage();
            FillLoginForm(new AccountData("admin", "e3Zr14G14MoXkQ0TS8t8"));
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

        private void GoToContactCreationPage()
        {
            _driver.FindElement(By.LinkText("add new")).Click();
        }

        private void Logout()
        {
            _driver.FindElement(By.LinkText("Logout")).Click();
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

        private void SubmitLoginForm()
        {
            _driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void FillLoginForm(AccountData data)
        {
            _driver.FindElement(By.Name("user")).Clear();
            _driver.FindElement(By.Name("user")).SendKeys(data.Login);
            _driver.FindElement(By.Name("pass")).Clear();
            _driver.FindElement(By.Name("pass")).SendKeys(data.Password);
        }

        private void OpenMainPage()
        {
            _driver.Navigate().GoToUrl(_baseUrl + "addressbook/");
        }
    }
}