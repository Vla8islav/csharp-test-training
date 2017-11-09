using LinqToDB.Mapping;

namespace addressbook_web_tests
{
    [Table(Name = "address_in_groups")]
    public class GroupContactRelation
    {
        [Column(Name = "id"), PrimaryKey, Identity]
        public int ContactId { get; set; }
        
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public int GroupId { get; set; }

    }
}