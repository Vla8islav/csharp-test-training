using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : TestBaseWithLogin
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData data = new ContactData("TestName" + " modified")
            {
                MiddleName = "TestMiddleName" + " modified",
                LastName = "TestLastName" + " modified"
            };
            const int contactNumberToModify = 5;
            app.ContactHelper.PrepareANumberOfContacts(contactNumberToModify);

            app.NavigationHelper.OpenMainPage();
            app.ContactHelper.ModifyContactNumber(contactNumberToModify, data);
        }
    }
}