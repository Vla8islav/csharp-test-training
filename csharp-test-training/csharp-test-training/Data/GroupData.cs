namespace addressbook_web_tests
{
    public class GroupData
    {
        public GroupData(string groupName)
        {
            GroupName = groupName;
        }

        public string GroupName { get; set; }

        public string GroupHeader { get; set; } = "";

        public string GroupFooter { get; set; } = "";
    }
}