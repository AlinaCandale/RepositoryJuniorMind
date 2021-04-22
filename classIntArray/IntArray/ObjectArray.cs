using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IntArray
{
    public class ObjectArray : IEnumerable
    {
        protected object[] objArray;

        public ObjectArray()
        {
            objArray = new object[4];
        }

        public int Count { get; private set; } = 0;

        public object this[int index] //Element() + SetElement()
        {
            get => Count > 0 && index < Count ? objArray[index] : -1;
            set => objArray[index] = value;
        }

        public void Add(object element)
        {
            ResizeArray();
            objArray[Count] = element;
            Count++;
        }

        public bool Contains(object element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(object element)
        {
            return Array.IndexOf(objArray, element, 0, Count);
        }

        public void Insert(int index, object element)
        {
            ResizeArray();
            MoveElementsToRight(index, element);
            objArray[index] = element;
            Count++;
        }

        private void ResizeArray()
        {
            if (Count >= objArray.Length)
            {
                Array.Resize(ref objArray, objArray.Length * 2);
            }
        }

        private void MoveElementsToRight(int index, object element)
        {
            for (int i = Count; i >= index; i--)
            {
                objArray[i] = objArray[i - 1];
            }
        }

        public void Clear()
        {
            objArray = new object[4];
            Count = 0;
        }

        public void Remove(object element)
        {
            int index = IndexOf(element);
            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                objArray[i] = objArray[i + 1];
            }
            Count--;
        }

        public IEnumerator GetEnumerator()
        {
            int nrOfPositions = 0;
            foreach (object o in objArray)
            {
                nrOfPositions++;
                if (nrOfPositions >= Count)
                {
                    break;
                }
                yield return o;
            }
        }
    }
}
