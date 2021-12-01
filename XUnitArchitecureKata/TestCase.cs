using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XUnitArchitecureKata
{
    public class TestCase
    {
        private readonly string _name;

        public TestCase(string name)
        {
            _name = name;
        }

        public virtual void SetUp() { }

        public void Run(TestResult testResult)
        {
            testResult.TestStarted();

            try
            {
                SetUp();
                Type thisType = GetType();
                MethodInfo theMethod = thisType.GetMethod(_name);
                theMethod.Invoke(this, null);
            }
            catch (Exception)
            {
                testResult.TestFailed();
            }

            TearDown();
        }

        public virtual void TearDown() { }
    }
}
