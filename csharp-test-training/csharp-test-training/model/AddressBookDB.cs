using LinqToDB;

namespace addressbook_web_tests
{
    public class AddressBookDb : LinqToDB.Data.DataConnection
    {
        public AddressBookDb() : base("AddressBook"){}

        public ITable<GroupData> Groups => GetTable<GroupData>();
        public ITable<ContactData> Contacts => GetTable<ContactData>();
        public ITable<GroupContactRelation> Gcr => GetTable<GroupContactRelation>();
    }
}