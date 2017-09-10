using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class HelperBase
    {
        protected readonly IWebDriver Driver;

        public HelperBase(ApplicationManager app)
        {
            Driver = app.Driver;
        }

    }
}