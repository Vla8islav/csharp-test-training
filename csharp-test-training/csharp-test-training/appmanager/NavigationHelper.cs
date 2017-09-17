using System;
using addressbook_web_tests.Pages;
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

        public NavigationHelper OpenMainPage()
        {
            MainPage page = new MainPage();
            if (!IsOnThePage(page))
            {
                GoToRelativeUrl(page.PageUrl);
            }
            return this;
        }
        
        public NavigationHelper OpenContactCreationPage()
        {
            ContactCreationPage page = new ContactCreationPage();
            if (!IsOnThePage(page))
            {
                GoToRelativeUrl(page.PageUrl);
                Driver.FindElement(By.LinkText("add new")).Click();
            }
            
            return this;
        }

        public NavigationHelper OpenGroupCreationPage()
        {
            GroupCreationPage page = new GroupCreationPage();
            if (!IsOnThePage(page))
            {
                GoToRelativeUrl(page.PageUrl);
                Driver.FindElement(By.Name("new")).Click();
            }
            
            return this;
        }

        public NavigationHelper OpenGroupsPage()
        {
            GroupsPage page = new GroupsPage();
            if (!IsOnThePage(page))
            {
                GoToRelativeUrl(page.PageUrl);
                Driver.FindElement(By.LinkText("groups")).Click();
            }
            
            return this;
        }

        private bool IsOnThePage(PageBase currentPage)
        {
            bool retval = true;
            if (null != currentPage.PageUrl)
            {
                Uri currentUri = new Uri(Driver.Url);
                retval &= currentPage.PageUrl.Equals(currentUri.PathAndQuery);
            }

            retval &= IsElementDisplayed(currentPage.GetAnElementUniqueToPage());

            return retval;
        }

        public void GoToRelativeUrl(string relativePath)
        {
            Uri currentBaseUri = new Uri(_environment.BaseUrl);
            string trimmedBaseURL = currentBaseUri.GetLeftPart(UriPartial.Authority); // just get the "base" bit of the URL
            string urlToGo = trimmedBaseURL + "/" + relativePath;
            Driver.Navigate().GoToUrl(urlToGo);
        }


    }
}