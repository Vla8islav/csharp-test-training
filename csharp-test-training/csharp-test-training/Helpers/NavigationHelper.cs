using System;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class NavigationHelper
    {
        private readonly IWebDriver _driver;
        private readonly TestingEnvironment _environment;

        public NavigationHelper(IWebDriver driver, TestingEnvironment environment)
        {
            _driver = driver;
            _environment = environment;

        }

        public void GoToContactCreationPage()
        {
            _driver.FindElement(By.LinkText("add new")).Click();
        }

        public void OpenMainPage()
        {
            _driver.Navigate().GoToUrl(_environment.BaseUrl + "addressbook/");
        }

        public void OpenCreateGroupPage()
        {
            _driver.FindElement(By.Name("new")).Click();
        }

        public void GoToGroupsPage()
        {
            _driver.FindElement(By.LinkText("groups")).Click();
        }

    }
}