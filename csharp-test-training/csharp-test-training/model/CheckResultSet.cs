using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class CheckResultSet
    {
        private readonly List<CheckResult> _resultSetList;

        public CheckResultSet()
        {
            _resultSetList = new List<CheckResult>();
        }

        public CheckResultSet Add(CheckResult result)
        {
            _resultSetList.Add(result);
            return this;
        }

        public List<CheckResult> GetCheckResults()
        {
            return new List<CheckResult>(_resultSetList);
        }


        public CheckResultSet Concatenate(CheckResultSet checkResultSet)
        {
            foreach (var checkResult in checkResultSet.GetCheckResults())
            {
                _resultSetList.Add(checkResult);
            }
            return this;
        }

        public void CheckTestResult()
        {
            bool testResult = true;
            string testMessage = "";

            foreach (CheckResult r in _resultSetList)
            {
                testMessage += r.getResultMessage() + "\n";
                testResult &= r.Result;
            }
            Assert.IsTrue(testResult, testMessage);
        }
    }
}