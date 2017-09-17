using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactCreationTests : TestBaseWithLogin
    {
        [Test]
        public void ContactCreationTest()
        {
            app.NavigationHelper.GoToContactCreationPage();
            ContactData data = new ContactData("TestName")
            {
                MiddleName = "TestMiddleName",
                LastName = "TestLastName"
            };
            app.ContactHelper
                .FillContactForm(data)
                .SubmitContactData();
        }
    }
}