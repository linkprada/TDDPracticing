
using System;

namespace XUnitArchitecureKata
{
    public class WasRun : TestCase
    {
        public string log;

        public WasRun(string name) : base(name)
        {
        }

        public override void SetUp()
        {
            log = "SetUp ";
        }

        public void TestMethod()
        {
            log += "TestMethod ";
        }

        public override void TearDown()
        {
            log += "TearDown ";
        }

        public void TestBrokenMethod()
        {
            throw new Exception();
        }

        public void TestBrokenSetUp()
        {
            throw new Exception();
        }
    }
}
