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
            bool isLessThenFive = false;
            bool isLessThenTwo = false;
            bool isZero = false;

            Product received = null;
            void CheckIfQuantityIsLessThanTen(Product rec)
            {
                isLessThenTen = true;
                received = rec;
            }
            void CheckIfQuantityIsLessThanFive(Product rec)
            {
                isLessThenFive = true;
                received = rec;
            }
            void CheckIfQuantityIsLessThanTwo(Product rec)
            {
                isLessThenTwo = true;
                received = rec;
            }
            void CheckIfQuantityIsZero(Product rec)
            {
                isZero = true;
                received = rec;
            }

            Stock store = new Stock();
            store.callBackLessTen = CheckIfQuantityIsLessThanTen;
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
            bool isLessThenFive = false;
            bool isLessThenTwo = false;
            bool isZero = false;

            Product received = null;
            void CheckIfQuantityIsLessThanTen(Product rec)
            {
                isLessThenTen = true;
                received = rec;
            }
            void CheckIfQuantityIsLessThanFive(Product rec)
            {
                isLessThenFive = true;
                received = rec;
            }
            void CheckIfQuantityIsLessThanTwo(Product rec)
            {
                isLessThenTwo = true;
                received = rec;
            }
            void CheckIfQuantityIsZero(Product rec)
            {
                isZero = true;
                received = rec;
            }

            Stock store = new Stock();
            store.callBackLessTen = CheckIfQuantityIsLessThanTen;
            store.callBackLessFive = CheckIfQuantityIsLessThanFive;
            store.callBackLessTwo = CheckIfQuantityIsLessThanTwo;
            store.callBackIsZero = CheckIfQuantityIsZero;

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
            Assert.False(isZero);
            
            Product apple3 = new Product("apple", 1);
            store.Subtract(apple3);
            Assert.False(isLessThenTen);
            Assert.False(isLessThenTwo);

            Product apple4 = new Product("apple", 1);
            store.Subtract(apple4);
            Assert.False(isLessThenTen);

            Product apple5 = new Product("apple", 3);
            store.Subtract(apple5);
            Assert.True(isLessThenFive);
            isLessThenFive = false;

            Product apple6 = new Product("apple", 3);
            store.Subtract(apple6);
            Assert.False(isLessThenTen);
            Assert.False(isLessThenFive);
            Assert.True(isLessThenTwo);
            isLessThenTwo = false;

            Product apple7 = new Product("apple", 3);
            store.Add(apple7);

            Product apple8 = new Product("apple", 2);
            store.Subtract(apple8);
            Assert.False(isLessThenTen);
            Assert.False(isLessThenTwo);

            Product apple9 = new Product("apple", 2);
            store.Subtract(apple9);
            Assert.True(isZero);
        }
    }
}
