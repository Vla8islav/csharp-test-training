using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBaseWithLogin
    {
        [Test]
        public void GroupCreationTest()
        {

            GroupData data = new GroupData("Some new goup")
            {
                GroupHeader = "Some group header",
                GroupFooter = "Некоторый русский текст для разнообразия."
            };
            app.GroupHelper.Create(data);
        }
        [Test]
        public void GroupCreationLeaveFooterIntactTest()
        {

            GroupData data = new GroupData("Some new goup")
            {
                GroupHeader = "Some group header",
                GroupFooter = null
            };
            
            app.GroupHelper.Create(data);
        }
        
        [Test]
        public void EmptyGroupCrationTest()
        {
            GroupData data = new GroupData("")
            {
                GroupHeader = "",
                GroupFooter = ""
            };
            app.GroupHelper.Create(data);
        }
    }
}