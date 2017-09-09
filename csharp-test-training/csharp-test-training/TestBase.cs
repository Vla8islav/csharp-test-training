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
        protected GroupHelper GroupHelper;
        protected ContactHelper ContactHelper;
        private FirefoxDriverFactory _driverFactory;

        [SetUp]
        public void SetupTest()
        {
            if (Driver == null)
            {
                Driver = _driverFactory.GetFirefoxDriver();
            }
        }

        public TestBase()
        {
            _driverFactory = new FirefoxDriverFactory();
            Driver = _driverFactory.GetFirefoxDriver();

            AccountFactory = new AccountFactory();
            Environment = new TestingEnvironment();
            LoginHelper = new LoginHelper(Driver);
            NavigationHelper = new NavigationHelper(Driver, Environment);
            GroupHelper = new GroupHelper(Driver);
            ContactHelper = new ContactHelper(Driver);
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




    }
}