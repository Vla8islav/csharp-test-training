using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : TestBaseWithLogin
    {
        [Test]
        public void ContactRemovalTest()
        {
            const int contactNumberToDelete = 6;
            app.ContactHelper.PrepareANumberOfContacts(contactNumberToDelete);
            app.NavigationHelper.OpenMainPage();
            app.ContactHelper.RemoveContactNumber(contactNumberToDelete);
        }
    }
}