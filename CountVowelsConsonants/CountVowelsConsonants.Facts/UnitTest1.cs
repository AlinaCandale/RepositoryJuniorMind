using System;
using Xunit;

namespace CountVowelsConsonants.Facts
{
    public class UnitTest1
    {
        [Fact]
        public void CheckVowelsAndConsonates()
        {
            string text = "The quick brown fox jumps over the lazy dog.";
            CountLetters sentance = new CountLetters(text);

            int vowelsNr, consonantNr;
            (vowelsNr, consonantNr) = sentance.GetNrOfVowelsAndConsonant();
            
            Assert.Equal(11, vowelsNr);
            Assert.Equal(24, consonantNr);
        }

        [Fact]
        public void CheckIfVowelsIsZero()
        {
            string text = "Th qck brwng.";
            CountLetters sentance = new CountLetters(text);

            int vowelsNr, consonantNr;
            (vowelsNr, consonantNr) = sentance.GetNrOfVowelsAndConsonant();

            Assert.Equal(0, vowelsNr);
            Assert.Equal(10, consonantNr);
        }

        [Fact]
        public void CheckIfConsonatesIsZero()
        {
            string text = "    aaaa !";
            CountLetters sentance = new CountLetters(text);

            int vowelsNr, consonantNr;
            (vowelsNr, consonantNr) = sentance.GetNrOfVowelsAndConsonant();

            Assert.Equal(4, vowelsNr);
            Assert.Equal(0, consonantNr);
        }
    }
}
