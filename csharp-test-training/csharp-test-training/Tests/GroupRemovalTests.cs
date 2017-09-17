using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBaseWithLogin
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.GroupHelper.RemoveFromTheListItemNumber(5);
        }
    }
}