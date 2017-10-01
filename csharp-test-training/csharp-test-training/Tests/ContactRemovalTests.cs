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
            const int contactNumberToDelete = 3;
            app.ContactHelper.PrepareANumberOfContacts(contactNumberToDelete + 1);
            
            List<ContactData> contactListPrev = app.ContactHelper.GetContactList();
            app.ContactHelper.RemoveContactNumber(contactNumberToDelete);
            List<ContactData> contactListAfter = app.ContactHelper.GetContactList();

            List<ContactData> contactListExpected = contactListPrev; 
            contactListExpected.RemoveAt(contactNumberToDelete);
            
            app.ContactHelper.CormpareTwoContactLists(contactListAfter, contactListExpected).CheckTestResult();

        }
    }
}