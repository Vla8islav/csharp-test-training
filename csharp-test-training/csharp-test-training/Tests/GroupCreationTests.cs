﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBaseWithLogin
    {

        [Test, TestCaseSource(nameof(GroupFactory.GroupDataProvider))]
        public void GroupCreationTest(Tuple<GroupData,string> dataTuple)
        {
            GroupData data = dataTuple.Item1;
            List<GroupData> groupListPrev = app.GroupHelper.GetGroupList();
            app.GroupHelper.Create(data);
            List<GroupData> groupListAfter = app.GroupHelper.GetGroupList();
            
            app.GroupHelper.CormpareGroupLists(
                    app.GroupHelper.AddAndSort(groupListPrev, data), 
                    app.GroupHelper.Sort(groupListAfter))
                .CheckTestResult();
        }
        
        [Test]
        public void TestDbConnectivity()
        {
            List<GroupData> fromWeb = app.GroupHelper.GetGroupList();
            List<GroupData> fromDb = app.GroupHelper.GetGroupListDb();
            

            app.GroupHelper.CormpareGroupListsNames(
                    app.GroupHelper.Sort(fromWeb), 
                    app.GroupHelper.Sort(fromDb))
                .CheckTestResult();
        }
    }
}