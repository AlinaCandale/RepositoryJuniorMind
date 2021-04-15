using System;
using Xunit;

namespace Arrays.Facts

{
    public class SortedIntArrayFacts
    {
        [Fact]
        public void CheckAdd()
        {
            var a = new SortedIntArray();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Add(112);
            a.Add(0);
            int result = a[4];
            Assert.Equal(3, result);
        }

        [Fact]
        public void CheckAdd2()
        {
            var a = new SortedIntArray();
            a.Add(7);
            a.Add(1);
            a.Add(0);
            a.Add(3);
            a.Add(4);
            a.Add(112);
            int result = a[3];
            Assert.Equal(4, result);
        }


        [Fact]
        public void CheckInsert()
        {
            var a = new SortedIntArray();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Insert(1, 8);
            int result = a.IndexOf(8);
            int result1 = a.IndexOf(3);
            Assert.Equal(4, result);
            Assert.Equal(3, result1);
        }

        [Fact]
        public void CheckInsert2()
        {
            var a = new SortedIntArray();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Insert(1, 0);
            int result = a.IndexOf(0);
            Assert.Equal(0, result);
            a.Insert(1, 5);
            int result1 = a.IndexOf(5);
            Assert.Equal(5, result1);
        }

        [Fact]
        public void CheckInsert3()
        {
            var a = new SortedIntArray();
            a.Add(2);
            a.Add(1);
            a.Add(322);
            a.Add(14);
            a.Add(5);
            a.Insert(3, 0);
            a.Insert(5, 6);
            int result = a.IndexOf(6);
            Assert.Equal(4, result);
        }

        [Fact]
        public void CheckInsert4()
        {
            var a = new SortedIntArray();
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Add(4);
            a.Insert(3, 6);
            int result = a.IndexOf(4);
            Assert.Equal(3, result);
        }

        [Fact]
        public void CheckElement()
        {
            var a = new SortedIntArray();
            a.Add(1);
            a.Add(0);
            a.Add(5);
            a.Add(3);
            int result = a[2];
            Assert.Equal(3, result);
        }

        [Fact]
        public void CheckElement2()
        {
            var a = new SortedIntArray();
            int result = a[2];
            Assert.Equal(-1, result);
        }

        [Fact]
        public void CheckSetElement()
        {
            var a = new SortedIntArray();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a[1] = 5;
            Assert.Equal(2, a[1]);
            Assert.Equal(5, a[3]);
        }

        [Fact]
        public void CheckRemove()
        {
            var a = new SortedIntArray();
            a.Add(3);
            a.Add(1);
            a.Add(5);
            a.Add(2);
            a.Remove(1);
            int result = a[2];
            Assert.Equal(5, result);
        }

        [Fact]
        public void CheckRemoveAt()
        {
            var a = new SortedIntArray();
            a.Add(10);
            a.Add(1);
            a.Add(5);
            a.Add(3);
            a.RemoveAt(1);
            int result = a[2];
            Assert.Equal(10, result);
            int result1 = a[3];
            Assert.Equal(-1, result1);
        }
    }
}
