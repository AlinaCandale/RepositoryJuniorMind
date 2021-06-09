using System;
using System.Collections.Generic;

namespace LinkedList
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }

        public Node(T item)
        {
            this.Value = item;
            this.Next = null;
            this.Previous = null;
        }
        public Node()
        {
        }
    }
}
