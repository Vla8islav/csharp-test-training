using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactTest : TestBase
    {

        [Test]
        public void CreateContactTest()
        {
            app.NavigationHelper.OpenMainPage();
            app.LoginHelper.FillLoginForm(app.AccountFactory.GetAdminAccountData());
            app.LoginHelper.SubmitLoginForm();

            app.NavigationHelper.GoToContactCreationPage();
            ContactData data = new ContactData("TestName");
            data.MiddleName = "TestMiddleName";
            data.LastName = "TestLastName";
            app.ContactHelper.FillContactForm(data);
            app.ContactHelper.SubmitContactData();
            app.LoginHelper.Logout();

        }
    }
}