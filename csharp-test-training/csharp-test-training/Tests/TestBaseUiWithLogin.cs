using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class TestBaseUiWithLogin : TestBaseUi
    {
        [SetUp]
        public void SetupLogin()
        {
            AccountData adminAccountData = AccountFactory.GetAdminAccountData();

            if (app.LoginHelper.CheckIfThisUserLoggedIn(adminAccountData))
            {
                return;
            }
            app.LoginHelper.Logout();
            app.LoginHelper.Login(adminAccountData);
        }

        [TearDown]
        public void CheckInterfaceAndDbDataMatch()
        {
#if PERSISTENT_UI_CHECK_AFTER_TEST
            List<ContactData> contactListDb = ContactData.GetAllActiveContacts();
            List<ContactData> contactListFront = app.ContactHelper.GetContactList();
            CheckResultSet contactCheckResultSet = app.ContactHelper.CormpareTwoContactLists(
                    app.HelperBase.Sort(contactListDb),
                    app.HelperBase.Sort(contactListFront));

            List<GroupData> groupListDb = GroupData.GetAllGroups();
            List<GroupData> groupListFront = app.GroupHelper.GetGroupList();
            CheckResultSet groupCheckResultSet = app.GroupHelper.CormpareGroupListsVisibleValues(
                    app.GroupHelper.Sort(groupListDb),
                    app.GroupHelper.Sort(groupListFront));

            contactCheckResultSet.Concatenate(groupCheckResultSet).CheckTestResult();
#endif
        }
    }
}