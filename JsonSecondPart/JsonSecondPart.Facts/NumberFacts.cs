using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class NumberFacts
    {
        [Fact]
        public void JsonNumberCanBe()
        {
            var a = new Number();

            Assert.False(a.Match("abc").Success()); // false
            Assert.True(a.Match("0").Success()); // true 
            Assert.True(a.Match("1").Success()); // true 
            Assert.True(a.Match("0.7").Success()); // true 
            //Assert.False(a.Match("07").Success()); // false 
            Assert.Equal("7", a.Match("07").RemainingText());
            //Assert.False(a.Match("12.").Success()); // false 
            Assert.Equal(".", a.Match("12.").RemainingText());
            Assert.True(a.Match("12e3").Success()); // true 
            Assert.True(a.Match("12E3").Success()); // true 
            Assert.True(a.Match("12e+3").Success()); // true 
            Assert.True(a.Match("12E-3").Success()); // true
            //Assert.False(a.Match("12e+").Success()); // false
            Assert.Equal("e+", a.Match("12e+").RemainingText());
            //Assert.False(a.Match("12E").Success()); // false
            Assert.Equal("E", a.Match("12E").RemainingText()); 
            Assert.True(a.Match("12.2E3").Success()); // true
            Assert.True(a.Match("12e3.2").Success()); // true
            //Assert.False(a.Match("12e12E").Success()); // false 
            Assert.Equal("E", a.Match("12e12E").RemainingText());
        }


    }
}    
