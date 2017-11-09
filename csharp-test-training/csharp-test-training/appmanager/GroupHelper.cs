using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using LinqToDB;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager app) : base(app)
        {
        }

        public GroupHelper Create(GroupData data)
        {
            app.NavigationHelper.OpenGroupCreationPage();

            FillGroupForm(data);
            SubmitGroupForm();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData data)
        {
            FillField(By.Name("group_name"), data.Name);
            FillField(By.Name("group_header"), data.Header);
            FillField(By.Name("group_footer"), data.Footer);

            return this;
        }

        public GroupHelper SubmitGroupForm()
        {
            Driver.FindElement(By.Name("submit")).Click();
            _groupCache = null;
            return this;
        }

        public GroupHelper RemoveFromTheListItemNumber(int i)
        {
            app.NavigationHelper.OpenGroupsPage();
            ClickCheckboxElement(i);
            ClickOnDeleteButton();

            return this;
        }

        public GroupHelper RemoveFromTheListItemNumber(GroupData groupData)
        {
            app.NavigationHelper.OpenGroupsPage();
            ClickCheckboxElement(groupData);
            ClickOnDeleteButton();

            return this;
        }

        private GroupHelper ClickOnDeleteButton()
        {
            _groupCache = null;
            Driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            return this;
        }

        private GroupHelper ClickCheckboxElement(int groupIndex)
        {
            string selector =
                $"[id=content] span:nth-of-type({ListPosToXpathSelector(groupIndex)}) input[type=checkbox]";
            Driver.FindElement(By.CssSelector(selector)).Click();
            return this;
        }

        private GroupHelper ClickCheckboxElement(GroupData group)
        {
            string selector = $".group input[value='{group.Id}']";
            Driver.FindElement(By.CssSelector(selector)).Click();
            return this;
        }

        public GroupHelper ModifyGroup(int i, GroupData newGroup)
        {
            app.NavigationHelper.OpenGroupsPage();
            ClickCheckboxElement(i);
            ClickOnModifyButton();
            FillGroupForm(newGroup);
            ClickOnUpdateButton();
            return this;
        }

        public GroupHelper ModifyGroup(GroupData groupToModify, GroupData newGroup)
        {
            app.NavigationHelper.OpenGroupsPage();
            ClickCheckboxElement(groupToModify);
            ClickOnModifyButton();
            FillGroupForm(newGroup);
            ClickOnUpdateButton();
            return this;
        }

        public GroupHelper ClickOnModifyButton()
        {
            Driver.FindElement(By.Name("edit")).Click();
            _groupCache = null;
            return this;
        }

        public GroupHelper ClickOnUpdateButton()
        {
            Driver.FindElement(By.Name("update")).Click();
            _groupCache = null;
            return this;
        }

        public void PrepareANumberOfGroups(int groupIndex)
        {
            app.NavigationHelper.OpenGroupsPage();
            int numberOfDisplayedGroups = GetGroupList().Count;
            int numberOfGroupsThatShouldBeDisplayed = groupIndex + 1;
            if (numberOfDisplayedGroups < numberOfGroupsThatShouldBeDisplayed)
            {
                for (int j = 0; j < numberOfGroupsThatShouldBeDisplayed - numberOfDisplayedGroups; j++)
                {
                    Create(GroupFactory.GetSampleGroupData());
                }
            }
        }

        private List<GroupData> _groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (null == _groupCache)
            {
                _groupCache = new List<GroupData>();
                app.NavigationHelper.OpenGroupsPage();

                ReadOnlyCollection<IWebElement>
                    displayedGroups = Driver.FindElements(By.CssSelector("#content span.group"));

                foreach (var displayedGroup in displayedGroups)
                {
                    _groupCache.Add(new GroupData
                    {
                        Name = displayedGroup.Text,
                        Id = Int32.Parse(displayedGroup.FindElement(By.CssSelector("input")).GetAttribute("value"))
                    });
                }
            }

            return new List<GroupData>(_groupCache);
        }

        public CheckResultSet CormpareGroupLists(List<GroupData> groupListPrev, List<GroupData> groupListAfter)
        {
            return CormpareTwoModelLists(groupListPrev, groupListAfter,
                (firstGroupData, secondGroupData) => firstGroupData.Compare(secondGroupData));
        }

        public CheckResultSet CormpareGroupListsVisibleValues(List<GroupData> gl1, List<GroupData> gl2)
        {
            return app.GroupHelper.CormpareTwoModelLists(gl1, gl2,
                (g1, g2) => new CheckResult(g1.Id == g2.Id && g1.Name == g2.Name,
                    $"{g1.Id} == {g2.Id} && {g1.Name} == {g2.Name}")
            );
        }

        public CheckResultSet CormpareGroupListsNames(List<GroupData> g1, List<GroupData> g2)
        {
            return CormpareTwoModelLists(g1, g2,
                (g1D, g2D) => g1D.CompareNames(g2D));
        }

        private GroupData RemoveValuesWhichArentShownInGroupList(GroupData groupData)
        {
            groupData.Footer = null;
            groupData.Header = null;
            return groupData;
        }

        public List<GroupData> ModifyGroupInList(List<GroupData> groupList, GroupData groupToModify, GroupData data)
        {
            // This should work, but it doesn't 
            // int elementIndex = groupList.IndexOf(groupList.First(g => g.Id == groupToModify.Id)); 
            int elementIndex = 0;
            for (; elementIndex < groupList.Count; elementIndex++)
            {
                if (groupList[elementIndex].Id == groupToModify.Id)
                {
                    break;
                }
            }
            return ModifyGroupInList(groupList, 
                elementIndex,
                data);
        }

        public List<GroupData> ModifyGroupInList(List<GroupData> groupList, int i, GroupData data)
        {
            return ModifyGroupNumberInList(groupList, i, data, RemoveValuesWhichArentShownInGroupList);
        }


        public List<GroupData> AddAndSort(List<GroupData> groupListPrev, GroupData data)
        {
            AddAndSort(groupListPrev, data, RemoveValuesWhichArentShownInGroupList);
            return Sort(groupListPrev);
        }
    }
}