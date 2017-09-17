using OpenQA.Selenium;

namespace addressbook_web_tests.Pages
{
    public abstract class PageBase
    {
        public string PageUrl { get; } = null;
        public abstract By GetAnElementUniqueToPage();
    }
}