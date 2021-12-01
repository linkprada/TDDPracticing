using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XUnitArchitecureKata.Tests;

namespace XUnitArchitecureKata.Test
{
    public class TestCaseTest : TestCase
    {
        private WasRun _test;
        private TestResult _testResult;

        public TestCaseTest(string name) : base(name)
        {

        }

        public override void SetUp()
        {
            _testResult = new TestResult();
        }

        public void TestTemplateMethod()
        {
            _test = new WasRun("TestMethod");

            _test.Run(_testResult);

            var expectedLog = "SetUp TestMethod TearDown ";
            Debug.Assert(_test.log.Equals(expectedLog), $"{expectedLog.Replace(_test.log, string.Empty)} operation(s) missing");
        }

        public void TestResult()
        {
            _test = new WasRun("TestMethod");

            _test.Run(_testResult);

            var expectedResult = "1 Run, 0 Failed";
            Debug.Assert(_testResult.Summary().Equals(expectedResult));
        }

        public void TestFailedResult()
        {
            _test = new WasRun("TestBrokenMethod");

            _test.Run(_testResult);

            var expectedResult = "1 Run, 1 Failed";
            Debug.Assert(_testResult.Summary().Equals(expectedResult), _testResult.Summary());
        }

        public void TestFailedResultFormating()
        {
            _testResult.TestStarted();
            _testResult.TestFailed();

            var expectedResult = "1 Run, 1 Failed";
            Debug.Assert(_testResult.Summary().Equals(expectedResult));
        }

        public void TestSetupExceptionResultFormating()
        {
            var testMock = new WasRunMock("TestMethod");

            testMock.Run(_testResult);

            var expectedResult = "1 Run, 1 Failed";
            Debug.Assert(_testResult.Summary().Equals(expectedResult));
        }

        public void TestSuiteResult()
        {
            var suite = new TestSuite();

            suite.Add(new WasRun("TestMethod"));
            suite.Add(new WasRun("TestBrokenMethod"));

            suite.Run(_testResult);

            var expectedResult = "2 Run, 1 Failed";
            Debug.Assert(_testResult.Summary().Equals(expectedResult));
        }
    }
}
