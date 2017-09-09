using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class LoginHelper : HelperBase
    {

        public LoginHelper(IWebDriver driver) : base(driver)
        {

        }
        public void Logout()
        {
            Driver.FindElement(By.LinkText("Logout")).Click();
        }

        public void SubmitLoginForm()
        {
            Driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        public void FillLoginForm(AccountData data)
        {
            Driver.FindElement(By.Name("user")).Clear();
            Driver.FindElement(By.Name("user")).SendKeys(data.Login);
            Driver.FindElement(By.Name("pass")).Clear();
            Driver.FindElement(By.Name("pass")).SendKeys(data.Password);
        }

    }
}