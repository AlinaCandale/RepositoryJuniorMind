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

            Assert.True(letter.MatchChar(textToTest1));
            Assert.False(letter.MatchChar(textToTest2));
        }
    }
}
