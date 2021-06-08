using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class CircularLinkedList<T> : ICollection<T>
    {
        private Node<T> head;

        public CircularLinkedList()
        {
            head = new Node<T>();
            head.Next = head;
            head.Previous = head;
        }

        public int Count { get; private set; } = 0;
        public bool IsReadOnly => false;

        void AddNode(Node<T> node, T valueForNodeToAdd)
        {
            Node<T> nodeToAdd = new Node<T>(valueForNodeToAdd);
            nodeToAdd.Value = valueForNodeToAdd;

            AddAfter(node, nodeToAdd);
        }

        public void AddFirst(T nodeToAdd)
        {
            AddNode(head, nodeToAdd);
        }

        public void AddLast(T nodeToAdd)
        {
            AddNode(head.Previous, nodeToAdd);
        }

        public void Add(T nodeToAdd)
        {
            AddLast(nodeToAdd);    
        }
        
        public void AddAfter(Node<T> existingNode, T valueForNodeToAdd)
        {
            AddNode(existingNode, valueForNodeToAdd);
        }

        public void AddAfter(Node<T> existingNode, Node<T> nodeToAdd)
        {
            nodeToAdd.Next = existingNode.Next;
            nodeToAdd.Previous = existingNode;
            existingNode.Next.Previous = nodeToAdd;
            existingNode.Next = nodeToAdd;

            Count++;
        }

        public void AddBefore(Node<T> existingNode, Node<T> nodeToAdd)
        {
            AddAfter(existingNode.Previous, nodeToAdd);
        }

        public void AddBefore(Node<T> existingNode, T valueForNodeToAdd)
        {
            AddNode(existingNode.Previous, valueForNodeToAdd);
        }

        public void Clear()
        {
            head.Next = head;
            head.Previous = head;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public Node<T> Find(T item)
        {
            Node<T> node = FindNode(head, item);
            return node;
        }

        Node<T> FindNode(Node<T> node, T valueToCompare)
        {
            for (node = head.Next; node != head; node = node.Next)
            {
                if (Comparer.Equals(node.Value, valueToCompare))
                {
                    return node;
                }
            }

            return node;
        }

        public bool Remove(T item)
        {
            Node<T> nodeToRemove = Find(item);
            if (nodeToRemove != null)
            {
                return RemoveNode(nodeToRemove);
            }
            
            return false;
        }

        bool RemoveNode(Node<T> nodeToRemove)
        {
            if (head == nodeToRemove)
            {
                nodeToRemove = head.Next;
            }
            
            Node<T> node = nodeToRemove.Previous;
            node.Next = nodeToRemove.Next;
            nodeToRemove.Next.Previous = nodeToRemove.Previous;

            Count--;
            return true;
        }

        public bool RemoveFirst()
        {
            return RemoveNode(head.Next);
        }

        public bool RemoveLast()
        {
            return RemoveNode(head.Previous);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array is null");
            }
            if (arrayIndex < 0 || arrayIndex > Count)
            {
                throw new ArgumentOutOfRangeException("arrayIndex is out of range");
            }
            if (Count > array.Length - arrayIndex + 1)
            {
                throw new ArgumentException();
            }

            Node<T> node = head.Next;
            do
            {
                array[arrayIndex++] = node.Value;
                node = node.Next;
            } 
            while (node != head);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head.Next;
            for (int i = 0; i < Count; i++)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
