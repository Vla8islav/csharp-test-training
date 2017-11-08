using LinqToDB;

namespace addressbook_web_tests
{
    public class AddressBookDb : LinqToDB.Data.DataConnection
    {
        public AddressBookDb() : base("AddressBook"){}

        public ITable<GroupData> Groups {get { return GetTable<GroupData>(); }}
        public ITable<ContactData> Contacts {get { return GetTable<ContactData>(); }}
    }
}