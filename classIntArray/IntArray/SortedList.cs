using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IntArray
{
    class SortedList<T> where T : IComparable<T>
    {
        protected List<T> myLS;

        public SortedList(List<T> list)
        {
            this.myLS = list;
        }

        void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < myLS.Count - 1; i++)
                {
                    if (myLS[i].CompareTo(myLS[i + 1]) > 0)
                    {
                        Swap(i);
                        flag = true;
                    }
                }
            }
        }

        void Swap(int index)
        {
            T temp = myLS[index];
            myLS[index] = myLS[index + 1];
            myLS[index + 1] = temp;
        }
    }
}
