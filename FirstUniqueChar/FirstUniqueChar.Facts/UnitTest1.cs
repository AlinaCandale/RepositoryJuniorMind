using System;
using Xunit;

namespace FirstUniqueChar.Facts
{
    public class UnitTest1
    {
        [Fact]
        public void CHeckUniqueCHar()
        {
            string text = "avdfttah";
            FindFirstUniqueChar sentance = new FindFirstUniqueChar(text);

            string x = sentance.SearhForFirstUniqueChar();
            Assert.Equal("v", x);
        }

        [Fact]
        public void CHeckUniqueCHar2()
        {
            string text = "avdfttah vf;slfjeorjgnvcofhw ";
            FindFirstUniqueChar sentance = new FindFirstUniqueChar(text);

            string x = sentance.SearhForFirstUniqueChar();
            Assert.Equal("d", x);
        }

        [Fact]
        public void CHeckIf()
        {
            string text = "aAaaa";
            FindFirstUniqueChar sentance = new FindFirstUniqueChar(text);

            Assert.Throws<InvalidOperationException>(() => sentance.SearhForFirstUniqueChar());
        }

        [Fact]
        public void CheckIfThereAreNotUniqueCHar()
        {
            string text = "aaaa";
            FindFirstUniqueChar sentance = new FindFirstUniqueChar(text);

            Assert.Throws<InvalidOperationException>(() => sentance.SearhForFirstUniqueChar());
        }

        [Fact]
        public void NullString()
        {
            string text = "";
            FindFirstUniqueChar sentance = new FindFirstUniqueChar(text);

            Assert.Throws<InvalidOperationException>(() => sentance.SearhForFirstUniqueChar());
        }
    }
}
