using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace addressbook_web_tests
{
    [TestFixture]
    public class Untitled
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            FirefoxBinary firefox = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox_45_9_0_esr\firefox.exe");
            driver = new FirefoxDriver(firefox,
                new FirefoxProfile());
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheUntitledTest()
        {
            OpenMainPage();
            FillLoginForm(new AccountData("admin", "e3Zr14G14MoXkQ0TS8t8"));
            SubmitLoginForm();
            GoToGroupsPage();
            OpenCreateGroupPage();
            GroupData data = new GroupData("Some new goup");
            data.GroupHeader = "Some group header";
            data.GroupFooter = "Некоторый русский текст для разнообразия.";
            FillGroupForm(data);
            SubmitGroupForm();
            Logout();
        }

        private void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void FillGroupForm(GroupData data)
        {

            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(data.GroupName);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(data.GroupHeader);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(data.GroupFooter);
        }

        private void SubmitGroupForm()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void OpenCreateGroupPage()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        private void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        private void SubmitLoginForm()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void FillLoginForm(AccountData data)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(data.Login);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(data.Password);
        }

        private void OpenMainPage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
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
                acceptNextAlert = true;
            }
        }
    }

}