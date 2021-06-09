using System;
using System.Collections.Generic;

namespace LinkedList
{
    public class Node<T>
    {
        public CircularLinkedList<T> list;

        public Node()
        {
        }

        public Node(T item)
        {
            this.Value = item;
            this.Next = null;
            this.Previous = null;
            this.list = null;
        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }
    }
}
