using NUnit.Framework;

namespace addressbook_web_tests
{
    public class TestBaseUi : TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();
        }

        [TearDown]
        public void TeardownTest()
        {
        }
    }
}