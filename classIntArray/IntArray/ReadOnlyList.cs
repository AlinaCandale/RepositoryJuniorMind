using System;
using System.Collections;
using System.Collections.Generic;

namespace IntArray
{
    public class ReadOnlyList<T> : IList<T>
    {
        readonly IList<T> readOnlyList = new List<T>();

        public T this[int index] { get => readOnlyList[index]; set => throw new NotSupportedException("List is read-only"); }

        public int Count => readOnlyList.Count;

        public bool IsReadOnly
        {
            get { return true; }
        }

        public void Add(T item)
        {
            throw new NotSupportedException("List is read-only");
        }

        public void Clear()
        {
            throw new NotSupportedException("List is read-only");
        }

        public bool Contains(T item)
        {
            return readOnlyList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            readOnlyList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return readOnlyList.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return readOnlyList.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            throw new NotSupportedException("List is read-only");
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException("List is read-only");
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException("List is read-only");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)readOnlyList).GetEnumerator();
        }
    }
}
