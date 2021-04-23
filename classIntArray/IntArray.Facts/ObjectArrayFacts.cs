using IntArray;
using System;
using Xunit;
using System.Collections.Generic;

namespace Arrays.Facts
{
    public class ObjectArrayFacts
    {
        [Fact]
        public void CheckCount()
        {
            var a = new System.Collections.Generic.List<int>();
            a.Add(0);
            a.Add(8);
            a.Add(2);
            a.Add(3);
            int result = a.Count;
            Assert.Equal(4, result);
        }

        [Fact]
        public void CheckElement()
        {
            var a = new System.Collections.Generic.List<int>();
            a.Add(0);
            a.Add(1);
            a.Add(10);
            a.Add(3);
            object result = a[2];
            Assert.Equal(10, result);
        }

        [Fact]
        public void CheckSetElement()
        {
            var a = new System.Collections.Generic.List<int>();
            a.Add(0);
            a.Add(1);
            a.Add(6);
            a.Add(3);
            a[1] = 5;
            Assert.Equal(5, a[1]);
            Assert.Equal(6, a[2]);
        }

        [Fact]
        public void CheckContains()
        {
            var a = new System.Collections.Generic.List<int>();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            bool result = a.Contains(0);
            Assert.True(result);
        }

        [Fact]
        public void CheckContains2()
        {
            var a = new System.Collections.Generic.List<int>();
            bool result = a.Contains(0);
            Assert.False(result);
        }

        [Fact]
        public void CheckIndexOf()
        {
            var a = new System.Collections.Generic.List<int>();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            int result = a.IndexOf(1);
            Assert.Equal(1, result);
        }

        [Fact]
        public void CheckIndexOf2()
        {
            var a = new System.Collections.Generic.List<int>();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            int result = a.IndexOf(101);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void CheckIndexOf3()
        {
            var a = new System.Collections.Generic.List<int>();
            int result = a.IndexOf(0);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void CheckInsert()
        {
            var a = new System.Collections.Generic.List<int>();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(1001);
            a.Insert(1, 8);
            int result = a.IndexOf(8);
            int result1 = a.IndexOf(1001);
            Assert.Equal(1, result);
            Assert.Equal(4, result1);
        }

        [Fact]
        public void CheckClear()
        {
            var a = new System.Collections.Generic.List<int>();
            a.Add(0);
            a.Add(1235);
            a.Add(2);
            a.Add(314);
            Assert.Equal(4, a.Count);
            a.Clear();
            Assert.Equal(0, a.Count);
        }

        [Fact]
        public void CheckRemove()
        {
            var a = new System.Collections.Generic.List<int>();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Remove(1);
            object result = a[2];
            Assert.Equal(3, result);
        }

        [Fact]
        public void CheckRemove2()
        {
            var a = new System.Collections.Generic.List<int>();
            a.Add(1);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Remove(1);
            object result = a[1];
            Assert.Equal(2, result);
        }

        [Fact]
        public void CheckRemoveAt()
        {
            var a = new System.Collections.Generic.List<int>();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.RemoveAt(1);
            object result = a[2];
            Assert.Equal(3, result);
        }

        [Fact]
        public void CheckAdd()
        {
            var a = new System.Collections.Generic.List<int>();
            a.Add(0);
            a.Add(10);
            a.Add(201);
            a.Add(3);
            a.Add(112);
            a.Add(5);
            object result = a[4];
            Assert.Equal(112, result);
        }

        [Fact]
        public void TestForeach()
        {
            var a = new System.Collections.Generic.List<int>();
            a.Add(0);
            a.Add(10052);
            a.Add(201);
            a.Add(3);
            a.Add(112);
            a.GetEnumerator();
        }
    }
}
