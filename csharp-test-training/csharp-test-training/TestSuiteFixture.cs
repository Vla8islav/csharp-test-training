using NUnit.Framework;

namespace addressbook_web_tests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        public static ApplicationManager app;
        
        [SetUp]
        public void InitApplicationManager()
        {
            app = new ApplicationManager();
            app.NavigationHelper.OpenMainPage();
            app.LoginHelper.FillLoginForm(app.AccountFactory.GetAdminAccountData()).
                SubmitLoginForm();
    
        }


        [TearDown]
        public void StopApplicationManager()
        {
            app.LoginHelper.Logout();
            app.Stop();
        }

    }
}