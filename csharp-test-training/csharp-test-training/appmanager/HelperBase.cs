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

        public void FillField(By locator, string text)
        {
            if (null != text)
            {
                Driver.FindElement(locator).Clear();
                Driver.FindElement(locator).SendKeys(text);
            }
        }

        public string CloseAlertAndGetItsText(bool accept)
        {
            try
            {
                IAlert alert = Driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (accept)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
            }
        }
        
        
        public bool IsElementDisplayed(By by)
        {
            bool retval = true;
            try
            {
                retval = Driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException e)
            {
                retval = false;
            }
            return retval;
        }

        protected int listPosToXpathSelector(int i)
        {
            return ++i;
        }

    }
}