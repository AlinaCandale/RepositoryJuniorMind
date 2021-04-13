using System;

namespace Arrays
{
	public class IntArray
    {
        int[] intArray;
        int counter = 0;

        public IntArray()
        {
            intArray = new int[4];
        }

        public void Add(int element)
        {
            ResizeArray();
            intArray[counter] = element;
            counter++;
        }

        public int Count()
        {
            return counter;
        }

        public int Element(int index)
        {
            return counter > 0 && index < counter ? intArray[index] : -1;
        }

        public void SetElement(int index, int element)
        {
            intArray[index] = element;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) > -1 ? true : false;
        }

        public int IndexOf(int element)
        {
            return Array.IndexOf(intArray, element, 0, counter);
        }

        public void Insert(int index, int element)
        {
            ResizeArray();
            MoveElementsToRight(index, element);
            intArray[index] = element;
            counter++;
        }

        private void ResizeArray()
        {
            if (counter >= intArray.Length)
            {
                Array.Resize(ref intArray, intArray.Length * 2);
            }
        }

        private void MoveElementsToRight(int index, int element)
        {
            for (int i = counter; i >= index; i--)
            {
                intArray[i] = intArray[i - 1];
            }
        }

        public void Clear()
        {
            intArray = new int[4];
            counter = 0;
        }

        public void Remove(int element)
        {
            int index = IndexOf(element);
            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < counter - 1; i++)
            {
                intArray[i] = intArray[i + 1];
            }
            counter--;
        }
    }
}
