using System;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class ApplicationManager
    {
        protected IWebDriver _driver;
        protected AccountFactory _accountFactory;
        protected TestingEnvironment Environment;
        private readonly LoginHelper _loginHelper;
        private readonly NavigationHelper _navigationHelper;
        private readonly GroupHelper _groupHelper;
        private readonly ContactHelper _contactHelper;
        private FirefoxDriverFactory _driverFactory;

        public ApplicationManager()
        {
            _driverFactory = new FirefoxDriverFactory();
            _driver = _driverFactory.GetFirefoxDriver();

            _accountFactory = new AccountFactory();
            Environment = new TestingEnvironment();
            _loginHelper = new LoginHelper(Driver);
            _navigationHelper = new NavigationHelper(Driver, Environment);
            _groupHelper = new GroupHelper(Driver);
            _contactHelper = new ContactHelper(Driver);

        }

        public NavigationHelper NavigationHelper => _navigationHelper;
        public LoginHelper LoginHelper => _loginHelper;
        public GroupHelper GroupHelper => _groupHelper;
        public ContactHelper ContactHelper => _contactHelper;

        public AccountFactory AccountFactory => _accountFactory;

        public FirefoxDriverFactory DriverFactory => _driverFactory;
        public IWebDriver Driver => _driver;

        public void Stop()

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