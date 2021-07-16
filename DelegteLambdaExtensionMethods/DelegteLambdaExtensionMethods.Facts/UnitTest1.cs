using System;
using System.Collections.Generic;
using Xunit;

namespace DelegteLambdaExtensionMethods.Facts
{
    public class UnitTest1
    {
        [Fact]
        public void CheckAllisFalse()
        {
            IEnumerable<string> strings = new List<string> { "one", "three", "five" };
            bool result = strings.All(str => str.Contains("z"));

            Assert.False(result);
        }

        [Fact]
        public void CheckAllisTrue()
        {
            IEnumerable<string> strings = new List<string> { "one", "three", "five" };
            bool result = strings.All(str => str.Contains("e"));

            Assert.True(result);
        }

        [Fact]
        public void CheckAnyIsTrue()
        {
            IEnumerable<string> strings = new List<string> { "one", "three", "five" };
            bool result = strings.Any(str => str.Contains("e"));
            bool result2 = strings.Any(str => str.Contains("o"));

            Assert.True(result);
            Assert.True(result2);
        }

        [Fact]
        public void CheckAnyIsFalse()
        {
            IEnumerable<string> strings = new List<string> { "one", "three", "five" };
            bool result = strings.Any(str => str.Contains("z"));
            
            Assert.False(result);
        }

        [Fact]
        public void CheckFirstIsTrue()
        {
            IEnumerable<int> ints = new List<int> { 7, 9, 3, 4, 5, 6, 7 };
            int result = ints.First(str => str < 5);

            Assert.Equal(3, result);
        }

        [Fact]
        public void CheckFirstIsFalse()
        {
            IEnumerable<string> strings = new List<string> { "one", "three", "five" };

            Assert.Throws<InvalidOperationException>(() => strings.First(str => str.Contains("z")));
        }

        [Fact]
        public void CheckWhere()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = source.Where(x => x < 4);
            int[] expectedResult = { 1, 3, 2, 1 };

            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void NullSourceThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(x => x < 4));
        }

        [Fact]
        public void NullPredicateThrowsNullArgumentException()
        {
            int[] source = { 1, 3, 7, 9, 10 };
            Func<int, bool> predicate = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
        }

        [Fact]
        public void CheckSelect()
        {
            int[] source = { 1, 5, 2 };
            var result = source.Select(x => x.ToString());
            string[] expectedResult = { "1", "5", "2" };

            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void CheckSelectMany()
        {
            int[] numbers = { 3, 5, 20 };
            var result = numbers.SelectMany(x => (x * x).ToString());
            char[] expectedResult = { '9', '2', '5', '4', '0', '0' };

            Assert.Equal(result, expectedResult);
        }


    }
}
