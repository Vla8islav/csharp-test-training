﻿using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactCreationTests : TestBaseWithLogin
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData newContactData = ContactFactory.GetSampleContactData();
            
            List<ContactData> contactListPrev = app.ContactHelper.GetContactList();
            app.ContactHelper.Create(newContactData);
            List<ContactData> contactListAfter = app.ContactHelper.GetContactList();

            List<ContactData> contactListExpected = contactListPrev;
            newContactData.Id = ContactHelper.GuessIdOfNewElement(contactListPrev, contactListAfter);
            contactListExpected.Add(newContactData);

            app.ContactHelper.CormpareTwoContactLists(
                    app.HelperBase.Sort(contactListAfter),
                    app.HelperBase.Sort(contactListExpected))
                .CheckTestResult();
        }
    }
}