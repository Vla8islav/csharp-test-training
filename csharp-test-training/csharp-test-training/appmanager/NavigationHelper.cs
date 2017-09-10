using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class NavigationHelper : HelperBase
    {
        private readonly TestingEnvironment _environment;

        public NavigationHelper(ApplicationManager app, TestingEnvironment environment) : base(app)
        {
            _environment = environment;
        }

        public NavigationHelper GoToContactCreationPage()
        {
            Driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public NavigationHelper OpenMainPage()
        {
            Driver.Navigate().GoToUrl(_environment.BaseUrl + "addressbook/");
            return this;
        }

        public NavigationHelper OpenCreateGroupPage()
        {
            Driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public NavigationHelper GoToGroupsPage()
        {
            Driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

    }
}