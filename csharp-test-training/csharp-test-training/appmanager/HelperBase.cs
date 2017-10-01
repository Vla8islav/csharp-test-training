using System;
using System.Collections.Generic;
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

        protected int listPosToXpathSelector(int i)
        {
            return ++i;
        }

        protected CheckResultSet CormpareTwoModelLists<T>(List<T> groupListPrev, List<T> groupListAfter,
            Func<T, T, CheckResult> myMethodName)
        {
            CheckResultSet retval = new CheckResultSet();
            CheckResult compareListLength = CompareListLength(groupListPrev, groupListAfter);
            retval.Add(compareListLength);
            List<T> longestList = groupListAfter.Count >= groupListPrev.Count ? groupListAfter : groupListPrev;
            List<T> shortestList = groupListAfter.Count < groupListPrev.Count ? groupListAfter : groupListPrev;

            for (int i = 0; i < longestList.Count; i++)
            {
                T elementToCompare = default(T);
                if (i < shortestList.Count)
                {
                    elementToCompare = shortestList[i];
                }

                CheckResult currentCheckResult = myMethodName(longestList[i], elementToCompare);
                retval.Add(currentCheckResult);
            }
            return retval;
        }

        
        private static CheckResult CompareListLength<T>(List<T> groupListPrev, List<T> groupListAfter)
        {
            CheckResult compareListLength = new CheckResult(groupListAfter.Count == groupListPrev.Count,
                $"First list length is {groupListPrev.Count}, second list length is {groupListAfter.Count}");
            return compareListLength;
        }
        
        public List<T> Sort<T>(List<T> groupList)
        {
            groupList.Sort();
            return groupList;
        }
        
        protected List<T> AddAndSort<T>(List<T> list, T data, Func<T, T> removeValuesNotInTheList)
        {
            data = removeValuesNotInTheList(data);
            list.Add(data);
            return Sort(list);
        }

        protected List<T> ModifyGroupNumberInList<T>(List<T> list, int i, T data, Func<T, T> removeValuesNotInTheList)
        {
            data = removeValuesNotInTheList(data);
            list[i] = data;
            return list;
        }

    }
}