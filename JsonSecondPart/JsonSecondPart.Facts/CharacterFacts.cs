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

            Assert.True(letter.Match(textToTest1));
            Assert.False(letter.Match(textToTest2));
        }
    }
}
