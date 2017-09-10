using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData data = new ContactData("TestName" + " modified")
            {
                MiddleName = "TestMiddleName" + " modified",
                LastName = "TestLastName" + " modified"
            };
            app.ContactHelper.ModifyContactNumber(5, data);
        }
    }
}