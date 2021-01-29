using Xunit;
using static Json.JsonString;

namespace Json.Facts
{
    public class JsonStringFacts
    {
        [Fact]
        public void IsWrappedInDoubleQuotes()
        {
            Assert.True(IsJsonString(Quoted("abc")));
        }

        [Fact]
        public void AlwaysStartsWithQuotes()
        {
            Assert.False(IsJsonString("abc\""));
        }

        [Fact]
        public void AlwaysEndsWithQuotes()
        {
            Assert.False(IsJsonString("\"abc"));
        }

        [Fact]
        public void IsNotNull()
        {
            Assert.False(IsJsonString(null));
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            Assert.False(IsJsonString(string.Empty));
        }

        [Fact]
        public void IsAnEmptyDoubleQuotedString()
        {
            Assert.True(IsJsonString(Quoted(string.Empty)));
        }

        [Fact]
        public void HasStartAndEndQuotes()
        {
            Assert.False(IsJsonString("\""));
        }


        [Fact]
        public void DoesNotContainControlCharacters()
        {
            Assert.False(IsJsonString(Quoted("a\nb\rc")));
        }

        [Fact]
        public void CanContainLargeUnicodeCharacters()
        {
            Assert.True(IsJsonString(Quoted("⛅⚾")));
        }

        [Fact]
        public void CanContainEscapedQuotationMark()
        {
            Assert.True(IsJsonString(Quoted(@"\""a\"" b")));
        }

        [Fact]
        public void CanContainEscapedReverseSolidus()
        {
            Assert.True(IsJsonString(Quoted(@"a \\ b")));
        }

        [Fact]
        public void CanContainEscapedSolidus()
        {
            Assert.True(IsJsonString(Quoted(@"a \/ b")));
        }

        [Fact(Skip = "Remove this Skip as you implement")]
        public void CanContainEscapedBackspace()
        {
            Assert.True(IsJsonString(Quoted(@"a \b b")));
        }

        [Fact(Skip = "Remove this Skip as you implement")]
        public void CanContainEscapedFormFeed()
        {
            Assert.True(IsJsonString(Quoted(@"a \f b")));
        }

        [Fact(Skip = "Remove this Skip as you implement")]
        public void CanContainEscapedLineFeed()
        {
            Assert.True(IsJsonString(Quoted(@"a \n b")));
        }

        [Fact(Skip = "Remove this Skip as you implement")]
        public void CanContainEscapedCarrigeReturn()
        {
            Assert.True(IsJsonString(Quoted(@"a \r b")));
        }

        [Fact(Skip = "Remove this Skip as you implement")]
        public void CanContainEscapedHorizontalTab()
        {
            Assert.True(IsJsonString(Quoted(@"a \t b")));
        }

        [Fact(Skip = "Remove this Skip as you implement")]
        public void CanContainEscapedUnicodeCharacters()
        {
            Assert.True(IsJsonString(Quoted(@"a \u26Be b")));
        }

        [Fact(Skip = "Remove this Skip as you implement")]
        public void DoesNotContainUnrecognizedExcapceCharacters()
        {
            Assert.False(IsJsonString(Quoted(@"a\x")));
        }

        [Fact(Skip = "Remove this Skip as you implement")]
        public void DoesNotEndWithReverseSolidus()
        {
            Assert.False(IsJsonString(Quoted(@"a\")));
        }

        [Fact(Skip = "Remove this Skip as you implement")]
        public void DoesNotEndWithAnUnfinishedHexNumber()
        {
            Assert.False(IsJsonString(Quoted(@"a\u")));
            Assert.False(IsJsonString(Quoted(@"a\u123")));
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
