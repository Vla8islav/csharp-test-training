﻿using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : TestBaseUiWithLogin
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData data = GroupFactory.GetGroupDataByInstanceNameFromJson("GroupForModification");
            int groupNumberToModify = 5;
            app.GroupHelper.PrepareANumberOfGroups(groupNumberToModify);

            List<GroupData> groupListPrev = GroupData.GetAllGroups();
            data.Id = groupListPrev[groupNumberToModify].Id;
            app.GroupHelper.ModifyGroup(groupListPrev[groupNumberToModify], data);
            List<GroupData> groupListAfter = GroupData.GetAllGroups();

            
            List<GroupData> groupListExpected =
                app.GroupHelper.ModifyGroupInList(groupListPrev, groupListPrev[groupNumberToModify], data);

            app.GroupHelper.CormpareGroupListsVisibleValues(
                    app.GroupHelper.Sort(groupListAfter),
                    app.GroupHelper.Sort(groupListExpected))
                .CheckTestResult();
        }
    }
}