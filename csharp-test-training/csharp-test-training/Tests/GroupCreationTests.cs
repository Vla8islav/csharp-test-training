using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {

            app.GroupHelper.RemoveFromTheListItemNumber(1);
        }

    }
}