using System;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class ApplicationManager
    {
        protected TestingEnvironment Environment;

        public ApplicationManager()
        {
            FirefoxDriverFactory driverFactory = new FirefoxDriverFactory();
            Driver = driverFactory.GetFirefoxDriver();

            AccountFactory = new AccountFactory();
            Environment = new TestingEnvironment();
            LoginHelper = new LoginHelper(Driver);
            NavigationHelper = new NavigationHelper(Driver, Environment);
            GroupHelper = new GroupHelper(Driver);
            ContactHelper = new ContactHelper(Driver);

        }

        public NavigationHelper NavigationHelper { get; }

        public LoginHelper LoginHelper { get; }

        public GroupHelper GroupHelper { get; }

        public ContactHelper ContactHelper { get; }

        public AccountFactory AccountFactory { get; }

        public IWebDriver Driver { get; }

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