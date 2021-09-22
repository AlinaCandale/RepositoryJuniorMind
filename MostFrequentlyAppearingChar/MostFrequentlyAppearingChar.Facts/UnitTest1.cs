using System;
using Xunit;

namespace MostFrequentlyAppearingChar.Facts
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string text = "123111";
            CharWIthMaxAppearances sentance = new CharWIthMaxAppearances(text);
            char result = '1';

            int expected = sentance.FindCharWIthMaxAppearances();
            Assert.Equal(result, expected);
        }

        [Fact]
        public void Test2()
        {
            string text = "111111111";
            CharWIthMaxAppearances sentance = new CharWIthMaxAppearances(text);
            char result = '1';

            int expected = sentance.FindCharWIthMaxAppearances();
            Assert.Equal(result, expected);
        }

        [Fact]
        public void Test3()
        {
            string text = "123111aaaaaabbbbbbbbbbbbbbbb";
            CharWIthMaxAppearances sentance = new CharWIthMaxAppearances(text);
            char result = 'b';

            int expected = sentance.FindCharWIthMaxAppearances();
            Assert.Equal(result, expected);
        }

        [Fact]
        public void Test4()
        {
            string text = "123111aaaa";
            CharWIthMaxAppearances sentance = new CharWIthMaxAppearances(text);
            char result = '1';

            int expected = sentance.FindCharWIthMaxAppearances();
            Assert.Equal(result, expected);
        }
    }
}
