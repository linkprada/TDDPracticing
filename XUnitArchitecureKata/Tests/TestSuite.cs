using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitArchitecureKata.Tests
{
    public class TestSuite
    {
        private readonly List<TestCase> _tests;
        public TestSuite()
        {
            _tests = new List<TestCase>();
        }
        public void Add(TestCase testCase)
        {
            _tests.Add(testCase);
        }

        public void Run(TestResult testResult)
        {
            foreach (var test in _tests)
            {
                test.Run(testResult);
            };
        }
    }
}
