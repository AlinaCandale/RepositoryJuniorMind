using System;
using System.Collections.Generic;
using Xunit;

namespace AddOrSubstractFirstXNr.Facts
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string[] x1 = new string[] { "---++", "-+++-", "+-+-+" };
            Assert.Equal(x1, GetResultK.AllSignsCombinations(5, 3));
        }
    }
}
