using OpenQA.Selenium;

namespace addressbook_web_tests.Pages
{
    public class GroupsPage : PageBase
    {
        public new string PageUrl { get; } = "addressbook/group.php";

        public override By GetAnElementUniqueToPage()
        {
            return By.XPath("//input[@type='submit' and @value='New group']");
        }

    }
}