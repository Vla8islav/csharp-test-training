using System;

namespace addressbook_web_tests
{
    public class ContactFactory
    {
        public static ContactData GetSampleContactData()
        {
            return new ContactData
            {
                FirstName = "TestName",
                MiddleName = "TestMiddleName",
                LastName = "TestLastName",
                Address =	"",
                TelephoneHome = "",
                EMail = ""
            };
        }
        
        public static ContactData GetContactDataWithUniqueValues()
        {
            return new ContactData
            {
                FirstName = "TestName" + DateTime.Now,
                MiddleName = "TestMiddleName" + DateTime.Now,
                LastName = "TestLastName" + DateTime.Now,
                Address =	"",
                TelephoneHome = "",
                EMail = "" + DateTime.Now,
            };
        }
    }
}