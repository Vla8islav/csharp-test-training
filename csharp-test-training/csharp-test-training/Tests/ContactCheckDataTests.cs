using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactCheckDataTests : TestBaseWithLogin
    {
        [Test]
        public void ContactCreationTest()
        {
            List<ContactData> contactList = app.ContactHelper.GetContactList();
        }

    }
}