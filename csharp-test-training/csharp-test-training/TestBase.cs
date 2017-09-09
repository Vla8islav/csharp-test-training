using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class TestBase
    {
        protected IWebDriver Driver;
        protected AccountFactory AccountFactory;
        protected TestingEnvironment Environment;
        protected LoginHelper LoginHelper;
        protected NavigationHelper NavigationHelper;

        [SetUp]
        public void SetupTest()
        {

        }

        public TestBase()
        {
            FirefoxDriverFactory driverFactory = new FirefoxDriverFactory();
            Driver = driverFactory.GetFirefoxDriver();

            Environment = new TestingEnvironment();
            LoginHelper = new LoginHelper(Driver);
            NavigationHelper = new NavigationHelper(Driver, Environment);
            AccountFactory = new AccountFactory();
        }



        [TearDown]
        public void TeardownTest()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }


        protected void FillGroupForm(GroupData data)
        {
            Driver.FindElement(By.Name("group_name")).Clear();
            Driver.FindElement(By.Name("group_name")).SendKeys(data.GroupName);
            Driver.FindElement(By.Name("group_header")).Clear();
            Driver.FindElement(By.Name("group_header")).SendKeys(data.GroupHeader);
            Driver.FindElement(By.Name("group_footer")).Clear();
            Driver.FindElement(By.Name("group_footer")).SendKeys(data.GroupFooter);
        }

        protected void SubmitGroupForm()
        {
            Driver.FindElement(By.Name("submit")).Click();
        }


        protected void SubmitContactData()
        {
            Driver.FindElement(By.Name("submit")).Click();
        }

        protected void FillContactForm(ContactData data)
        {
            Driver.FindElement(By.Name("firstname")).Clear();
            Driver.FindElement(By.Name("firstname")).SendKeys(data.FirstName);
            Driver.FindElement(By.Name("middlename")).Clear();
            Driver.FindElement(By.Name("middlename")).SendKeys(data.MiddleName);
            Driver.FindElement(By.Name("lastname")).Clear();
            Driver.FindElement(By.Name("lastname")).SendKeys(data.LastName);
        }
    }
}