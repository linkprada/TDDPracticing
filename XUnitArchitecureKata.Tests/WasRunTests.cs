using System;
using Xunit;

namespace XUnitArchitecureKata.Tests
{
    // inspired from : TDD By Exemple Kent Beck
    // https://en.wikipedia.org/wiki/XUnit
    // you can replace python "assert" with debug.assert and implement all tests
    // without using any testing framework

    public class WasRunTests
    {
        [Fact]
        public void BootStrapTest()
        {
            var test = new WasRun("TestMethod");
            Assert.False(test.wasRun);
            test.Run();
            Assert.True(test.wasRun);
        }
    }
}
