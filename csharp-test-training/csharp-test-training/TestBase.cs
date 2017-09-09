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
        protected LoginHelper LoginHelper;

        [SetUp]
        public void SetupTest()
        {
            FirefoxDriverFactory driverFactory = new FirefoxDriverFactory();
            Environment = new TestingEnvironment();

            _driver = driverFactory.GetFirefoxDriver();
        }

        public TestBase()
        {
            _accountFactory = new AccountFactory();
            LoginHelper = new LoginHelper(_driver);
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

        protected void OpenMainPage()
        {
            _driver.Navigate().GoToUrl(Environment.BaseUrl + "addressbook/");
        }

        protected void FillGroupForm(GroupData data)
        {
            _driver.FindElement(By.Name("group_name")).Clear();
            _driver.FindElement(By.Name("group_name")).SendKeys(data.GroupName);
            _driver.FindElement(By.Name("group_header")).Clear();
            _driver.FindElement(By.Name("group_header")).SendKeys(data.GroupHeader);
            _driver.FindElement(By.Name("group_footer")).Clear();
            _driver.FindElement(By.Name("group_footer")).SendKeys(data.GroupFooter);
        }

        protected void SubmitGroupForm()
        {
            _driver.FindElement(By.Name("submit")).Click();
        }

        protected void OpenCreateGroupPage()
        {
            _driver.FindElement(By.Name("new")).Click();
        }

        protected void GoToGroupsPage()
        {
            _driver.FindElement(By.LinkText("groups")).Click();
        }

        protected void SubmitContactData()
        {
            _driver.FindElement(By.Name("submit")).Click();
        }

        protected void FillContactForm(ContactData data)
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