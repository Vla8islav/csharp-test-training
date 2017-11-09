using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : TestBaseUiWithLogin
    {
        [Test]
        public void ContactRemovalTest()
        {
            const int contactNumberToDelete = 3;
            app.ContactHelper.PrepareContactWithIndex(contactNumberToDelete + 1);
            
            List<ContactData> contactListPrev = ContactData.GetAllActiveContacts();
            app.ContactHelper.RemoveContact(contactListPrev[contactNumberToDelete]);
            List<ContactData> contactListAfter = ContactData.GetAllActiveContacts();

            List<ContactData> contactListExpected = contactListPrev; 
            contactListExpected.RemoveAt(contactListExpected.IndexOf(contactListPrev[contactNumberToDelete]));
            
            app.ContactHelper.CormpareTwoContactLists(contactListAfter, contactListExpected).CheckTestResult();

        }
    }
}