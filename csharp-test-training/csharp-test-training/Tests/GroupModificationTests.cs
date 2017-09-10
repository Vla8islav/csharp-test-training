using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData data = new GroupData("Some new goup" + " modified")
            {
                GroupHeader = "Some group header" + " modified",
                GroupFooter = "Некоторый русский текст для разнообразия." + " modified"
            };

            app.GroupHelper.ModifyGroupNumber(5, data);
        }

    }
}