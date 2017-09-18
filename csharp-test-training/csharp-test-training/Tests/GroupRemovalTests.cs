using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBaseWithLogin
    {
        [Test]
        public void GroupRemovalTest()
        {
            const int groupNumberToDelete = 5;
            app.GroupHelper.PrepareANumberOfGroups(groupNumberToDelete);
            app.NavigationHelper.OpenGroupsPage();
            app.GroupHelper.RemoveFromTheListItemNumber(groupNumberToDelete);
        }
    }
}