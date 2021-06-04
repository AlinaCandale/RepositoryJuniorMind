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

        void AddFirstElement(T newElement)
        {
            Node<T> newNode = new Node<T>(newElement);
            newNode.Value = newElement;

            head.Next = newNode;
            head.Previous = newNode;
            newNode.Next = head;
            newNode.Previous = head;
        }

        public void AddFirst(T newElement)
        {
            if (head.Next == null)
            {
                AddFirstElement(newElement);
            }
            else
            {
                Node<T> newNode = new Node<T>(newElement);
                newNode.Value = newElement;

                newNode.Next = head.Next;
                newNode.Previous = head;
                head.Next.Previous = newNode;
                head.Next = newNode;
            }
            Count++;
        }

        public void AddLast(T newElement)
        {
            if (head.Previous == null)
            {
                AddFirstElement(newElement);
            }
            else
            {
                Node<T> newNode = new Node<T>(newElement);
                newNode.Value = newElement;

                newNode.Next = head;
                newNode.Previous = head.Previous;
                head.Previous.Next = newNode;
                head.Previous = newNode;
            }
            Count++;
        }

        public void Add(T newElement)
        {
            AddLast(newElement);    
        }
        
        void AddAfter(Node<T> node, T newElement)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            Node<T> temp = FindNode(head, node.Value);
            if (temp != node)
            {
                throw new InvalidOperationException("Node is not in the current list");
            }

            Node<T> newNode = new Node<T>(newElement);
            newNode.Next = node.Next;
            node.Next.Previous = newNode;
            newNode.Previous = node;
            node.Next = newNode;

            Count++;
        }

        public void AddAfter(T existingElement, T newElement)
        {
            Node<T> node = Find(existingElement);
            if (node == null)
            {
                throw new ArgumentException("existingElement is not in the current list");
            }
            AddAfter(node, newElement);
        }

        void AddBefore(Node<T> node, T newElement)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            Node<T> temp = FindNode(head, node.Value);
            if (temp != node)
            {
                throw new InvalidOperationException("Node is not in the current list");
            }

            Node<T> newNode = new Node<T>(newElement);
            node.Previous.Next = newNode;
            newNode.Previous = node.Previous;
            newNode.Next = node;
            node.Previous = newNode;

            Count++;
        }

        public void AddBefore(T existingElement, T newElement)
        {
            Node<T> node = Find(existingElement);
            if (node == null)
            {
                throw new ArgumentException("existingElement is not in the current list");
            }
            AddBefore(node, newElement);
        }

        public void Clear()
        {
            while (true && Count != 0)
            {
                Count--;
                RemoveFirst();
            }
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
            Node<T> searchNode = null;
            if (Comparer.Equals(node.Value, valueToCompare))
            {
                searchNode = node;
            }
            else if (searchNode == null && node.Next != head)
            {
                searchNode = FindNode(node.Next, valueToCompare);
            }
            
            return searchNode;
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
                head = nodeToRemove.Next;
            }
            else if (head.Previous == nodeToRemove)
            {
                head.Previous = head.Previous.Previous;
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
            //if ()
            //{
            //    throw new ArgumentException();
            //}

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
            if (current != null)
            {
                do
                {
                    yield return current.Value;
                    current = current.Next;
                }
                while (current != head);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
