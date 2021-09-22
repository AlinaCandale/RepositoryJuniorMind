using System;
using Xunit;

namespace ConvertStringToInteger.Facts
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string text =  "123" ;
            StringToInteger sentance = new StringToInteger(text);
            int result = 123 ;

            int expected = sentance.GetIntFromString();
            Assert.Equal(result, expected);
        }

        [Fact]
        public void Test2()
        {
            string text = "002";
            StringToInteger sentance = new StringToInteger(text);
            int result = 2;

            int expected = sentance.GetIntFromString();
            Assert.Equal(result, expected);
        }

        [Fact]
        public void Test3()
        {
            string text = "10null";
            StringToInteger sentance = new StringToInteger(text);

            Assert.Throws<Exception>(() => sentance.GetIntFromString());
        }
    }
}
