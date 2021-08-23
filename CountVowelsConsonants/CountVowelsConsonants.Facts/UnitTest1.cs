using System;
using Xunit;

namespace CountVowelsConsonants.Facts
{
    public class UnitTest1
    {
        [Fact]
        public void CheckVowels()
        {
            string text = "The quick brown fox jumps over the lazy dog.";
            CountLetters sentance = new CountLetters(text);

            int vowelsNr = sentance.GetNrOfVowels();
            int consonantNr = sentance.GetNrOfConsonant();

            Assert.Equal(11, vowelsNr);
            Assert.Equal(24, consonantNr);

        }
    }
}
