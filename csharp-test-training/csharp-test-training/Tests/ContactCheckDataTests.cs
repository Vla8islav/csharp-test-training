using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactCheckDataTests : TestBaseWithLogin
    {
        const int ContactIndex = 1;
        
        [Test]
        public void ContactCheckEditViewConformToListTest()
        {
            CheckResultSet checkResultSet = new CheckResultSet();
            app.ContactHelper.PrepareContactWithIndex(ContactIndex);
            
            ContactData contactInfoFromList = app.ContactHelper.GetContactInfoFromList(ContactIndex);
            ContactData contactInfoFromEditForm = app.ContactHelper.GetContactInfoFromEditForm(ContactIndex);
            
            checkResultSet.Add(contactInfoFromList.Compare(contactInfoFromEditForm));
            
            checkResultSet.CheckTestResult();
        }
        
        [Test]
        public void ContactCheckViewFormConformsToEditTest()
        {
            CheckResultSet checkResultSet = new CheckResultSet();
            app.ContactHelper.PrepareContactWithIndex(ContactIndex);
            ContactData contactInfoFromEditForm = app.ContactHelper.GetContactInfoFromEditForm(ContactIndex);
            
            string contactInfoFromViewString = PrettyPrint.CleanSpecialCharacters(app.ContactHelper.GetContactInfoFromViewForm(ContactIndex));
            string contactInfoFromEditFormString = PrettyPrint.CleanSpecialCharacters(contactInfoFromEditForm.ViewFormString);
            
            checkResultSet.Add(new CheckResult(contactInfoFromViewString == contactInfoFromEditFormString,
                $"Expected: \n${contactInfoFromEditFormString} Got: \n${contactInfoFromViewString}\n${app.Driver.Url}\n"));
            checkResultSet.CheckTestResult();
        }

    }
}