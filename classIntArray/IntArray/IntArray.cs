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
            if (counter < arrayName.Length)
            {
                arrayName[counter] = element;
            }
            else
            {
                Array.Resize(ref arrayName, arrayName.Length * 2);
                arrayName[counter] = element;
            }
            counter++;
        }

        public int Count()
        {
            return arrayName.Length;
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
            return Array.Exists(arrayName, elementToFind => elementToFind == element);
        }

        public int IndexOf(int element)
        {
            return Array.IndexOf(arrayName, element);
        }

        public void Insert(int index, int element)
        {
            if (counter < arrayName.Length)
            {
                MoveElementsToRight(index, element);
            }
            else
            {
                Array.Resize(ref arrayName, arrayName.Length * 2);
                MoveElementsToRight(index, element);
            }
            counter++;
        }

        public void MoveElementsToRight(int index, int element)
        {
            for (int i = arrayName.Length - 1; i >= index; i--)
            {
                arrayName[i] = arrayName[i - 1];
            }
            arrayName[index - 1] = element;
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
