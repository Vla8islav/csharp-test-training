using System.Collections.Generic;
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
            
            app.ContactHelper.RemoveContactNumber(contactNumberToDelete);

            
        }
    }
}