using OpenQA.Selenium;

namespace addressbook_web_tests.Pages
{
    public class ContactCreationPage : PageBase
    {
        public new string PageUrl { get; } = "addressbook/edit.php";

        public override By GetAnElementUniqueToPage()
        {
            return By.XPath("//h1[.='Edit / add address book entry']");
        }
    }
}