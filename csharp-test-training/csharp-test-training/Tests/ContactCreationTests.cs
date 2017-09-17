using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactCreationTests : TestBaseWithLogin
    {
        [Test]
        public void ContactCreationTest()
        {
            app.ContactHelper.Create(ContactFactory.GetSampleContactData());
        }
    }
}