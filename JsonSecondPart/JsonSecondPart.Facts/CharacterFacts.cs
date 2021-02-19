using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class CharacterFacts
    {
        [Fact]
        public void CHeckIfFirstLetterIsCorrectChar()
        {
            Character letter = new Character('a');
            string textToTest1 = "abc";
            string textToTest2 = "";

            Assert.Equal("bc",letter.Match(textToTest1).RemainingText());
            Assert.Equal("", letter.Match(textToTest2).RemainingText());
        }
    }
}
