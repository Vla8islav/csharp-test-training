using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactTest : TestBase
    {
        [Test]
        public void CreateContactTest()
        {
            app.NavigationHelper.OpenMainPage();
            app.LoginHelper.FillLoginForm(app.AccountFactory.GetAdminAccountData())
                .SubmitLoginForm();

            app.NavigationHelper.GoToContactCreationPage();

            ContactData data = new ContactData("TestName")
            {
                MiddleName = "TestMiddleName",
                LastName = "TestLastName"
            };

            app.ContactHelper.FillContactForm(data)
                .SubmitContactData();

            app.LoginHelper.Logout();
        }
    }
}