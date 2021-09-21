using System;
using Xunit;

namespace ConvertStringToInteger.Facts
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string[] text = { "123" };
            StringToInteger sentance = new StringToInteger(text);
            int[] result = { 123 };

            int[] expected = sentance.GetIntFromString();

            Assert.Equal(result, expected);
        }

        [Fact]
        public void Test2()
        {
            string[] text = { null, " ", " 1 ", " 002 ", "3.0" };
            StringToInteger sentance = new StringToInteger(text);
            int[] result = { 1, 2 };

            int[] expected = sentance.GetIntFromString();

            Assert.Equal(result, expected);
        }

        [Fact]
        public void Test3()
        {
            string[] text = { null, " ", "3.0" };
            StringToInteger sentance = new StringToInteger(text);
            int[] result = { };

            int[] expected = sentance.GetIntFromString();

            Assert.Equal(result, expected);
        }
    }
}
