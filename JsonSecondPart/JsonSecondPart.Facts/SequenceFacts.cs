using System;
using Xunit;

namespace JsonSecondPart.Facts
{
    public class SequenceFacts
    {
        [Fact]
        public void CheckIsStringBeginsWithRequestedCharacters()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));

            Assert.True(ab.Match("abcd").Success()); // true / "cd"
            Assert.False(ab.Match("ax").Success()); // false / "ax"
            Assert.False(ab.Match("def").Success()); // false / "def"
            Assert.False(ab.Match("").Success()); // false / ""
            Assert.False(ab.Match(null).Success()); // false / null

            var abc = new Sequence(ab, new Character('c'));

            Assert.True(abc.Match("abcd").Success()); // true / "d"
            Assert.False(abc.Match("def").Success()); // false / "def"
            Assert.False(abc.Match("abx").Success()); // false / "abx"
            Assert.Equal("abx", abc.Match("abx").RemainingText()); // false / "abx"
            Assert.False(abc.Match("").Success()); // false / ""
            Assert.False(abc.Match(null).Success()); // false / null

            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));

            var hexSeq = new Sequence(new Character('u'), new Sequence(hex, hex, hex, hex));

            Assert.True(hexSeq.Match("u1234").Success()); // true / ""
            Assert.True(hexSeq.Match("uabcdef").Success()); // true / "ef"
            Assert.True(hexSeq.Match("uB005 ab").Success()); // true / " ab"
            Assert.False(hexSeq.Match("abc").Success()); // false / "abc"
            Assert.False(hexSeq.Match(null).Success()); // false / null
        }
    }
}
