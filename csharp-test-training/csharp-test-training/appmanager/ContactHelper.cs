using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager app) : base(app)
        {
        }

        public ContactHelper SubmitContactData()
        {
            Driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData data)
        {
            FillField(By.Name("firstname"), data.FirstName);
            FillField(By.Name("middlename"), data.MiddleName);
            FillField(By.Name("lastname"), data.LastName);
            return this;
        }

        public ContactHelper RemoveContactNumber(int i)
        {
            ClickCheckboxElementNumber(i);
            ClickDeleteButton();
            ConfirmDeletion();
            return this;
        }

        private ContactHelper ClickCheckboxElementNumber(int i)
        {
            Driver.FindElement(By.CssSelector($"table[id=maintable] tr:nth-of-type({++i}) input[type='checkbox']"))
                .Click();
            return this;
        }

        private ContactHelper ClickDeleteButton()
        {
            Driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        private ContactHelper ConfirmDeletion()
        {
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(true), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }

        private ContactHelper ClickUpdateButton()
        {
            Driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private ContactHelper ClickOnModifyPencilPictogammNumber(int i)
        {
            Driver.FindElement(By.CssSelector($"table[id=maintable] tr:nth-of-type({++i}) img[title=Edit]")).Click();
            return this;
        }

        public ContactHelper Create(ContactData data)
        {
            app.NavigationHelper.OpenContactCreationPage();
            app.ContactHelper
                .FillContactForm(data)
                .SubmitContactData();

            return this;

        }

        public ContactHelper ModifyContactNumber(int i, ContactData data)
        {
            ClickOnModifyPencilPictogammNumber(i);
            FillContactForm(data);
            ClickUpdateButton();

            return this;
        }

        public void PrepareANumberOfContacts(int i)
        {
            app.NavigationHelper.OpenMainPage();
            int numberOfDisplayedContacts = GetNumberOfDisplayedContacts();
            if (numberOfDisplayedContacts < i)
            {
                for (int j = 0; j < i - numberOfDisplayedContacts; j++)
                {
                    Create(ContactFactory.GetSampleContactData());
                }
            }
        }

        private int GetNumberOfDisplayedContacts()
        {
            return Driver.FindElements(By.CssSelector("#maintable tr[name='entry']")).Count;
        }
    }
}