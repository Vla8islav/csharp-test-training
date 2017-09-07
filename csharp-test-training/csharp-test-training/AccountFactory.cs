namespace addressbook_web_tests
{
    public class AccountFactory
    {
        public AccountFactory() { }

        public AccountData GetAdminAccountData()
        {
                return new AccountData("admin", "e3Zr14G14MoXkQ0TS8t8");
        }
    }
}