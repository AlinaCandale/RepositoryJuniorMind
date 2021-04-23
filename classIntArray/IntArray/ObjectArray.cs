using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IntArray
{
    public class List<T> : IEnumerable
    {
        protected T[] myArray;

        public List()
        {
            myArray = new T[4];
        }

        public int Count { get; private set; } = 0;

        public T this[int index] //Element() + SetElement()
        {
            get => Count > 0 && index < Count ? myArray[index] : throw new ArgumentOutOfRangeException();
            set => myArray[index] = (T)value;
        }

        public void Add(T element)
        {
            ResizeArray();
            myArray[Count] = element;
            Count++;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(T element)
        {
            return Array.IndexOf(myArray, element, 0, Count);
        }

        public void Insert(int index, T element)
        {
            ResizeArray();
            MoveElementsToRight(index, element);
            myArray[index] = element;
            Count++;
        }

        private void ResizeArray()
        {
            if (Count >= myArray.Length)
            {
                Array.Resize(ref myArray, myArray.Length * 2);
            }
        }

        private void MoveElementsToRight(int index, T element)
        {
            for (int i = Count; i >= index; i--)
            {
                myArray[i] = myArray[i - 1];
            }
        }

        public void Clear()
        {
            myArray = new T[4];
            Count = 0;
        }

        public void Remove(T element)
        {
            int index = IndexOf(element);
            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                myArray[i] = myArray[i + 1];
            }
            Count--;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return myArray[i];
            }
        }
    }
}
