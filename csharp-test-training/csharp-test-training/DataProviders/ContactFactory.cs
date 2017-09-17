namespace addressbook_web_tests
{
    public class ContactFactory
    {
        public static ContactData GetSampleContactData()
        {
            return new ContactData("TestName")
            {
                MiddleName = "TestMiddleName",
                LastName = "TestLastName"
            };
        }
    }
}