using System;

namespace Arrays
{
	public class IntArray
    {
        int[] arrayName;
        int counter = 0;

        public IntArray()
        {
            arrayName = new int[4];
        }

        public void Add(int element)
        {
            ResizeArray();
            arrayName[counter] = element;
            counter++;
        }

        public int Count()
        {
            return counter;
        }

        public int Element(int index)
        {
            return arrayName[index - 1];
        }

        public void SetElement(int index, int element)
        {
            arrayName[index - 1] = element;
        }

        public bool Contains(int element)
        {
            if (counter > 0)
            {
                return Array.Exists(arrayName, elementToFind => elementToFind == element);
            }
            return false;
        }

        public int IndexOf(int element)
        {
            if (counter > 0)
            {
                return Array.IndexOf(arrayName, element);
            }
            return -1;
        }

        public void Insert(int index, int element)
        {
            ResizeArray();
            MoveElementsToRight(index, element);
            arrayName[index - 1] = element;
            counter++;
        }

        public void ResizeArray()
        {
            if (counter >= arrayName.Length)
            {
                Array.Resize(ref arrayName, arrayName.Length * 2);
            }
        }

        public void MoveElementsToRight(int index, int element)
        {
            for (int i = counter; i >= index; i--)
            {
                arrayName[i] = arrayName[i - 1];
            }
        }

        public void Clear()
        {
            arrayName = new int[4];
            counter = 0;
        }

        public void Remove(int element)
        {
            int index = Array.IndexOf(arrayName, element);
            RemoveAt(index + 1);
        }

        public void RemoveAt(int index)
        {
            for (int i = index - 1; i < arrayName.Length - 1; i++)
            {
                arrayName[i] = arrayName[i + 1];
            }
            counter--;
        }
    }
}
