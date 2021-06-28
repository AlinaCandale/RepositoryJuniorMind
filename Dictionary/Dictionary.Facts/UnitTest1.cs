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
            openWith.Remove(7);
            openWith.Remove(1);
            openWith.Add(17, "f");

            foreach (var item in openWith)
            {
                Console.WriteLine(item);
            }
        }

        [Fact]
        public void CheckIndexerGet()
        {
            MyDictionary<int, string> openWith = new MyDictionary<int, string>(5, 5);
            openWith.Add(17, "f");

            string test = openWith[17];
        }

        [Fact]
        public void CheckIndexerSet()
        {
            MyDictionary<int, string> openWith = new MyDictionary<int, string>(5, 5);
            openWith.Add(17, "f");

            openWith[17] = "g";
            string test = openWith[17];
        }

        [Fact]
        public void CheckAddKeyValue()
        {
            MyDictionary<int, string> openWith = new MyDictionary<int, string>(5, 5);
            openWith.Add(1, "a");
            openWith.Add(2, "b");
            openWith.Add(10, "c");
            openWith.Add(7, "d");
            openWith.Add(12, "e");

            Assert.True(openWith.ContainsKey(1));
            Assert.False(openWith.ContainsKey(11));
            Assert.Throws<ArgumentException>(() => openWith.Add(1, "b"));
        }

        [Fact]
        public void CheckAddItem()
        {
            MyDictionary<int, string> openWith = new MyDictionary<int, string>(5, 5);
            KeyValuePair<int, string> a = new KeyValuePair<int, string>(1, "a");
            KeyValuePair<int, string> b = new KeyValuePair<int, string>(2, "b");
            KeyValuePair<int, string> c = new KeyValuePair<int, string>(10, "c");
            KeyValuePair<int, string> d = new KeyValuePair<int, string>(7, "d");
            KeyValuePair<int, string> e = new KeyValuePair<int, string>(12, "e");
            openWith.Add(a);
            openWith.Add(b);
            openWith.Add(c);
            openWith.Add(d);
            openWith.Add(e);
            openWith.Remove(7);
            openWith.Remove(1);
            KeyValuePair<int, string> f = new KeyValuePair<int, string>(17, "f");
            openWith.Add(f);

            Assert.True(openWith.ContainsKey(12));
            Assert.False(openWith.ContainsKey(7));
            Assert.True(openWith.Contains(b));
            Assert.False(openWith.Contains(a));
        }

        [Fact]
        public void CheckRemoveKey()
        {
            MyDictionary<int, string> openWith = new MyDictionary<int, string>(5, 5);
            openWith.Add(1, "a");
            openWith.Add(2, "b");
            openWith.Remove(1);

            Assert.False(openWith.ContainsKey(1));
            Assert.True(openWith.ContainsKey(2));
        }

        [Fact]
        public void CheckClear()
        {
            MyDictionary<int, string> openWith = new MyDictionary<int, string>(5, 5);
            openWith.Add(1, "a");
            openWith.Add(2, "b");
            openWith.Add(10, "c");
            openWith.Add(7, "d");
            openWith.Add(12, "e");

            openWith.Clear();
            Assert.False(openWith.ContainsKey(1));
            Assert.False(openWith.ContainsKey(2));
            Assert.False(openWith.ContainsKey(10));
            Assert.False(openWith.ContainsKey(7));
            Assert.False(openWith.ContainsKey(12));
        }

        [Fact]
        public void CheckRemoveItem()
        {
            MyDictionary<int, string> openWith = new MyDictionary<int, string>(5, 5);
            KeyValuePair<int, string> a = new KeyValuePair<int, string>(1, "a");
            openWith.Add(a);
            openWith.Add(2, "b");
            openWith.Add(10, "c");
            openWith.Add(7, "d");
            openWith.Add(12, "e");

            KeyValuePair<int, string> f = new KeyValuePair<int, string>(17, "f");
            KeyValuePair<int, string> g = new KeyValuePair<int, string>(1, "b");

            Assert.True(openWith.Remove(a));
            Assert.False(openWith.Remove(f));
            Assert.False(openWith.Remove(a));
            Assert.False(openWith.Remove(g));
        }

        [Fact]
        public void CheckContains()
        {
            MyDictionary<string, string> openWith = new MyDictionary<string, string>(5, 5);
            openWith.Add("a", "b");
            openWith.Add("b", "a");
            KeyValuePair<string, string> f = new KeyValuePair<string, string>("17", "f");
            openWith.Add(f);
            KeyValuePair<string, string> g = new KeyValuePair<string, string>("18", "f");

            Assert.True(openWith.ContainsKey("a"));
            Assert.True(openWith.Contains(f));
            Assert.False(openWith.Contains(g));
            Assert.DoesNotContain(g, openWith);
        }

        [Fact]
        public void CheckTryGetValue()
        {
            MyDictionary<string, string> openWith = new MyDictionary<string, string>(5, 5);
            openWith.Add("a", "b");
            openWith.Add("b", "a");
            KeyValuePair<string, string> f = new KeyValuePair<string, string>("17", "f");
            openWith.Add(f);

            Assert.True(openWith.TryGetValue("a", out _));
            Assert.False(openWith.TryGetValue("i", out _));
        }

        [Fact]
        public void CheckCopyTo()
        {
            KeyValuePair<int, string>[] array = new KeyValuePair<int, string>[10];

            MyDictionary<int, string> openWith = new MyDictionary<int, string>(5, 5);
            openWith.Add(1, "a");
            openWith.Add(2, "b");
            openWith.Add(10, "c");
            openWith.Add(7, "d");
            openWith.Add(12, "e");
            openWith.Remove(7);
            openWith.Remove(1);
            openWith.Add(17, "f");

            openWith.CopyTo(array, 1);

            Assert.Equal(17, array[1].Key);
            Assert.Null(array[0].Value);
        }
    }
}
