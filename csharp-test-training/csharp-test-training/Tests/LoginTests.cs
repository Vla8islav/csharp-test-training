using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class LoginTests : TestBaseUi
    {

        [SetUp]
        public void SetUp()
        {
            app.LoginHelper.Logout();
        }

        [Test]
        public void LoginWithAdminCredentialsTest()
        {
            AccountData adminAccountData = AccountFactory.GetAdminAccountData();
            app.LoginHelper.Login(adminAccountData);
            Assert.IsTrue(app.LoginHelper.IsLoggedIn(adminAccountData));
        }
        
        [Test]
        public void LoginWithInvalidCredentialsTest()
        {
            AccountData adminAccountData = AccountFactory.GetInvalidAccountData();
            app.LoginHelper.Login(adminAccountData);
            Assert.IsFalse(app.LoginHelper.IsLoggedIn(adminAccountData));
        }
    }
}