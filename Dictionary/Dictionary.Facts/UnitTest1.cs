using System;
using System.Collections.Generic;
using Xunit;

namespace Dictionary.Facts
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            MyDictionary<int, string> openWith = new MyDictionary<int, string>(5, 5);
            openWith.Add(1, "a");
            openWith.Add(2, "b");
            openWith.Add(10, "c");
            openWith.Add(7, "d");
            openWith.Add(12, "e");
            openWith.Remove(12);
            //openWith.Add(2, "b");
            //openWith.Add(2, "b");
        }
    }
}
