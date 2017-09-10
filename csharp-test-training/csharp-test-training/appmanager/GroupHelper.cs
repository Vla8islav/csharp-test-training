﻿using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(IWebDriver driver) : base(driver)
        {
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
    }
}