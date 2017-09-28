using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            FillField(By.Name("group_name"), data.GroupName);
            FillField(By.Name("group_header"), data.GroupHeader);
            FillField(By.Name("group_footer"), data.GroupFooter);
            
            return this;
        }

        public GroupHelper SubmitGroupForm()
        {
            Driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper RemoveFromTheListItemNumber(int i)
        {
            app.NavigationHelper.OpenGroupsPage();
            ClickCheckboxElementNumber(i);
            ClickOnDeleteButton();

            return this;
        }

        private GroupHelper ClickOnDeleteButton()
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
        
        public void PrepareANumberOfGroups(int i)
        {
            app.NavigationHelper.OpenGroupsPage();
            int numberOfDisplayedContacts = GetGroupList().Count;
            if (numberOfDisplayedContacts < i)
            {
                for (int j = 0; j < i - numberOfDisplayedContacts; j++)
                {
                    Create(GroupFactory.GetSampleGroupData());
                }
            }
        }
        
        public List<GroupData> GetGroupList()
        {
            app.NavigationHelper.OpenGroupsPage();
            List<GroupData> groupDataList = new List<GroupData>();

            ReadOnlyCollection<IWebElement> displayedGroups = Driver.FindElements(By.CssSelector("#content span.group"));

            foreach (var displayedGroup in displayedGroups)
            {
                groupDataList.Add(new GroupData{GroupName =  displayedGroup.Text});
            }
            
            return groupDataList;
        }
    }
}