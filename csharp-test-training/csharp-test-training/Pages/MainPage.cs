using OpenQA.Selenium;

namespace addressbook_web_tests.Pages
{
    public class MainPage : PageBase
    {
        public override string PageUrl { get; } = "addressbook/";

        public override By GetAnElementUniqueToPage()
        {
            return By.XPath("//input[@type='button' and @value='Send e-Mail']");
        }

    }
}