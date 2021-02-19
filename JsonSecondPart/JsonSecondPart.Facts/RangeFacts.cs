using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class RangeFacts
    {
        [Fact]
        public void CheckIfMatchIsCorrect()
        {
            Range letter = new Range('a', 'f');
            string textToTest1 = "abc";
            string textToTest2 = "1bc";

            Assert.Equal("bc", letter.Match(textToTest1).RemainingText());
            Assert.Equal("1bc", letter.Match(textToTest2).RemainingText());
        }
    }
}
