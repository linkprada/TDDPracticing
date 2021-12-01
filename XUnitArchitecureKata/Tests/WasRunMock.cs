using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitArchitecureKata.Tests
{
    public class WasRunMock : WasRun
    {
        public WasRunMock(string name) : base(name)
        {
        }

        public override void SetUp()
        {
            throw new Exception();
            log = "SetUp ";
        }
    }
}
