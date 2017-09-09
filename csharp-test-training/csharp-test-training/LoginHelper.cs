using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class LoginHelper
    {
        private readonly IWebDriver _driver;

        public LoginHelper(IWebDriver driver)
        {
            _driver = driver;

        }
        public void Logout()
        {
            _driver.FindElement(By.LinkText("Logout")).Click();
        }

        public void SubmitLoginForm()
        {
            _driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        public void FillLoginForm(AccountData data)
        {
            _driver.FindElement(By.Name("user")).Clear();
            _driver.FindElement(By.Name("user")).SendKeys(data.Login);
            _driver.FindElement(By.Name("pass")).Clear();
            _driver.FindElement(By.Name("pass")).SendKeys(data.Password);
        }

    }
}