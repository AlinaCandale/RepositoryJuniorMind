using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class AnyFacts
    {
        [Fact]
        public void CheckLetters()
        {
            var e = new Any("eE");

            Assert.True(e.Match("ea").Success()); // true / "a"
            Assert.True(e.Match("Ea").Success()); // true / "a"
            Assert.False(e.Match("a").Success()); // false / "a"
            Assert.False(e.Match("").Success()); // false / ""
            Assert.False(e.Match(null).Success()); // false / null
        }

        [Fact]
        public void CheckSign()
        {
            var sign = new Any("-+");

            Assert.True(sign.Match("+3").Success()); // true / "3"
            Assert.True(sign.Match("-2").Success()); // true  / "2"
            Assert.False(sign.Match("2").Success()); // false / "2"
            Assert.False(sign.Match("").Success()); // false / ""
            Assert.False(sign.Match(null).Success()); // false / null
        }
    }
}
