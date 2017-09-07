using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateGroupTest
    {
        private IWebDriver _driver;
        private StringBuilder _verificationErrors;
        private string _baseUrl;
        private AccountFactory _accountFactory;

        public CreateGroupTest()
        {
            _accountFactory = new AccountFactory();
        }

        [SetUp]
        public void SetupTest()
        {
            FirefoxDriverFactory driverFactory = new FirefoxDriverFactory();
            TestingEnvironment environment = new TestingEnvironment();

            _driver = driverFactory.GetFirefoxDriver();
            _baseUrl = environment.BaseUrl;
            _verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                _driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", _verificationErrors.ToString());
        }

        [Test]
        public void TheUntitledTest()
        {
            OpenMainPage();
            FillLoginForm(_accountFactory.GetAdminAccountData());
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
            _driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void FillGroupForm(GroupData data)
        {
            _driver.FindElement(By.Name("group_name")).Clear();
            _driver.FindElement(By.Name("group_name")).SendKeys(data.GroupName);
            _driver.FindElement(By.Name("group_header")).Clear();
            _driver.FindElement(By.Name("group_header")).SendKeys(data.GroupHeader);
            _driver.FindElement(By.Name("group_footer")).Clear();
            _driver.FindElement(By.Name("group_footer")).SendKeys(data.GroupFooter);
        }

        private void SubmitGroupForm()
        {
            _driver.FindElement(By.Name("submit")).Click();
        }

        private void OpenCreateGroupPage()
        {
            _driver.FindElement(By.Name("new")).Click();
        }

        private void GoToGroupsPage()
        {
            _driver.FindElement(By.LinkText("groups")).Click();
        }

        private void SubmitLoginForm()
        {
            _driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void FillLoginForm(AccountData data)
        {
            _driver.FindElement(By.Name("user")).Clear();
            _driver.FindElement(By.Name("user")).SendKeys(data.Login);
            _driver.FindElement(By.Name("pass")).Clear();
            _driver.FindElement(By.Name("pass")).SendKeys(data.Password);
        }

        private void OpenMainPage()
        {
            _driver.Navigate().GoToUrl(_baseUrl + "addressbook/");
        }
    }
}