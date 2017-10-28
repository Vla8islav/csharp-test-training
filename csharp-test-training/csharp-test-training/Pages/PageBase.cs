using OpenQA.Selenium;

namespace addressbook_web_tests.Pages
{
    public abstract class PageBase
    {
        public abstract string PageUrl { get; }
        public abstract By GetAnElementUniqueToPage();
    }
}