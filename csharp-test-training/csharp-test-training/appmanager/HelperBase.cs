﻿using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class HelperBase
    {
        protected readonly IWebDriver Driver;
        protected readonly ApplicationManager app;

        public HelperBase(ApplicationManager app)
        {
            this.app = app;
            Driver = app.Driver;
        }

        public string CloseAlertAndGetItsText(bool accept)
        {
            try
            {
                IAlert alert = Driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (accept)
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
            }
        }

    }
}