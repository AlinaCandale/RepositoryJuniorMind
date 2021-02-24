using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class OptionalFacts
    {
    //    [Theory]
    //    [InlineData("abc", "bc", true)]
    //    [InlineData("aabc", "abc", true)]
    //    [InlineData("bc", "bc", true)]
    //    [InlineData("", "", true)]
    //    [InlineData(null, null, true)]

    //    public void test2(string value, string expected, bool expected1)
    //    {
    //        var a = new Optional(new Character('a'));

    //        IMatch result = a.Match(value);

    //        Assert.Equal(expected, expected, (System.Collections.Generic.IEqualityComparer<char>)result);
    //    }

        [Fact]
        public void test4()
        {
            var a = new Optional(new Character('a'));

            Assert.Equal("bc", a.Match("abc").RemainingText()); // true
            Assert.Equal("abc", a.Match("aabc").RemainingText()); // true 
            Assert.Equal("bc", a.Match("bc").RemainingText()); // true 
            Assert.Equal("", a.Match("").RemainingText()); // true 
            Assert.Equal(null, a.Match(null).RemainingText()); // true
        }

        [Fact]
        public void test3()
        {
            var sign = new Optional(new Character('-'));

            Assert.Equal("123", sign.Match("123").RemainingText()); // true
            Assert.Equal("123", sign.Match("-123").RemainingText()); // true 
        }
    }
}
