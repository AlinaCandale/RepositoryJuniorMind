using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class TextFacts
    {
        [Fact]
        public void test1()
        {
            var trrue = new Text("true");
            var faalse = new Text("false");

            Assert.True(trrue.Match("true").Success()); // true / ""
            Assert.True(trrue.Match("trueX").Success()); // true / "X"
            Assert.False(trrue.Match("false").Success()); // false / "false"
            Assert.False(trrue.Match("").Success()); // false / ""
            Assert.False(trrue.Match(null).Success()); // false / null

            Assert.True(faalse.Match("false").Success()); // true / ""
            Assert.True(faalse.Match("falseX").Success()); // true / "X"
            Assert.False(faalse.Match("true").Success()); // false / "true"
            Assert.False(faalse.Match("").Success()); // false / ""
            Assert.False(faalse.Match(null).Success()); // false / null
        }

        [Fact]
        public void CheckIfPrefixIsEmptySpace()
        {
            var empty = new Text("");

            Assert.True(empty.Match("true").Success()); // true / "true"
            Assert.False(empty.Match(null).Success()); // false / null
        }
    }
}
