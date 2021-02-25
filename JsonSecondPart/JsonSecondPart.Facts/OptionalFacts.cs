using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class OptionalFacts
    {
        [Theory]
        [InlineData("abc", "bc")]
        [InlineData("aabc", "abc")]
        [InlineData("bc", "bc")]
        [InlineData("", "")]
        [InlineData(null, null)]

        public void OptionalConsumesTheMatchingText(string input, string expectedRemainingText)
        {
            var subject = new Optional(new Character('a'));
            var result = subject.Match(input);
            Assert.Equal(expectedRemainingText, result.RemainingText());
        }

        [Theory]
        [InlineData("abc", true)]
        [InlineData("aabc", true)]
        [InlineData("bc", true)]
        [InlineData("", true)]
        [InlineData(null, true)]
        public void OptionalConsumesTheMatchingTextWithBoolResult(string input, bool expectedRemainingText)
        {
            var subject = new Optional(new Character('a'));
            var result = subject.Match(input);
            Assert.Equal(expectedRemainingText, result.Success());
        }

        //{
        //    var a = new Optional(new Character('a'));

        //    Assert.Equal("bc", a.Match("abc").RemainingText()); // true
        //    Assert.Equal("abc", a.Match("aabc").RemainingText()); // true 
        //    Assert.Equal("bc", a.Match("bc").RemainingText()); // true 
        //    Assert.Equal("", a.Match("").RemainingText()); // true 
        //    Assert.Equal(null, a.Match(null).RemainingText()); // true
        //}

        [Fact]
        public void test3()
        {
            var sign = new Optional(new Character('-'));

            Assert.Equal("123", sign.Match("123").RemainingText()); // true
            Assert.Equal("123", sign.Match("-123").RemainingText()); // true 
        }
    }
}
