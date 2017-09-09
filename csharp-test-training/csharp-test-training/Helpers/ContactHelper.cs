using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class ContactHelper
    {
        protected IWebDriver Driver;

        public ContactHelper(IWebDriver driver)
        {
            Driver = driver;
        }

        public void SubmitContactData()
        {
            Driver.FindElement(By.Name("submit")).Click();
        }

        public void FillContactForm(ContactData data)
        {
            Driver.FindElement(By.Name("firstname")).Clear();
            Driver.FindElement(By.Name("firstname")).SendKeys(data.FirstName);
            Driver.FindElement(By.Name("middlename")).Clear();
            Driver.FindElement(By.Name("middlename")).SendKeys(data.MiddleName);
            Driver.FindElement(By.Name("lastname")).Clear();
            Driver.FindElement(By.Name("lastname")).SendKeys(data.LastName);
        }

    }
}