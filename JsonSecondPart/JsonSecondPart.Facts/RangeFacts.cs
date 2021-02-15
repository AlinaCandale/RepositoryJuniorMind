using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class RangeFacts
    {
        [Fact]
        public void Test1()
        {
            Range letter = new Range('a', 'f');
            string textToTest = "abc";

            Assert.True(letter.Match(textToTest));
        }
    }
}
