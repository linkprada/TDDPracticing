using System;
using XUnitArchitecureKata.Test;
using XUnitArchitecureKata.Tests;

namespace XUnitArchitecureKata
{
    // inspired from : TDD By Exemple Kent Beck
    // https://en.wikipedia.org/wiki/XUnit
    // you can replace python "assert" with debug.assert and implement all tests
    // without using any testing framework

    class Program
    {
        static void Main(string[] args)
        {
            var testSuite = new TestSuite();
            testSuite.Add(new TestCaseTest("TestTemplateMethod"));
            testSuite.Add(new TestCaseTest("TestResult"));
            testSuite.Add(new TestCaseTest("TestFailedResult"));
            testSuite.Add(new TestCaseTest("TestFailedResultFormating"));
            testSuite.Add(new TestCaseTest("TestSetupExceptionResultFormating"));
            testSuite.Add(new TestCaseTest("TestSuiteResult"));

            var testResult = new TestResult();
            testSuite.Run(testResult);

            Console.WriteLine(testResult.Summary());
        }
    }
}
