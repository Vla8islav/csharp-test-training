using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            _contactCache = null;
            Driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData data)
        {
            FillField(By.Name("firstname"), data.FirstName);
            FillField(By.Name("middlename"), data.MiddleName);
            FillField(By.Name("lastname"), data.LastName);
            FillField(By.Name("email"), data.EMail);
            return this;
        }

        public ContactHelper RemoveContactNumber(int i)
        {
            _contactCache = null;
            app.NavigationHelper.OpenMainPage();
            ClickCheckboxElementNumber(i);
            ClickDeleteButton();
            ConfirmDeletion();
            return this;
        }

        private ContactHelper ClickCheckboxElementNumber(int i)
        {
            Driver.FindElement(By.CssSelector($"table[id=maintable] tr:nth-of-type({ListPosToXpathSelector(i + 1)}) input[type='checkbox']"))
                .Click();
            return this;
        }

        private ContactHelper ClickDeleteButton()
        {
            _contactCache = null;
            Driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        private ContactHelper ConfirmDeletion()
        {
            _contactCache = null;
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(true), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }

        private ContactHelper ClickUpdateButton()
        {
            _contactCache = null;
            Driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private ContactHelper ClickOnModifyPencilPictogammNumber(int i)
        {
            Driver.FindElement(By.CssSelector($"table[id=maintable] tr:nth-of-type({ListPosToXpathSelector(i + 1)}) img[title=Edit]")).Click();
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
            app.NavigationHelper.OpenMainPage();
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
                    Create(ContactFactory.GetContactDataWithUniqueValues());
                }
            }
        }

        private int GetNumberOfDisplayedContacts()
        {
            return Driver.FindElements(By.CssSelector("#maintable tr[name='entry']")).Count;
        }

        private List<ContactData> _contactCache = null;
        
        public List<ContactData>  GetContactList()
        {
            if (_contactCache == null)
            {
                _contactCache = new List<ContactData>();
                app.NavigationHelper.OpenMainPage();

                ReadOnlyCollection<IWebElement> displayedContacts = Driver.FindElements(By.CssSelector("#maintable tr[name=entry]"));

                foreach (var displayedContact in displayedContacts)
                {
                    IWebElement lastNameElement = displayedContact.FindElement(By.CssSelector("td:nth-child(2)"));
                    IWebElement firstNameElement = displayedContact.FindElement(By.CssSelector("td:nth-child(3)"));
                    IWebElement addressElement = displayedContact.FindElement(By.CssSelector("td:nth-child(4)"));
                    IWebElement emailElement = displayedContact.FindElement(By.CssSelector("td:nth-child(5)"));
                    IWebElement phoneElement = displayedContact.FindElement(By.CssSelector("td:nth-child(6)"));
                
                    _contactCache.Add(new ContactData
                    {
                        LastName =  lastNameElement.Text,
                        FirstName =  firstNameElement.Text,
                        Address =  addressElement.Text,
                        // TODO: Add email and phone parser
                        EMail = emailElement.Text,
                        Telephone =  phoneElement.Text,
                    
                    });
                }
            }
            
            return new List<ContactData>(_contactCache);
        }
        
        private ContactData RemoveValuesWhichArentShownInGroupList(ContactData contactData)
        {
            contactData.MiddleName = null;
            contactData.Nickname = null;
            contactData.Photo = null;
            contactData.Title = null;
            contactData.Company = null;
            contactData.Home = null;
            contactData.Mobile = null;
            contactData.Work = null;
            contactData.Fax = null;
            contactData.EMail2 = null;
            contactData.EMail3 = null;
            contactData.Homepage = null;
            contactData.Birthday = null;
            contactData.Anniversary = null;
            contactData.Group = null;
            contactData.Secondary = null;
            contactData.SecondaryAddress = null;
            contactData.SecondaryHome = null;
            contactData.Notes = null;
            
            return contactData;
        }
        
        public CheckResultSet CormpareTwoContactLists(List<ContactData> contactListPrev, List<ContactData> contactListAfter)
        {
            return CormpareTwoModelLists(contactListPrev, contactListAfter,
                (firstContactData, secondContactData) => firstContactData.Compare(secondContactData));
        }

        public List<ContactData> ModifyContactNumberInList(List<ContactData> contactListPrev, int contactNumberToModify, ContactData data)
        {
            return ModifyGroupNumberInList(contactListPrev, contactNumberToModify, data, RemoveValuesWhichArentShownInGroupList);;
        }
    }
}