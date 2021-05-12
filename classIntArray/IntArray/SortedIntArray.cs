using System;
using System.Collections.Generic;
using System.Text;

namespace IntArray
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray(): base() { }

        public override void Add(int element) 
        {
            base.Add(element);
            Array.Sort(intArray, 0, Count);
        }

        public override void Insert(int index, int element)
        {
            base.Insert(index, element);
            Array.Sort(intArray, 0, Count);
        }

        public override int this[int index]
        {
            set
            {
                base[index] = value;
                Array.Sort(intArray, 0, Count);
            }
        }
    }
}
