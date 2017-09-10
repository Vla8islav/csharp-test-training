using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager app) : base(app)
        {
        }

        public GroupHelper Create(GroupData data)
        {
            app.NavigationHelper
                .GoToGroupsPage()
                .OpenCreateGroupPage();

            FillGroupForm(data);
            SubmitGroupForm();
            return this;
        }


        public GroupHelper FillGroupForm(GroupData data)
        {
            Driver.FindElement(By.Name("group_name")).Clear();
            Driver.FindElement(By.Name("group_name")).SendKeys(data.GroupName);
            Driver.FindElement(By.Name("group_header")).Clear();
            Driver.FindElement(By.Name("group_header")).SendKeys(data.GroupHeader);
            Driver.FindElement(By.Name("group_footer")).Clear();
            Driver.FindElement(By.Name("group_footer")).SendKeys(data.GroupFooter);
            return this;
        }

        public GroupHelper SubmitGroupForm()
        {
            Driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper RemoveFromTheListItemNumber(int i)
        {
            app.NavigationHelper.GoToGroupsPage();
            ClickCheckboxElementNumber(i);
            SubmitDelete();

            return this;
        }

        private GroupHelper SubmitDelete()
        {
            Driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            return this;
        }

        private GroupHelper ClickCheckboxElementNumber(int i)
        {
            Driver.FindElement(By.CssSelector($"[id=content] span:nth-of-type({i}) input[type=checkbox]")).Click();
            return this;
        }

        public GroupHelper ModifyGroupNumber(int i, GroupData data)
        {
            app.NavigationHelper.GoToGroupsPage();
            ClickCheckboxElementNumber(i);
            ClickOnModifyButton();
            FillGroupForm(data);
            ClickOnUpdateButton();
            return this;
        }

        public GroupHelper ClickOnModifyButton()
        {
            Driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper ClickOnUpdateButton()
        {
            Driver.FindElement(By.Name("update")).Click();
            return this;
        }
    }
}