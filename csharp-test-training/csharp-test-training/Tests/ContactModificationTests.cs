using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : TestBaseUiWithLogin
    {
        [Test]
        public void ContactModificationTest()
        {
            const int contactNumberToModify = 1;
            ContactData data = ContactFactory.GetContactDataWithUniqueValues();
            app.ContactHelper.PrepareContactWithIndex(contactNumberToModify);

            List<ContactData> contactListPrev = ContactData.GetAllActiveContacts();
            
            data.Id = contactListPrev[contactNumberToModify].Id;
            app.ContactHelper.ModifyContact(contactListPrev[contactNumberToModify], data);
            
            List<ContactData> contactListAfter = ContactData.GetAllActiveContacts();
            
            List<ContactData> contactListExpected = contactListPrev;
            contactListExpected[contactNumberToModify] = data;
                

            app.ContactHelper.CormpareTwoContactLists(
                    app.HelperBase.Sort(contactListAfter),
                    app.HelperBase.Sort(contactListExpected))
                .CheckTestResult();
            
        }
    }
}