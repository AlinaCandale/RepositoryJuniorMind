using System;
using System.Collections;
using System.Collections.Generic;

namespace IntArray
{
    public class ReadOnlyList<T> : IList<T>
    {
        readonly IList<T> _list = new List<T>();

        public T this[int index] { get => _list[index]; set => throw new NotSupportedException("List is read-only"); }

        public int Count => _list.Count;

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
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
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
            return ((IEnumerable)_list).GetEnumerator();
        }
    }
}
