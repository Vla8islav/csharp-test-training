﻿using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class HelperBase
    {
        protected readonly IWebDriver Driver;

        public HelperBase(IWebDriver driver)
        {
            Driver = driver;

        }

    }
}