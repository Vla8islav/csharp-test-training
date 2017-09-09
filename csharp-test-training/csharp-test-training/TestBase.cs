using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class TestBase
    {
        protected IWebDriver _driver;
        protected AccountFactory _accountFactory;
        protected TestingEnvironment Environment;

        public TestBase()
        {
            _accountFactory = new AccountFactory();
        }

        [SetUp]
        public void SetupTest()
        {
            FirefoxDriverFactory driverFactory = new FirefoxDriverFactory();
            Environment = new TestingEnvironment();

            _driver = driverFactory.GetFirefoxDriver();
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
        }

        protected void GoToContactCreationPage()
        {
            _driver.FindElement(By.LinkText("add new")).Click();
        }

        protected void Logout()
        {
            _driver.FindElement(By.LinkText("Logout")).Click();
        }

        protected void SubmitLoginForm()
        {
            _driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        protected void FillLoginForm(AccountData data)
        {
            _driver.FindElement(By.Name("user")).Clear();
            _driver.FindElement(By.Name("user")).SendKeys(data.Login);
            _driver.FindElement(By.Name("pass")).Clear();
            _driver.FindElement(By.Name("pass")).SendKeys(data.Password);
        }

        protected void OpenMainPage()
        {
            _driver.Navigate().GoToUrl(Environment.BaseUrl + "addressbook/");
        }
    }
}