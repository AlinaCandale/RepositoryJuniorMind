using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IntArray
{
    public class List<T> : IEnumerable
    {
        protected List<int> myList;

        public List(int Capacity)
        {
            myList = new List<int>(Capacity);
        }

        public int Count { get; private set; } = 0;
        public int Capacity { get; private set; } = 4;

        public object this[int index] //Element() + SetElement()
        {
            get => Count > 0 && index < Count ? myList[index] : -1;
            set => myList[index] = value;
        }

        public void Add(object element)
        {
            ResizeArray();
            myList[Count] = element;
            Count++;
        }

        public bool Contains(object element)
        {
            return IndexOf(element, 0, Count) != -1;
        }

        public int IndexOf(object element, int start, int end)
        {
            return myList.IndexOf(element, 0, Count);
        }

        public void Insert(int index, object element)
        {
            ResizeArray();
            MoveElementsToRight(index, element);
            myList[index] = element;
            Count++;
        }

        private void ResizeArray()
        {
            if (Count >= myList.Capacity)
            {
                Capacity *= 2;
            }
        }

        private void MoveElementsToRight(int index, object element)
        {
            for (int i = Count; i >= index; i--)
            {
                myList[i] = myList[i - 1];
            }
        }

        public void Clear()
        {
            myList = new List<int>(4);
            Count = 0;
            Capacity = 4;
        }

        public void Remove(object element)
        {
            int index = IndexOf(element, 0 , Count);
            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                myList[i] = myList[i + 1];
            }
            Count--;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return myList[i];
            }
        }
    }
}
