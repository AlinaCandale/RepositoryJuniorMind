using System;
using Xunit;

namespace Stock.Facts
{
    public class UnitTest1
    {
        bool isLessThenTen = false;
        void CheckIfQuantityIsLessThanTen()
        {
            isLessThenTen = true;
        }

        [Fact]
        public void TestAddition()
        {
            Stock store = new Stock();
            store.callBack = CheckIfQuantityIsLessThanTen;
            Product apple = new Product("apple", 10);
            store.Add(apple);
            Assert.Equal("apple", store.itemsList[0].Name);

            Product apple2 = new Product("apple", 10);
            store.Add(apple2);
            Assert.Equal(20, store.itemsList[0].Quantity);

            Product cats = new Product("cats", 4);
            store.Add(cats);
            Product cats2 = new Product("cats", 4);
            store.Add(cats2);
            Product cats3 = new Product("cats", 4);
            store.Add(cats3);
            Product cats4 = new Product("cats", 4);
            store.Add(cats4);
            Assert.Equal(16, store.itemsList[1].Quantity);
        }

        [Fact]
        public void TestSubstraction()
        {
            Stock store = new Stock();
            store.callBack = CheckIfQuantityIsLessThanTen;
            Product apple = new Product("apple", 10);
            Product apple1 = new Product("apple", 1);
            store.Add(apple);
            store.Subtract(apple1);
            Assert.Equal(9, store.itemsList[0].Quantity);
        }

        [Fact]
        public void TestCallMethod()
        {
            Stock store = new Stock();
            store.callBack = CheckIfQuantityIsLessThanTen;

            Product apple = new Product("apple", 9);
            store.Add(apple);
            Assert.True(isLessThenTen);
            isLessThenTen = false;
            store.Add(apple);
            Assert.False(isLessThenTen);
        }
    }
}
