namespace addressbook_web_tests
{
    public class CheckResult
    {
        public bool Result { set; get; }
        public string Message { set; get; }

        public string getResultMessage()
        {
            if (Result)
            {
                return "[PASSED] " + Message;
            }
            return "[FAILED] " + Message;
        }

        public CheckResult(bool result = true, string message = "")
        {
            Result = result;
            Message = message;
        }
    }
}