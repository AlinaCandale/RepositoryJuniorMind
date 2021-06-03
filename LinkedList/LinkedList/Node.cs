using System;
using System.Collections.Generic;

namespace LinkedList
{
    public class Node<T>
    {
        public T Value { get; internal set; }

        public Node<T> Next { get; internal set; }

        public Node<T> Previous { get; internal set; }

        public Node(T item)
        {
            this.Value = item;
        }
        public Node()
        {
        }
    }
}
