namespace addressbook_web_tests
{
    public class GroupFactory
    {
        public static GroupData GetSampleGroupData()
        {
            return new GroupData("Some new goup")
            {
                GroupHeader = "Some group header",
                GroupFooter = "Некоторый русский текст для разнообразия."
            };
        }

    }
}