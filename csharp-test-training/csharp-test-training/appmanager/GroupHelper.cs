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
            Driver.FindElement(By.CssSelector($"[id=content] span:nth-of-type({i}) input[type=checkbox]")).Click();
            Driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();

            return this;
        }


    }
}