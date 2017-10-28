using OpenQA.Selenium;

namespace addressbook_web_tests.Pages
{
    public class GroupCreationPage : PageBase
    {
        public override string PageUrl { get; } = "addressbook/group.php";

        public override By GetAnElementUniqueToPage()
        {
            return By.XPath("//input[@name='submit' and @value='Enter information']");
        }

    }
}