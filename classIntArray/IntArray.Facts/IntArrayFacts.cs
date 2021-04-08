using System;
using Xunit;

namespace Arrays.Facts
{
    public class IntArrayFacts
    {
        [Fact]
        public void CheckCount()
        {
            var a = new IntArray();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            int result = a.Count();
            Assert.Equal(4, result);
        }

        [Fact]
        public void CheckElement()
        {
            var a = new IntArray();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            int result = a.Element(2);
            Assert.Equal(1, result);
        }

        [Fact]
        public void CheckSetElement()
        {
            var a = new IntArray();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.SetElement(1, 5);
            Assert.Equal(5, a.Element(1));
        }

        [Fact]
        public void CheckContains()
        {
            var a = new IntArray();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            bool result = a.Contains(0);
            Assert.True(result);
        }

        [Fact]
        public void CheckIndexOf()
        {
            var a = new IntArray();
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
            var a = new IntArray();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            int result = a.IndexOf(11);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void CheckInsert()
        {
            var a = new IntArray();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Insert(1, 8);
            int result = a.IndexOf(8);
            Assert.Equal(0, result);
        }

        [Fact]
        public void CheckClear()
        {
            var a = new IntArray();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Clear();
            Assert.Equal(0, a.Count());
        }

        [Fact]
        public void CheckRemove()
        {
            var a = new IntArray();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Remove(1);
            int result = a.Element(2);
            Assert.Equal(2, result);
        }

        [Fact]
        public void CheckRemoveAt()
        {
            var a = new IntArray();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.RemoveAt(1);
            int result = a.Element(2);
            Assert.Equal(2, result);
        }

        [Fact]
        public void CheckAdd()
        {
            var a = new IntArray();
            a.Add(0);
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Add(112);
            int result = a.Element(5);
            Assert.Equal(112, result);
        }
    }
}
