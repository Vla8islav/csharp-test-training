namespace addressbook_web_tests
{
    public class GroupData
    {
        public GroupData(string groupName)
        {
            _group_name = groupName;
        }

        public string GroupName
        {
            get { return _group_name; }
            set { _group_name = value; }
        }

        public string GroupHeader
        {
            get { return _group_header; }
            set { _group_header = value; }
        }

        public string GroupFooter
        {
            get { return _group_footer; }
            set { _group_footer = value; }
        }

        private string _group_name;
        private string _group_header = "";
        private string _group_footer = "";

    }
}