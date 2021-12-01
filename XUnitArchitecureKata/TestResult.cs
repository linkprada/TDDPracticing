using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitArchitecureKata
{
    public class TestResult
    {
        private int _runCount;
        private int _errorCount;

        public TestResult()
        {
            _runCount = 0;
            _errorCount = 0;
        }

        public string Summary()
        {
            return $"{_runCount} Run, {_errorCount} Failed";
        }

        public void TestStarted()
        {
            _runCount++;
        }

        public void TestFailed()
        {
            _errorCount++;
        }
    }
}
