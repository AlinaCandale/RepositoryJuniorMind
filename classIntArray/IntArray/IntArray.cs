using System;

namespace IntArray
{
    public class IntArray
    {
        protected int[] intArray;

        public IntArray()
        {
            intArray = new int[4];
        }

        public int Count { get; private set; } = 0;

        public virtual int this[int index] //Element() + SetElement()
        {
            get => Count > 0 && index < Count ? intArray[index] : -1;
            set => intArray[index] = value;
        }

        public virtual void Add(int element)
        {
            ResizeArray();
            intArray[Count] = element;
            Count++;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public int IndexOf(int element)
        {
            return Array.IndexOf(intArray, element, 0, Count);
        }

        public virtual void Insert(int index, int element)
        {
            ResizeArray();
            MoveElementsToRight(index, element);
            intArray[index] = element;
            Count++;
        }

        private void ResizeArray()
        {
            if (Count >= intArray.Length)
            {
                Array.Resize(ref intArray, intArray.Length * 2);
            }
        }

        private void MoveElementsToRight(int index, int element)
        {
            for (int i = Count; i >= index; i--)
            {
                intArray[i] = intArray[i - 1];
            }
        }

        public void Clear()
        {
            intArray = new int[4];
            Count = 0;
        }

        public void Remove(int element)
        {
            int index = IndexOf(element);
            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                intArray[i] = intArray[i + 1];
            }
            Count--;
        }
    }
}
