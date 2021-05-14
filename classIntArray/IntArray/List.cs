using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IntArray
{
    public class List<T> : IList<T>
    {
        protected T[] myArray;

        public List()
        {
            myArray = new T[4];
        }

        public int Count { get; private set; } = 0;
        public bool IsReadOnly
        {
            get { return false; }
        }

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

        public bool Remove(T element)
        {
            int index = IndexOf(element);
            if (index == -1)
            {
                throw new ArgumentOutOfRangeException("The element is not in the array.");
            }
            
            RemoveAt(index);
            return IndexOf(element) >= 0;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                myArray[i] = myArray[i + 1];
            }
            Count--;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("The destination array has fewer elements than the collection.");

            for (int i = 0; i < Count; i++)
            {
                array[i + arrayIndex] = myArray[i];
            }
        }
            
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return myArray[i];
            }
        }
    }
}
