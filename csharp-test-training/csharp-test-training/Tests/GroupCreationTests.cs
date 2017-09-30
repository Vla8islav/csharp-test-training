using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBaseWithLogin
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData data = new GroupData
            {
                GroupName = "Some new goup",
                GroupHeader = "Some group header",
                GroupFooter = "Некоторый русский текст для разнообразия."
            };
            List<GroupData> groupListPrev = app.GroupHelper.GetGroupList();
            app.GroupHelper.Create(data);
            List<GroupData> groupListAfter = app.GroupHelper.GetGroupList();
            
            app.GroupHelper.CormpareTwoGroupLists(
                app.GroupHelper.AddAndSort(groupListPrev, data), 
                app.GroupHelper.Sort(groupListAfter))
                .CheckTestResult();
        }
        
        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData data = new GroupData
            {
                GroupName = "a'a",
                GroupHeader = "Some group header",
                GroupFooter = "Некоторый русский текст для разнообразия."
            };
            List<GroupData> groupListPrev = app.GroupHelper.GetGroupList();
            app.GroupHelper.Create(data);
            List<GroupData> groupListAfter = app.GroupHelper.GetGroupList();
            
            app.GroupHelper.CormpareTwoGroupLists(
                    app.GroupHelper.AddAndSort(groupListPrev, data), 
                    app.GroupHelper.Sort(groupListAfter))
                .CheckTestResult();
        }

        [Test]
        public void GroupCreationLeaveFooterIntactTest()
        {
            GroupData data = new GroupData
            {
                GroupName = "Some new goup",
                GroupHeader = "Some group header",
                GroupFooter = null
            };

            List<GroupData> groupListPrev = app.GroupHelper.GetGroupList();
            app.GroupHelper.Create(data);
            List<GroupData> groupListAfter = app.GroupHelper.GetGroupList();

            app.GroupHelper.CormpareTwoGroupLists(
                    app.GroupHelper.AddAndSort(groupListPrev, data), 
                    app.GroupHelper.Sort(groupListAfter))
                .CheckTestResult();
            
        }

        [Test]
        public void EmptyGroupCrationTest()
        {
            GroupData data = new GroupData
            {
                GroupName = "",
                GroupHeader = "",
                GroupFooter = ""
            };
            List<GroupData> groupListPrev = app.GroupHelper.GetGroupList();
            app.GroupHelper.Create(data);
            List<GroupData> groupListAfter = app.GroupHelper.GetGroupList();
            
            app.GroupHelper.CormpareTwoGroupLists(
                    app.GroupHelper.AddAndSort(groupListPrev, data), 
                    app.GroupHelper.Sort(groupListAfter))
                .CheckTestResult();
        }
    }
}