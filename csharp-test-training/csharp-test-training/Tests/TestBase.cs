using NUnit.Framework;

namespace addressbook_web_tests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.NavigationHelper.OpenMainPage();
            app.LoginHelper.FillLoginForm(app.AccountFactory.GetAdminAccountData()).
                SubmitLoginForm();
        }

        [TearDown]
        public void TeardownTest()
        {
            app.LoginHelper.Logout();
            app.Stop();
        }
    }
}