using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SubsetsSumComparedToInteger.Facts
{
    public class UnitTest1
    {
        //[Fact]
        //public void Test1()
        //{
        //    int[] set = { 1, 2, 3 };
        //    int sum = 5;
        //    GetAllSubsets x = new GetAllSubsets(set,sum);
        //    List<int> x1 = new List<int>() { 1 };
        //    List<int> x2 = new List<int>() { 2 };
        //    List<int> x3 = new List<int>() { 3 };
        //    List<int> x4 = new List<int>() { 1, 2 };
        //    List<int> x5 = new List<int>() { 2, 3 };
        //    List<List<int>> result = new List<List<int>>() { x1, x4, x2, x5, x3 };

        //    List<List<int>> expected = x.GetRequiredSumSubArray(set, sum);
        //    Assert.Equal(result, expected);
        //}

        //[Fact]
        //public void Test2()
        //{
        //    int[] set = { 1, 2, 3, 4 };
        //    int sum = 10;
        //    GetAllSubsets x = new GetAllSubsets(set, sum);
        //    List<int> x1 = new List<int>() { 1 };
        //    List<int> x2 = new List<int>() { 2 };
        //    List<int> x3 = new List<int>() { 3 };
        //    List<int> x4 = new List<int>() { 1, 2 };
        //    List<int> x5 = new List<int>() { 2, 3 }; 
        //    List<int> x6 = new List<int>() { 4 };
        //    List<int> x7 = new List<int>() { 1, 2, 3 };
        //    List<int> x8 = new List<int>() { 1, 2, 3, 4 };
        //    List<int> x9 = new List<int>() { 2, 3, 4 };
        //    List<int> x10 = new List<int>() { 3, 4 };
        //    List<List<int>> result = new List<List<int>>() { x1, x4, x7, x8, x2, x5, x9, x3, x10, x6 };

        //    List<List<int>> expected = x.GetRequiredSumSubArray(set, sum);
        //    Assert.Equal(result, expected);
        //}

        [Fact]
        public void Test1()
        {
            int[] set = { 1, 2, 3 };
            GetAllSubsets x = new GetAllSubsets(set);
            List<int> x1 = new List<int>() { 1 };
            List<int> x2 = new List<int>() { 2 };
            List<int> x3 = new List<int>() { 3 };
            List<int> x4 = new List<int>() { 1, 2 };
            List<int> x5 = new List<int>() { 2, 3 };
            List<int> x6 = new List<int>() { 1, 2, 3 };
            List<List<int>> result = new List<List<int>>() { x1, x4, x6, x2, x5, x3 };

            List<List<int>> expected = x.GetRequiredSumSubArray(set);
            Assert.Equal(result, expected);
        }
    }
}
