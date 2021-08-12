using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace DelegteLambdaExtensionMethods.Facts
{
    class Student
    {
        public string Teacher { get; set; }
        public double Id { get; set; }
    }

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
            IList<int> outer = new List<int>() { 5, 3, 7 };
            IList<string> inner = new List<string>() { "bee", "giraffe", "tiger", "badger", "ox", "cat", "dog" };
            var result = outer.Join(inner,
                                   outerElement => outerElement,
                                   innerElement => innerElement.Length,
                                   (outerElement, innerElement) => outerElement + ":" + innerElement);
            string[] expectedResult = { "5:tiger", "3:bee", "3:cat", "3:dog", "7:giraffe" };
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void CheckJoin2()
        {
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four"};
            IList<string> strList2 = new List<string>() { "One", "Two", "Five", "Six"};
            var result = strList1.Join(strList2,
                                  str1 => str1,
                                  str2 => str2,
                                  (str1, str2) => str1);
            string[] expectedResult = { "One", "Two" };
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
        public void CheckUnion2()
        {
            IList<int> numbers2 = new List<int>() { 1, 1, 1, 3, 4, 4 };
            IList<int> numbers1 = new List<int>() { 1, 1, 1, 2, 2, 2, 3, 3, 3 };

            var result = numbers2.Union(numbers1, EqualityComparer<int>.Default);
            int[] expectedResult = { 1, 3, 4, 2 };
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

        [Fact]
        public void CheckGroupBy()
        {
            List<Student> stuentsList = new List<Student>{
                       new Student { Teacher="Barley", Id=8 },
                       new Student { Teacher="Boots", Id=4 },
                       new Student { Teacher="Barley", Id=1 },
                       new Student { Teacher="Barley", Id=3 } };

            var results = stuentsList.GroupBy(
                                    s => s.Teacher,
                                    s => s.Id,
                                    (teacher, ids) => new { t = teacher, id = ids },
                                    EqualityComparer<string>.Default);

            List<List<double>> res = new List<List<double>>();
            foreach (var result in results)
            {
                List<double> tmp = new List<double>();
                foreach (var i in result.id)
                {
                    tmp.Add(i);
                }
                res.Add(tmp);
            }

            List<double> exp1 = new List<double>();
            exp1.Add(8);
            exp1.Add(1);
            exp1.Add(3);
            List<double> exp2 = new List<double>();
            exp2.Add(4);
            List<List<double>> exp = new List<List<double>>();
            exp.Add(exp1);
            exp.Add(exp2);

            Assert.Equal(res, exp);
        }

        [Fact]
        public void CheckOrderBy()
        {
            List<string> fruits = new List<string> { "apricot", "orange", "banana", "mango", "apple", "grape", "strawberry" };
            IEnumerable<string> result = fruits.OrderBy(fruit => fruit.Length, Comparer<int>.Default).ThenBy(fruit => fruit, Comparer<string>.Default);
            IEnumerable<string> expectedResult = new List<string> { "apple", "grape", "mango", "banana", "orange", "apricot", "strawberry" };

            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void CheckOrderBy2()
        {
            List<string> strings = new List<string> { "first", "then", "and then", "finally" };
            IEnumerable<string> result = strings.OrderBy(str => str, Comparer<string>.Default);
            IEnumerable<string> expectedResult = new List<string> { "and then", "finally", "first", "then" };

            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void CheckOrderBy3()
        {
            List<string> strings = new List<string> { "final", "then", "and then", "finally" };
            IEnumerable<string> result = strings.OrderBy(str => str, Comparer<string>.Default).ThenBy(str => str.Length, Comparer<int>.Default);
            IEnumerable<string> expectedResult = new List<string> { "and then", "final", "finally", "then" };

            Assert.Equal(result, expectedResult);
        }
    }
}

