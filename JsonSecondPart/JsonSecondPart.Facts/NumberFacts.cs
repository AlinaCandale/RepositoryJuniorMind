using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class NumberFacts
    {
        [Theory]
        [InlineData("abc", "abc")]
        [InlineData("0", "")]
        [InlineData("1", "")]
        [InlineData("0.7", "")]
        [InlineData("07", "7")]
        [InlineData("12.", ".")]
        [InlineData("12e3", "")]
        [InlineData("12E2", "")]
        [InlineData("1e+2", "")]
        [InlineData("2+", "+")]
        [InlineData("3e-", "e-")]
        [InlineData("123.e", ".e")]
        [InlineData("123.1e", "e")]
        [InlineData("12e3.1e", ".1e")]
        [InlineData("123.1eE", "eE")]

        public void NumberConsumesTheMatchingText(string input, string expectedRemainingText)
        {
            var a = new Number();
            var result = a.Match(input);
            Assert.Equal(expectedRemainingText, result.RemainingText());
        }

        [Fact]
        public void JsonNumberCanBe()
        {
            var a = new Number();

            Assert.False(a.Match("abc").Success()); // false
            Assert.True(a.Match("0").Success()); // true 
            Assert.True(a.Match("1").Success()); // true 
            Assert.True(a.Match("0.7").Success()); // true 
            Assert.Equal("7", a.Match("07").RemainingText());
            Assert.Equal(".", a.Match("12.").RemainingText());
            Assert.True(a.Match("12e3").Success()); // true 
            Assert.True(a.Match("12E3").Success()); // true 
            Assert.True(a.Match("12e+3").Success()); // true 
            Assert.True(a.Match("12E-3").Success()); // true
            Assert.Equal("e+", a.Match("12e+").RemainingText());
            Assert.Equal("E", a.Match("12E").RemainingText()); 
            Assert.True(a.Match("12.2E3").Success()); // true
            Assert.True(a.Match("12e3.2").Success()); // true
            Assert.Equal("E", a.Match("12e12E").RemainingText());
        }
    }
}    
