using System;
using Xunit;

namespace Stock.Facts
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddition()
        {
            Stock store = new Stock();
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
            bool isLessThenTen = false;
            Product received = null;
            int finalQuantity = 0;
            void CheckIfQuantityIsLessThanTen(Product rec, int final)
            {
                isLessThenTen = true;
                received = rec;
                finalQuantity = final;
            }

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
            bool isLessThenTen = false;
            Product received = null;
            int finalQuantity = 0;
            void CheckIfQuantityIsLessThanTen(Product rec, int final)
            {
                isLessThenTen = true;
                received = rec;
                finalQuantity = final;
            }
 
            Stock store = new Stock();
            store.callBack = CheckIfQuantityIsLessThanTen;

            Product apple = new Product("apple", 9);
            store.Add(apple);
            Assert.False(isLessThenTen);

            Product apple1 = new Product("apple", 9);
            store.Add(apple1);
            Assert.False(isLessThenTen);

            Product apple2 = new Product("apple", 9);
            store.Subtract(apple2);
            Assert.True(isLessThenTen);
            isLessThenTen = false;
            
            Product apple3 = new Product("apple", 1);
            store.Subtract(apple3);
            Assert.False(isLessThenTen);

            Product apple4 = new Product("apple", 1);
            store.Subtract(apple4);
            Assert.False(isLessThenTen);

            Product apple5 = new Product("apple", 3);
            store.Subtract(apple5);
            Assert.True(isLessThenTen);
            isLessThenTen = false;

            Product apple6 = new Product("apple", 3);
            store.Subtract(apple6);
            Assert.True(isLessThenTen);
            isLessThenTen = false;

            Product apple7 = new Product("apple", 3);
            store.Add(apple7);

            Product apple8 = new Product("apple", 2);
            store.Subtract(apple8);
            Assert.False(isLessThenTen);

            Product apple9 = new Product("apple", 2);
            store.Subtract(apple9);
            Assert.True(isLessThenTen);
            isLessThenTen = false;
        }
    }
}
