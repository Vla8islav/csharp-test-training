using System;
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
            if (IsLoggedIn())
            {
                Driver.FindElement(By.LinkText("Logout")).Click();
            }
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


        public bool IsLoggedIn(AccountData data)
        {
            bool retval = IsLoggedIn();

            if (retval)
            {
                string usernameDisplayedElementText = Driver.FindElement(By.XPath("//*[@id='top']/form/b")).Text;
                string usernameDisplayed = usernameDisplayedElementText.Trim('(', ' ', ')');
                retval = usernameDisplayed.Equals(data.Login);
            }

            return retval;
        }

        public bool IsLoggedIn()
        {
            return IsElementDisplayed(By.CssSelector("#top form[name='logout']"));
        }
        
        public bool CheckIfThisUserLoggedIn(AccountData accountData)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(accountData))
                {
                    return true;
                }
            }
            return false;
        }

        public LoginHelper Login(AccountData accountData)
        {
            app.LoginHelper.
                FillLoginForm(accountData).
                SubmitLoginForm();

            return this;
        }
            
    }
}