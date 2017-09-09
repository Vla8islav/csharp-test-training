using NUnit.Framework;

namespace addressbook_web_tests
{
    public class TestBase
    {
        protected ApplicationManager ApplicationManager;

        [SetUp]
        public void SetupTest()
        {
            ApplicationManager = new ApplicationManager();
        }


        [TearDown]
        public void TeardownTest()
        {
            ApplicationManager.Stop();
        }
    }
}