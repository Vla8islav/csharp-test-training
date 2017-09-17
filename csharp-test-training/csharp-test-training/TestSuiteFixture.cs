using NUnit.Framework;

namespace addressbook_web_tests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        
        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
            app.NavigationHelper.OpenMainPage();
            app.LoginHelper.FillLoginForm(app.AccountFactory.GetAdminAccountData()).
                SubmitLoginForm();
    
        }

        [TearDown]
        public void StopApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
            app.LoginHelper.Logout();
        }

    }
}