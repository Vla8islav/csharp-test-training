using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactCheckDataTests : TestBaseWithLogin
    {
        [Test]
        public void ContactCreationTest()
        {
            CheckResultSet checkResultSet = new CheckResultSet();
            const int CONTACT_INDEX = 0;
            ContactData contactInfoFromList = app.ContactHelper.GetContactInfoFromList(CONTACT_INDEX);
            ContactData contactInfoFromEditForm = app.ContactHelper.GetContactInfoFromEditForm(CONTACT_INDEX);
            
            checkResultSet.Add(contactInfoFromList.Compare(contactInfoFromEditForm));
            checkResultSet.CheckTestResult();
        }

    }
}