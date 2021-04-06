using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class InternetDateTimeFormatFacts
    {
        [Theory]
        [InlineData("1985-04-12T23:20:50.52Z", "")]
        [InlineData("1996-12-19T16:39:57-08:00", "")]
        [InlineData("1990-12-31T23:59:60Z", "")]
        [InlineData("1990-12-31T15:59:60-08:00", "")]
        [InlineData("1937-01-01T12:00:27.87+00:20", "")]

        public void OptionalConsumesTheMatchingText(string input, string expectedRemainingText)
        {
            var subject = new InternetDateTimeFormat();
            var result = subject.Match(input);
            Assert.Equal(expectedRemainingText, result.RemainingText());
        }
    }
}
