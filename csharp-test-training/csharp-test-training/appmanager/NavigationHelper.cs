using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class NavigationHelper : HelperBase
    {
        private readonly TestingEnvironment _environment;

        public NavigationHelper(IWebDriver driver, TestingEnvironment environment) : base(driver)
        {
            _environment = environment;

        }

        public void GoToContactCreationPage()
        {
            Driver.FindElement(By.LinkText("add new")).Click();
        }

        public void OpenMainPage()
        {
            Driver.Navigate().GoToUrl(_environment.BaseUrl + "addressbook/");
        }

        public void OpenCreateGroupPage()
        {
            Driver.FindElement(By.Name("new")).Click();
        }

        public void GoToGroupsPage()
        {
            Driver.FindElement(By.LinkText("groups")).Click();
        }

    }
}