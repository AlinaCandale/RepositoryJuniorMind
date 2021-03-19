using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class StringFacts
    {
        [Theory]
        [InlineData("abc", "")]
        [InlineData("0", "")]
        [InlineData("abc012", "")]
        [InlineData("\\", "")]
        [InlineData("\u26Be", "")]
        [InlineData("a \r b", "")]


        public void StringConsumesTheMatchingText(string input, string expectedRemainingText)
        {
            var a = new String();
            var result = a.Match(Quoted(input));
            Assert.Equal(expectedRemainingText, result.RemainingText());
        }

        public static string Quoted(string text)
            => $"\"{text}\"";

    }
}    
