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
        public void NullPredicateThrowsNullArgumentException()
        {
            IEnumerable<int> source = null;
            Func<int, bool> predicate = null;
            IEnumerable<int> result = Class1.Where<int>(source, predicate);
            
            Assert.Throws<ArgumentNullException>(() => result.GetEnumerator().MoveNext());
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

        [Fact]
        public void CheckToDictionary()
        {
            string[] str = new string[] { "Car", "Bus", "Bicycle" };
            var d = str.ToDictionary(item => item, item => true);
            foreach (var ele in d)
            {
                Console.WriteLine("{0}, {1}", ele.Key, ele.Value);
            }
            Assert.True(d.ContainsKey("Bus"));
        }

        [Fact]
        public void CheckZip()
        {
            int[] numbers = { 1, 2, 3, 4 };
            string[] words = { "one", "two", "three" };

            var result = numbers.Zip(words, (first, second) => first + second);
            string[] expectedResult = { "1one", "2two", "3three" };

            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void CheckAggregate()
        {
            int[] ints = { 4, 8, 8, 3, 9, 0, 7, 8, 2 };
            int numEven = ints.Aggregate(0, (total, next) =>
                                                next % 2 == 0 ? total + 1 : total);
            Assert.Equal(6, numEven);
        }

        [Fact]
        public void CheckJoin()
        {
            int[] outer = { 5, 3, 7 };
            string[] inner = { "bee", "giraffe", "tiger", "badger", "ox", "cat", "dog" };
            var result = outer.Join(inner,
                                   outerElement => outerElement,
                                   innerElement => innerElement.Length,
                                   (outerElement, innerElement) => outerElement + ":" + innerElement);
            string[] expectedResult = { "5:tiger", "3:bee", "3:cat", "3:dog", "7:giraffe" };
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void CheckDistinct()
        {
            IList<int> numbers = new List<int>() { 1, 1, 1, 2, 2, 2, 3, 3, 3 };

            var result = numbers.Distinct(EqualityComparer<int>.Default);
            int[] expectedResult = { 1, 2, 3 };
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void CheckUnion()
        {
            IList<int> numbers1 = new List<int>() { 1, 1, 1, 2, 2, 2, 3, 3, 3 };
            IList<int> numbers2 = new List<int>() { 1, 1, 1, 3, 4, 4 };

            var result = numbers1.Union(numbers2, EqualityComparer<int>.Default);
            int[] expectedResult = { 1, 2, 3, 4 };
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void CheckIntersect()
        {
            IList<int> listA = new List<int>() { 1, 2, 3, 4, 5 };
            IList<int> listB = new List<int>() { 4, 5 };

            var result = listA.Intersect(listB, EqualityComparer<int>.Default);
            int[] expectedResult = { 4, 5 };
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void CheckIntersect2()
        {
            IList<int> listA = new List<int>() { 1, 1, 1, 2, 2, 2, 3, 3, 3 };
            IList<int> listB = new List<int>() { 1, 1, 1, 3, 4, 4 };

            var result = listA.Intersect(listB, EqualityComparer<int>.Default);
            int[] expectedResult = { 1, 3 };
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void CheckExcept()
        {
            IList<int> listA = new List<int>() { 1, 1, 1, 2, 2, 2, 3, 3, 3 };
            IList<int> listB = new List<int>() { 1, 1, 1, 3, 4, 4 };

            var result = listA.Except(listB, EqualityComparer<int>.Default);
            int[] expectedResult = { 2 };
            Assert.Equal(result, expectedResult);
        }

        //[Fact]
        //public void CheckGroupBy()
        //{
        //    string[] source = { "abc", "hello", "def", "there", "four" };
        //    var result = source.GroupBy(x => x.Length,
        //                        x => x[0],
        //                        (key, values) => key + ":" + string.Join(";", values), 
        //                        StringComparer.CurrentCultureIgnoreCase).ToString;
        //    string[] expectedResult = { "3:a;d", "5:h;t", "4:f" };
        //    Assert.Equal(result, expectedResult);

        //}
    }
}
