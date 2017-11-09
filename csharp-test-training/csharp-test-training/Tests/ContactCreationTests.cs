using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactCreationTests : TestBaseUiWithLogin
    {
        [Test, TestCaseSource(nameof(ContactDataProvider))]
        public void ContactCreationTest(Tuple<ContactData,string> dataTuple)
        {
            ContactData newContactData = dataTuple.Item1;
            
            List<ContactData> contactListPrev = ContactData.GetAllActiveContacts();
            app.ContactHelper.Create(newContactData);
            List<ContactData> contactListAfter = ContactData.GetAllActiveContacts();

            List<ContactData> contactListExpected = contactListPrev;
            newContactData.Id = ContactHelper.GuessIdOfNewElement(new List<ModelWithId>(contactListPrev), new List<ModelWithId>(contactListAfter));
            contactListExpected.Add(newContactData);

            app.ContactHelper.CormpareTwoContactLists(
                    app.HelperBase.Sort(contactListAfter),
                    app.HelperBase.Sort(contactListExpected))
                .CheckTestResult();
        }
        
        
        public static IEnumerable<Tuple<ContactData,string>> ContactDataProvider()
        {
            var retval = new List<Tuple<ContactData,string>>();
            
            retval.Add(new Tuple<ContactData, string>(ContactFactory.GetSampleContactData(),
                "Default random contact data"));
            
            return retval;
        }

        
    }
}