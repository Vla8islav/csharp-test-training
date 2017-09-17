using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : TestBaseWithLogin
    {
        [Test]
        public void ContactRemovalTest()
        {
                app.ContactHelper.RemoveContactNumber(6);
        }
    }
}