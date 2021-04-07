using System;

namespace Arrays
{
	public class IntArray
    {
        int[] arrayName;

        public IntArray()
        {
            // construiește noul șir
            arrayName = new int[4] { 0, 1, 2, 3 };
        }

        public void Add(int element)
        {
            // adaugă un nou element la sfârșitul șirului 
            Array.Resize(ref arrayName, arrayName.Length + 1);
            arrayName[arrayName.Length - 1] = element;
        }

        public int Count()
        {
            // întorce numărul de elemente din șir
            return arrayName.Length;
        }

        public int Element(int index)
        {
            // întoarce elementul de la indexul dat
            return arrayName[index - 1];
        }

        public void SetElement(int index, int element)
        {
            // modifică valoarea elementului de la indexul dat
            arrayName[index - 1] = element;
        }

        public bool Contains(int element)
        {
            // întoarce true dacă elementul dat există în șir
            return Array.Exists(arrayName, elementToFind => elementToFind == element);
        }

        public int IndexOf(int element)
        {
            // întoarce indexul elementului sau -1 dacă elementul nu se regăsește în șir
            if (Contains(element))
            {
                return Array.IndexOf(arrayName, element);
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            // adaugă un nou element pe poziția dată
            arrayName[index - 1] = element;
        }

        public void Clear()
        {
            // șterge toate elementele din șir
            Array.Clear(arrayName, 0, arrayName.Length - 1);
        }

        public void Remove(int element)
        {
            // șterge prima apariție a elementului din șir	
            int index = Array.IndexOf(arrayName, element) - 1;
            for (int i = index; i < arrayName.Length - 1; i++)
            {
                arrayName[i] = arrayName[i + 1];
            }
            Array.Resize(ref arrayName, arrayName.Length - 1);
        }

        public void RemoveAt(int index)
        {
            // șterge elementul de pe poziția dată
            int[] result = new int[arrayName.Length - 1];
            int z = 0;

            for (int i = 0; i < arrayName.Length; i++)
            {
                if (i != index - 1)
                {
                    result[z] = arrayName[i];
                    z++;
                }
            }
        }

    }
}
