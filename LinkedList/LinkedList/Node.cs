using System;
using System.Collections.Generic;

namespace LinkedList
{
    public class Node<T>
    {
        public Node()
        {
        }

        public Node(T item)
        {
            this.Value = item;
            this.Next = null;
            this.Previous = null;
            this.List = null;
        }
        
        public CircularLinkedList<T> List { get; internal set; }

        public T Value { get; set; }

        public Node<T> Next { get; internal set; }

        public Node<T> Previous { get; internal set; }
    }
}
