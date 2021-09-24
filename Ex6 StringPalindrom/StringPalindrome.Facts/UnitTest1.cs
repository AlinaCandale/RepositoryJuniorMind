using System;
using Xunit;

namespace StringPalindrome.Facts
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string text = "xxyxxz";
            AllPalindromPartitionInString sentance = new AllPalindromPartitionInString(text);
            string result = "x x y x x z xx xx xyx xxyxx";

            string[] expected = sentance.GenerateAllPalindromPartitionInString();
            string final = string.Join(" ", expected);
            Assert.Equal(result, final);
        }
    

        [Fact]
        public void Test2()
        {
            string text = "abc";
            AllPalindromPartitionInString sentance = new AllPalindromPartitionInString(text);
            string result = "a b c";

            string[] expected = sentance.GenerateAllPalindromPartitionInString();
            string final = string.Join(" ", expected);
            Assert.Equal(result, final);
        }

        [Fact]
        public void Test3()
        {
            string text = "aa";
            AllPalindromPartitionInString sentance = new AllPalindromPartitionInString(text);
            string result = "a a aa";

            string[] expected = sentance.GenerateAllPalindromPartitionInString();
            string final = string.Join(" ", expected);
            Assert.Equal(result, final);
        }
    }
}
