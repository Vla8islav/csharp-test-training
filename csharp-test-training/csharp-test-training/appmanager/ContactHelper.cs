﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using addressbook_web_tests.Pages;
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
            FillField(ContactCreationPage.FirstName, data.FirstName);
            FillField(ContactCreationPage.MiddleName, data.MiddleName);
            FillField(ContactCreationPage.LastName, data.LastName);
            FillField(ContactCreationPage.Email, data.EMail);
            FillField(ContactCreationPage.Address, data.Address);
            FillField(ContactCreationPage.TelephoneHome, data.TelephoneHome);
            FillField(ContactCreationPage.TelephoneMobile, data.TelephoneMobile);
            FillField(ContactCreationPage.TelephoneWork, data.TelephoneWork);
            FillField(ContactCreationPage.TelephoneFax, data.TelephoneFax);
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
            OpenContactEditForm(i);
            FillContactForm(data);
            ClickUpdateButton();

            return this;
        }

        public void PrepareContactWithIndex(int contactIndex)
        {
            app.NavigationHelper.OpenMainPage();
            int numberOfDisplayedContacts = GetNumberOfDisplayedContacts();
            int desiredNumberOfDisplayedContacts = contactIndex + 1;
            if (numberOfDisplayedContacts < desiredNumberOfDisplayedContacts)
            {
                for (int j = 0; j < desiredNumberOfDisplayedContacts - numberOfDisplayedContacts; j++)
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
        
        public List<ContactData> GetContactList()
        {
            if (_contactCache == null)
            {
                _contactCache = new List<ContactData>();
                app.NavigationHelper.OpenMainPage();
                ReadOnlyCollection<IWebElement> displayedContacts = Driver.FindElements(By.CssSelector("#maintable tr[name=entry]"));

                foreach (var displayedContact in displayedContacts)
                {
                    IWebElement idElement = displayedContact.FindElement(By.CssSelector("td:nth-child(1) input"));
                    IWebElement lastNameElement = displayedContact.FindElement(By.CssSelector("td:nth-child(2)"));
                    IWebElement firstNameElement = displayedContact.FindElement(By.CssSelector("td:nth-child(3)"));
                    IWebElement addressElement = displayedContact.FindElement(By.CssSelector("td:nth-child(4)"));
                    IWebElement emailElement = displayedContact.FindElement(By.CssSelector("td:nth-child(5)"));
                    IWebElement phoneElement = displayedContact.FindElement(By.CssSelector("td:nth-child(6)"));
                
                    _contactCache.Add(new ContactData
                    {
                        Id = Int32.Parse(idElement.GetAttribute("id")),
                        LastName =  lastNameElement.Text,
                        FirstName =  firstNameElement.Text,
                        Address =  addressElement.Text,
                        // TODO: Add email and phone parser
                        EMailString = emailElement.Text,
                        TelephoneString =  phoneElement.Text,
                    
                    });
                }
            }
            
            return new List<ContactData>(_contactCache);
        }

        public ContactData GetContactInfoFromList(int contactIndex)
        {
            if (GetContactList().Count > contactIndex)
            {
                return GetContactList()[contactIndex];
            }
            return null;
        }
        
        public ContactData GetContactInfoFromEditForm(int contactIndex)
        {
            OpenContactEditForm(contactIndex);
            
            return new ContactData
            {
                Id = Int32.Parse(Driver.FindElement(ContactCreationPage.Id).GetAttribute("value")),
                FirstName = Driver.FindElement(ContactCreationPage.FirstName).GetAttribute("value"),
                MiddleName = Driver.FindElement(ContactCreationPage.MiddleName).GetAttribute("value"),
                LastName = Driver.FindElement(ContactCreationPage.LastName).GetAttribute("value"),
                Nickname = Driver.FindElement(ContactCreationPage.Nickname).GetAttribute("value"),
                Company = Driver.FindElement(ContactCreationPage.Company).GetAttribute("value"),
                Title = Driver.FindElement(ContactCreationPage.Title).GetAttribute("value"),
                Address = Driver.FindElement(ContactCreationPage.Address).GetAttribute("value"),
                TelephoneHome = Driver.FindElement(ContactCreationPage.TelephoneHome).GetAttribute("value"),
                TelephoneMobile = Driver.FindElement(ContactCreationPage.TelephoneMobile).GetAttribute("value"),
                TelephoneWork = Driver.FindElement(ContactCreationPage.TelephoneWork).GetAttribute("value"),
                TelephoneFax = Driver.FindElement(ContactCreationPage.TelephoneFax).GetAttribute("value"),
                EMail = Driver.FindElement(ContactCreationPage.Email).GetAttribute("value"),
                EMail2 = Driver.FindElement(ContactCreationPage.Email2).GetAttribute("value"),
                EMail3 = Driver.FindElement(ContactCreationPage.Email3).GetAttribute("value"),
                Homepage = Driver.FindElement(ContactCreationPage.Homepage).GetAttribute("value"),
                
            };
        }

        private ContactData RemoveValuesWhichArentShownInGroupList(ContactData contactData)
        {
            contactData.MiddleName = null;
            contactData.Nickname = null;
            contactData.Photo = null;
            contactData.Title = null;
            contactData.Company = null;
            contactData.TelephoneHome = null;
            contactData.TelephoneMobile = null;
            contactData.TelephoneWork = null;
            contactData.TelephoneFax = null;
//            contactData.EMail = null;
//            contactData.EMail2 = null;
//            contactData.EMail3 = null;
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

        public static List<ContactData> GetElementsWithDiffId(List<ContactData> f, List<ContactData> s)
        {

            var result = s.Where(p => !f.Any(p2 => p2.Id == p.Id));
            return new List<ContactData>(result);
        }

        public static int? GetIdInOnlyOneList(List<ContactData> contactListPrev, List<ContactData> contactListAfter)
        {
            var litsDiffs = GetElementsWithDiffId(contactListPrev, contactListAfter);
            if (litsDiffs.Count > 0)
            {
                return litsDiffs.First().Id;
            }
            return null;
        }

        public static int? GuessIdOfNewElement(List<ContactData> contactListPrev, List<ContactData> contactListAfter)
        {
            int? newId = GetIdInOnlyOneList(contactListPrev, contactListAfter);
            return newId;
        }

        private void OpenContactEditForm(int contactIndex)
        {
            app.NavigationHelper.OpenMainPage();
            ClickOnModifyPencilPictogammNumber(contactIndex);
        }

        public string GetContactInfoFromViewForm(int contactIndex)
        {
            
            app.NavigationHelper.OpenMainPage();
            ClickOnPesonPictogammNumber(contactIndex);
            return Driver.FindElement(By.CssSelector("#content")).Text;
           
        }

        private ContactHelper ClickOnPesonPictogammNumber(int i)
        {
            Driver.FindElement(By.CssSelector($"table[id=maintable] tr:nth-of-type({ListPosToXpathSelector(i + 1)}) img[title=Details]")).Click();
            return this;
        }
        
        
            

    }
}