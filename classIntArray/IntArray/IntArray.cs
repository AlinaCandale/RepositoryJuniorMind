using System;

namespace Arrays
{
	public class IntArray
    {
        int[] arrayName;

        public IntArray()
        {
            arrayName = new int[0];
        }

        public void Add(int element)
        {
            Array.Resize(ref arrayName, arrayName.Length + 1);
            arrayName[arrayName.Length - 1] = element;
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
            Array.Resize(ref arrayName, arrayName.Length + 1);
            for (int i = index; i < arrayName.Length; i++)
            {
                arrayName[i] = arrayName[i - 1];
            }
            arrayName[index - 1] = element;
        }

        public void Clear()
        {
            arrayName = new int[0];
        }

        public void Remove(int element)
        {
            int index = Array.IndexOf(arrayName, element);
            RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            for (int i = index - 1; i < arrayName.Length - 1; i++)
            {
                arrayName[i] = arrayName[i + 1];
            }
            Array.Resize(ref arrayName, arrayName.Length - 1);
        }
    }
}
