using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager app) : base(app)
        {

        }
        public LoginHelper Logout()
        {
            Driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

        public LoginHelper SubmitLoginForm()
        {
            Driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return this;
        }

        public LoginHelper FillLoginForm(AccountData data)
        {
            FillField(By.Name("user"), data.Login);
            FillField(By.Name("pass"), data.Password);
            return this;
        }

    }
}