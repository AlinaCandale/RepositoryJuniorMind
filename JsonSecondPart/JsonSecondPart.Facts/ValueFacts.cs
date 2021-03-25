using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class ValueFacts
    {
        [Theory]
        [InlineData(" { \"abc\" :1} ", "")]
        [InlineData(" 0 ", "")]
        [InlineData(" \"abc\" ", "")]
        [InlineData(" true ", "")]
        [InlineData(" null ", "")]
        [InlineData(" [] ", "")]
        [InlineData(" [12] ", "")]
        [InlineData(" \"\u26Be\" ", "")]
        [InlineData(" 12e3 ", "")]

        public void CHeckIfValueIsCorrect(string input, string expectedRemainingText)
        {
            var a = new Value();
            var result = a.Match(input);
            Assert.Equal(expectedRemainingText, result.RemainingText());
        }
    }
}
