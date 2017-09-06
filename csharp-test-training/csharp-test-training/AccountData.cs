using System.Diagnostics.Eventing.Reader;

namespace addressbook_web_tests
{
    public class AccountData
    {
        public AccountData(string login, string password)
        {
            _login = login;
            _password = password;
        }

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _login;
        private string _password;
    }
}