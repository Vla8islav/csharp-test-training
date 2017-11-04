using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium;

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

        public void FillField(By locator, string text)
        {
            if (null != text)
            {
                Driver.FindElement(locator).Clear();
                Driver.FindElement(locator).SendKeys(text);
            }
        }
        
        public void FillField(IWebElement webElement, string text)
        {
            if (null != text)
            {
                webElement.Clear();
                webElement.SendKeys(text);
            }
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
        
        
        public bool IsElementDisplayed(By by)
        {
            bool retval = true;
            try
            {
                retval = Driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException e)
            {
                retval = false;
            }
            return retval;
        }

        protected int ListPosToXpathSelector(int i)
        {
            return ++i;
        }

        protected CheckResultSet CormpareTwoModelLists<T>(List<T> listFirst, List<T> listSecond,
            Func<T, T, CheckResult> compareAndGetTestResult)
        {
            CheckResultSet retval = new CheckResultSet();
            CheckResult compareListLength = CompareListLength(listFirst, listSecond);
            retval.Add(compareListLength);
            List<T> longestList = listSecond.Count >= listFirst.Count ? listSecond : listFirst;
            List<T> shortestList = listSecond.Count < listFirst.Count ? listSecond : listFirst;

            for (int i = 0; i < longestList.Count; i++)
            {
                T elementToCompare = default(T);
                if (i < shortestList.Count)
                {
                    elementToCompare = shortestList[i];
                }

                CheckResult currentCheckResult = compareAndGetTestResult(longestList[i], elementToCompare);
                retval.Add(currentCheckResult);
            }
            return retval;
        }

        
        private static CheckResult CompareListLength<T>(List<T> listFirst, List<T> listSecond)
        {
            CheckResult compareListLength = new CheckResult(listSecond.Count == listFirst.Count,
                $"First list length is {listFirst.Count}, second list length is {listSecond.Count}");
            return compareListLength;
        }
        
        public List<T> Sort<T>(List<T> list)
        {
            list.Sort();
            return list;
        }
        
        protected List<T> AddAndSort<T>(List<T> list, T data, Func<T, T> removeValuesNotShownInBrowserListPage)
        {
            data = removeValuesNotShownInBrowserListPage(data);
            list.Add(data);
            return Sort(list);
        }

        protected List<T> ModifyGroupNumberInList<T>(List<T> list, int i, T data, Func<T, T> removeValuesNotShownInBrowserListPage)
        {
            data = removeValuesNotShownInBrowserListPage(data);
            list[i] = data;
            return list;
        }
        
        public static string GetSolutionDirectoryFullPath()
        {
            return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "..\\..\\..\\"));
        }

        public static string GetDataFolderFullPath()
        {
            return Path.GetFullPath(Path.Combine(GetSolutionDirectoryFullPath(),
                "csharp-test-training\\Data\\"));
        }

        public static string GetDataFileFullPath(string filename)
        {
            return Path.GetFullPath(Path.Combine(GetDataFolderFullPath(), filename));
        }
        
        public static string GetJsonSchemaFolderFullPath()
        {
            return GetDataFolderFullPath();
        }
    }
}