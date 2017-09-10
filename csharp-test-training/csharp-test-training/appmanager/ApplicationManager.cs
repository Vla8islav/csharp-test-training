using System;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class ApplicationManager
    {
        private TestingEnvironment Environment;

        public ApplicationManager()
        {
            FirefoxDriverFactory driverFactory = new FirefoxDriverFactory();
            Driver = driverFactory.GetFirefoxDriver();

            AccountFactory = new AccountFactory();
            Environment = new TestingEnvironment();
            LoginHelper = new LoginHelper(this);
            NavigationHelper = new NavigationHelper(this, Environment);
            GroupHelper = new GroupHelper(this);
            ContactHelper = new ContactHelper(this);

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