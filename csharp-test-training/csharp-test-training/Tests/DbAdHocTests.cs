using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class DbAdHocTests : TestBase
    {
        [Test]
        public void TestDbConnectivity()
        {
            List<ContactData> fromDb = ContactData.GetAllActiveContacts();
            
            foreach (GroupData g in fromDb[0].GetGroups())
            {
                System.Console.Out.WriteLine($"{g.Footer} {g.Header}");
            }
            /*
            List<GroupData> fromWeb = app.GroupHelper.GetGroupList();
            

            app.GroupHelper.CormpareGroupListsNames(
                    app.GroupHelper.Sort(fromWeb), 
                    app.GroupHelper.Sort(fromDb))
                .CheckTestResult();*/
        }
    }
}