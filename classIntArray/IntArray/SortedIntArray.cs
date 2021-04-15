using System;
using System.Collections.Generic;
using System.Text;

namespace Arrays
{
    class SortedIntArray : IntArray
    {
        public SortedIntArray(): base() { }

        public override void Add(int element) 
        {
            base.Add(element);
            Array.Sort(intArray);
        }


    }
}
