using NUnit.Framework;

namespace addressbook_web_tests
{
    public class TestBaseWithLogin : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            AccountData adminAccountData = app.AccountFactory.GetAdminAccountData();

            if (app.LoginHelper.CheckIfThisUserLoggedIn(adminAccountData))
            {
                return;
            }
            app.LoginHelper.Logout();
            app.LoginHelper.Login(adminAccountData);
        }
    }
}