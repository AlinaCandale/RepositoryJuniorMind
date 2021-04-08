using System;

namespace Arrays
{
	public class IntArray
    {
        int[] arrayName;

        public IntArray()
        {
            arrayName = new int[4];
        }

        public void Add(int element)
        {
            int counter = 0;
            for (int i = 0; i < arrayName.Length; i++)
            {
                if (arrayName[i] == 0)
                {
                    arrayName[i] = element;
                    break;
                }
                else
                {
                    counter++;
                }
            }
            if (counter == arrayName.Length)
            {
                Array.Resize(ref arrayName, arrayName.Length * 2);
                arrayName[counter] = element;
            }
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
            int indexOfElementZero = IndexOf(0);
            if (indexOfElementZero == -1)
            {
                Array.Resize(ref arrayName, arrayName.Length * 2);
                for (int i = arrayName.Length / 2; i >= index; i--)
                {
                    arrayName[i] = arrayName[i - 1];
                }
                arrayName[index - 1] = element;
            }
            else if (indexOfElementZero >= index)
            {
                for (int i = indexOfElementZero; i >= index; i--)
                {
                    arrayName[i] = arrayName[i - 1];
                }
                arrayName[index - 1] = element;
            }
            else if (indexOfElementZero <= index)
            {
                for (int i = indexOfElementZero; i < index - 1; i++)
                {
                    arrayName[i] = arrayName[i + 1];
                }
                arrayName[index - 1] = element;
            }
        }

        public void Clear()
        {
            arrayName = new int[4];
        }

        public void Remove(int element)
        {
            int index = Array.IndexOf(arrayName, element);
            arrayName[index] = 0;
        }

        public void RemoveAt(int index)
        {
            arrayName[index] = 0;
        }
    }
}
