using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IntArray
{
    public class List<T> : IList<T>
    {
        protected T[] myArray;
        string command;

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
            get => Count > 0 && !IndexValidation(index) ? myArray[index] : throw new ArgumentOutOfRangeException();
            //set => myArray[index] = value;
            set
            {
                if (Count < 0 || IndexValidation(index))
                    throw new ArgumentOutOfRangeException();

                myArray[index] = value;
            }
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
            if(!IndexValidation(index))
                throw new ArgumentOutOfRangeException();
            
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
            RemoveAt(index);
            return IndexOf(element) >= 0;
        }

        public void RemoveAt(int index)
        {
            if (!IndexValidation(index))
                throw new ArgumentOutOfRangeException();

            for (int i = index; i < Count - 1; i++)
            {
                myArray[i] = myArray[i + 1];
            }
            Count--;
        }

        public bool IndexValidation(int index)
        {    
            return index < Count || index < 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("IntArray.List.CopyTo: The array cannot be null.", nameof(array));
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(array), "IntArray.List.CopyTo: The starting array index cannot be negative.");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("IntArray.List.CopyTo: The destination array has fewer elements than the collection.", nameof(array));

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
