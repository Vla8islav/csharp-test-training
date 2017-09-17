using System;

namespace addressbook_web_tests
{
    public class AccountFactory
    {
        public AccountFactory() { }

        public static AccountData GetAdminAccountData()
        {
                return new AccountData("admin", "e3Zr14G14MoXkQ0TS8t8");
        }
        
        public static AccountData GetInvalidAccountData()
        {
                return new AccountData("admin" + DateTime.Now, "e3Zr14G14MoXkQ0TS8t8" + DateTime.Now);
        }
    }
}