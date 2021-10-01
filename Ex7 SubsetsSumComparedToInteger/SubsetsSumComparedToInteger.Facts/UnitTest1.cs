using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SubsetsSumComparedToInteger.Facts
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int[] set = { 1, 2, 3 };
            int sum = 5;
            GetAllSubsets x = new GetAllSubsets(set, sum);
            int[] x1 = new int[] { 1 };
            int[] x2 = new int[] { 2 };
            int[] x3 = new int[] { 3 };
            int[] x4 = new int[] { 1, 2 };
            int[] x5 = new int[] { 2, 3 };
            int[] x6 = new int[] { 1, 2, 3 };
            List<int[]> result = new List<int[]>() { x1, x4, x2, x5, x3 };

            var expected = x.GetRequiredSumSubArray(set, sum);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void Test2()
        {
            int[] set = { 1, 2, 3, 4, 5 };
            int sum = 5;
            GetAllSubsets x = new GetAllSubsets(set, sum);
            int[] x1 = new int[] { 1 };
            int[] x2 = new int[] { 2 };
            int[] x3 = new int[] { 3 };
            int[] x4 = new int[] { 1, 2 };
            int[] x5 = new int[] { 2, 3 };
            int[] x6 = new int[] { 4 };
            int[] x7 = new int[] { 5 };
            List<int[]> result = new List<int[]>() { x1, x4, x2, x5, x3, x6, x7 };

            var expected = x.GetRequiredSumSubArray(set, sum);
            Assert.Equal(result, expected);
        }
    }
}
