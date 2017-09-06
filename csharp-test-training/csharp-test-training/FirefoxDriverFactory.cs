using OpenQA.Selenium.Firefox;

namespace addressbook_web_tests
{
    public class FirefoxDriverFactory
    {
        public FirefoxDriverFactory() { }

        public FirefoxDriver GetFirefoxDriver()
        {
                FirefoxBinary firefox = new FirefoxBinary(PathToFirefox);
                return new FirefoxDriver(firefox,
                    new FirefoxProfile());
        }

        private const string PathToFirefox = @"C:\Program Files (x86)\Mozilla Firefox_45_9_0_esr\firefox.exe";        

    }
}