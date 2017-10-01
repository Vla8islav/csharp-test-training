﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : TestBaseWithLogin
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData data = ContactFactory.GetContactDataWithUniqueValues();
            const int contactNumberToModify = 1;
            app.ContactHelper.PrepareANumberOfContacts(contactNumberToModify);

            List<ContactData> contactListPrev = app.ContactHelper.GetContactList();
            app.ContactHelper.ModifyContactNumber(contactNumberToModify, data);
            List<ContactData> contactListAfter = app.ContactHelper.GetContactList();
            
            
            List<ContactData> contactListExpected =
                app.ContactHelper.ModifyContactNumberInList(contactListPrev, contactNumberToModify, data);

            app.ContactHelper.CormpareTwoContactLists(
                    app.HelperBase.Sort(contactListAfter),
                    app.HelperBase.Sort(contactListExpected))
                .CheckTestResult();
            
        }
    }
}