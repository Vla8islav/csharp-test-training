using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactInGroupsTests : TestBaseUiWithLogin
    {
        [Test]
        public void AddContactToGroupTest()
        {
            GroupData g = GroupData.GetAllGroups()[0];
            List<ContactData> contactListPrev = g.GetContacts();
            ContactData c = ContactData.GetAllActiveContacts().Except(contactListPrev).First();

            app.ContactHelper.AddContactToGroup(c, g);

            List<ContactData> contactListAfter = g.GetContacts();
            List<ContactData> contactListExpected = contactListPrev;

            contactListExpected.Add(c);

            app.ContactHelper.CormpareTwoContactLists(
                    app.HelperBase.Sort(contactListAfter),
                    app.HelperBase.Sort(contactListExpected))
                .CheckTestResult();
        }

        [Test]
        public void RemoveContactFromGroupTest()
        {
            ContactData c = ContactData.GetAllActiveContacts().First(co => co.GetGroups().Count > 0);
            List<GroupData> currentContactGroupDatas = c.GetGroups();

            app.ContactHelper.RemoveContactFromGroup(c, currentContactGroupDatas[0]);

            List<GroupData> afterDeletionContactGroupDatas = c.GetGroups();

            List<GroupData> expectedContactGroupDatas = currentContactGroupDatas;
            expectedContactGroupDatas.Remove(currentContactGroupDatas[0]);

            app.GroupHelper.CormpareGroupListsVisibleValues(
                    app.GroupHelper.Sort(afterDeletionContactGroupDatas),
                    app.GroupHelper.Sort(expectedContactGroupDatas))
                .CheckTestResult();
        }
    }
}