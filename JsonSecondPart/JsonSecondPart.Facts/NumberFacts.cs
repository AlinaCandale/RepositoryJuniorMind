using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class NumberFacts
    {
        //[Theory]
        //[InlineData("1,2,3", "")]
        //[InlineData("1,2,3,", ",")]
        //[InlineData("1a", "a")]
        //[InlineData("abc", "abc")]
        //[InlineData("", "")]
        //[InlineData(null, null)]

        //public void ListConsumesTheMatchingText(string input, string expectedRemainingText)
        //{
        //    var a = new List(new Range('0', '9'), new Character(','));
        //    var result = a.Match(input);
        //    Assert.Equal(expectedRemainingText, result.RemainingText());

        [Fact]
        public void JsonNumberCanBe()
        {
            var a = new Number();
            
            Assert.True(a.Match("0").Success()); // true 
            Assert.True(a.Match("1").Success()); // true 
            Assert.True(a.Match("0.7").Success()); // true 
            Assert.False(a.Match("07").Success()); // false 
            Assert.False(a.Match("12.").Success()); // false 
            Assert.True(a.Match("12e3").Success()); // true 
            Assert.True(a.Match("12E3").Success()); // true 
            Assert.True(a.Match("12e+3").Success()); // true 
            Assert.True(a.Match("12E-3").Success()); // true
            Assert.False(a.Match("12e+").Success()); // false 
            Assert.False(a.Match("12E").Success()); // false
            Assert.True(a.Match("12.2E3").Success()); // true
            Assert.True(a.Match("12e3.2").Success()); // true
            Assert.False(a.Match("12e12E").Success()); // false 
            Assert.True(a.Match("").Success()); // true  
        }


    }
}    
