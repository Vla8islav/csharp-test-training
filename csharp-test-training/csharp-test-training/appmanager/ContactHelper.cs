﻿using System.Text.RegularExpressions;
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
            Driver.FindElement(By.Name("firstname")).Clear();
            Driver.FindElement(By.Name("firstname")).SendKeys(data.FirstName);
            Driver.FindElement(By.Name("middlename")).Clear();
            Driver.FindElement(By.Name("middlename")).SendKeys(data.MiddleName);
            Driver.FindElement(By.Name("lastname")).Clear();
            Driver.FindElement(By.Name("lastname")).SendKeys(data.LastName);
            return this;
        }

        public ContactHelper RemoveContactNumber(int i)
        {
            app.NavigationHelper.OpenMainPage();
            ClickCheckboxElementNumber(i);
            ClickDeleteButton();
            ConfirmDeletion();
            return this;
        }

        private ContactHelper ClickCheckboxElementNumber(int i)
        {
            Driver.FindElement(By.CssSelector($"table[id=maintable] tr:nth-of-type({++i}) input[type='checkbox']")).Click();
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

        public ContactHelper ModifyContactNumber(int i, ContactData data)
        {
            app.NavigationHelper.OpenMainPage();
            ClickOnModifyPencilPictogammNumber(i);
            FillContactForm(data);
            ClickUpdateButton();

            return this;
        }
    }
}