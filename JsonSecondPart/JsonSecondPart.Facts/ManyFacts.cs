using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class ManyFacts
    {
        [Fact]
        public void CheckIfRemainingTextIsCorrectIfManyConteinsCharacter()
        {
            var a = new Many(new Character('a'));

            Assert.Equal("bc", a.Match("abc").RemainingText()); // true  
            Assert.Equal("bc", a.Match("aaaabc").RemainingText()); // true 
            Assert.Equal("bc", a.Match("bc").RemainingText()); // true 
            Assert.Equal("", a.Match("").RemainingText()); // true 
            Assert.Equal(null, a.Match(null).RemainingText()); // true 
        }

        [Fact]
        public void CheckIfRemainingTextIsCorrectIfManyConteinsRange()
        {
            var digits = new Many(new Range('0', '9'));

            Assert.Equal("ab123", digits.Match("12345ab123").RemainingText()); // true 
            Assert.Equal("ab", digits.Match("ab").RemainingText()); // true  
        }

        [Fact]
        public void CheckIfRemainingTextIsCorrectIfManyConteinsText()
        {
            var text = new Many(new Text("re"));

            Assert.Equal("abc", text.Match("reabc").RemainingText()); // true  
            Assert.Equal("rbc", text.Match("rererbc").RemainingText()); // true 
            Assert.Equal("bc", text.Match("bc").RemainingText()); // true 

        }
    }
}
