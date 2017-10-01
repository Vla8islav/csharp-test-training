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
                Telephone = "",
                EMail = ""
            };
        }
    }
}