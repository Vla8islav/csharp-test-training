using System;

namespace addressbook_web_tests
{
    public class ContactFactory
    {
        public static ContactData GetSampleContactData()
        {
            return new ContactData
            {
                FirstName = $"TestName{StringGenerator.RandomString()}",
                MiddleName = $"TestMiddleName{StringGenerator.RandomString()}",
                LastName = $"TestLastName{StringGenerator.RandomString()}",
                Address =	$"{StringGenerator.RandomString()}",
                TelephoneHome = $"{StringGenerator.RandomString()}",
                EMail = $"{StringGenerator.RandomString()}"
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