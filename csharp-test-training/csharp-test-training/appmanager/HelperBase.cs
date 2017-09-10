using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class HelperBase
    {
        protected readonly IWebDriver Driver;
        protected readonly ApplicationManager app;

        public HelperBase(ApplicationManager app)
        {
            this.app = app;
            Driver = app.Driver;
        }

    }
}