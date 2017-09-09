namespace addressbook_web_tests
{
    public class AccountData
    {
        public AccountData(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}