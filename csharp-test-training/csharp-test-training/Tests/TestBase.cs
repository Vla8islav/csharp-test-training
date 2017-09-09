using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class TestBase
    {
        protected ApplicationManager ApplicationManager;

        [SetUp]
        public void SetupTest()
        {
            if (null == ApplicationManager)
            {
                ApplicationManager = new ApplicationManager();
            }
        }

        public TestBase()
        {
            ApplicationManager = new ApplicationManager();
        }


        [TearDown]
        public void TeardownTest()
        {
            ApplicationManager.Stop();
        }
    }
}