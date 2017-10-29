using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace addressbook_web_tests.Pages
{
    public class ContactCreationPage : PageBase
    {

        public override string PageUrl { get; } = "addressbook/edit.php";

        public override By GetAnElementUniqueToPage()
        {
            return By.XPath("//h1[.='Edit / add address book entry']");
        }
        
        public static By FirstName => By.Name("firstname");
        public static By MiddleName => By.Name("middlename");
        public static By LastName => By.Name("lastname");
        public static By Nickname => By.Name("nickname");
        public static By Company => By.Name("company");
        public static By Title => By.Name("title");
        public static By Address  => By.Name("address");
        public static By TelephoneHome => By.Name("home");
        public static By TelephoneMobile => By.Name("mobile");
        public static By TelephoneWork => By.Name("work");
        public static By TelephoneFax => By.Name("fax");
        public static By Email => By.Name("email");
        public static By Email2 => By.Name("email2");
        public static By Email3 => By.Name("email3");
        public static By Homepage => By.Name("homepage");
        
        public static By Id => By.Name("id");
    }
}