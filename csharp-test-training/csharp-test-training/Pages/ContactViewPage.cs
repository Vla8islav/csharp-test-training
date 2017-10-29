using OpenQA.Selenium;

namespace addressbook_web_tests.Pages
{
    public class ContactViewPage : PageBase
    {
        public override string PageUrl { get; } = "addressbook/view.php?id=";

        public override By GetAnElementUniqueToPage()
        {
            return By.CssSelector("#content > form:nth-child(26) > input[type='submit']:nth-child(2)[name=print]");
        }
        
        public static By Id => By.Name("id");
        public static By FirstName => By.Name("firstname");
        public static By MiddleName => By.Name("middlename");
        public static By LastName => By.Name("lastname");
        public static By Address  => By.Name("address");
        public static By Email => By.Name("email");
        public static By Email2 => By.Name("email2");
        public static By Email3 => By.Name("email3");
        public static By TelephoneHome => By.Name("home");
        public static By TelephoneMobile => By.Name("mobile");
        public static By TelephoneWork => By.Name("work");
        public static By TelephoneFax => By.Name("fax");
    }
}