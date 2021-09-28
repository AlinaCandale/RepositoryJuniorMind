using System;
using System.Linq;
using Xunit;

namespace SubsetsSumComparedToInteger.Facts
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //int[] set = { 1, 12, 2 };
            var data = new char[] { 'A', 'B', 'C' };
            //int sum = 13;
            //string[] result = { "1, 12, 2, 1, 2, 1, 12" };

            //var c = GetAllSubsets.GetCombinations<>(set);
            //Assert.Equal(result, array1);

            var result = GetAllSubsets.GetCombinations(data);

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"[{string.Join(", ", item)}]);
            //}
        }
    }
}
