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

            Assert.True(letter.Match(textToTest1).Success());
            Assert.False(letter.Match(textToTest2).Success());
        }
    }
}
