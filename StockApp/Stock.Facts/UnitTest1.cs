using System;
using Xunit;

namespace Stock.Facts
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Stock store = new Stock();
            Product apple = new Product("apple", 10);
            Product apple2 = new Product("apple", 10);
            Product cats = new Product("cats", 4);
            Product cats2 = new Product("cats", 4);
            Product cats3 = new Product("cats", 4);
            Product cats4 = new Product("cats", 4);
            Product cats5 = new Product("cats", 12);

            store.Add(apple);
            store.Add(apple2);
            store.Add(cats);
            store.Add(cats2);
            store.Add(cats3);
            store.Add(cats4);
            store.Subtract(cats5);
        }
    }
}
