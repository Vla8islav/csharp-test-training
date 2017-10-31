using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactCheckDataTests : TestBaseWithLogin
    {
        const int CONTACT_INDEX = 1;
        
        [Test]
        public void ContactCheckEditViewConformToListTest()
        {
            CheckResultSet checkResultSet = new CheckResultSet();
            app.ContactHelper.PrepareContactWithIndex(CONTACT_INDEX);
            
            ContactData contactInfoFromList = app.ContactHelper.GetContactInfoFromList(CONTACT_INDEX);
            ContactData contactInfoFromEditForm = app.ContactHelper.GetContactInfoFromEditForm(CONTACT_INDEX);
            
            checkResultSet.Add(contactInfoFromList.Compare(contactInfoFromEditForm));
            
            checkResultSet.CheckTestResult();
        }
        
        [Test]
        public void ContactCheckViewFormConformsToEditTest()
        {
            CheckResultSet checkResultSet = new CheckResultSet();
            app.ContactHelper.PrepareContactWithIndex(CONTACT_INDEX);
            ContactData contactInfoFromEditForm = app.ContactHelper.GetContactInfoFromEditForm(CONTACT_INDEX);
            
            string contactInfoFromViewString = PrettyPrint.CleanSpecialCharacters(app.ContactHelper.GetContactInfoFromViewForm(CONTACT_INDEX));
            string contactInfoFromEditFormString = PrettyPrint.CleanSpecialCharacters(contactInfoFromEditForm.ViewFormString);
            
            checkResultSet.Add(new CheckResult(contactInfoFromViewString == contactInfoFromEditFormString,
                $"Expected: \n${contactInfoFromEditFormString} Got: \n${contactInfoFromViewString}\n${app.Driver.Url}\n"));
            checkResultSet.CheckTestResult();
        }

    }
}