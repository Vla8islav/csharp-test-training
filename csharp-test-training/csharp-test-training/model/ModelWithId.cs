using LinqToDB.Mapping;

namespace addressbook_web_tests
{
    public abstract class ModelWithId : ModelBase
    {
        public abstract int? Id { get; set; }

    }
}