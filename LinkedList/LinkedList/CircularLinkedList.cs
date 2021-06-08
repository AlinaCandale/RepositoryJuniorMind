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

        void AddNode(Node<T> temp, Node<T> next, T valueForNodeToAdd)
        {
            Node<T> newNode = new Node<T>(valueForNodeToAdd);
            newNode.Value = valueForNodeToAdd;

            temp.Next = newNode;
            newNode.Previous = temp;
            newNode.Next = next;
            next.Previous = newNode;

            Count++;
        }

        public void AddFirst(T nodeToAdd)
        {
            if (head.Next == head)
            {
                AddNode(head, head, nodeToAdd);
            }
            else
            {
                AddNode(head, head.Next, nodeToAdd);
            }
        }

        public void AddLast(T nodeToAdd)
        {
            if (head.Previous == head)
            {
                AddNode(head, head, nodeToAdd); 
            }
            else
            {
                AddNode(head.Previous, head, nodeToAdd);
            }
        }

        public void Add(T nodeToAdd)
        {
            AddLast(nodeToAdd);    
        }
        
        public void AddAfter(Node<T> existingNode, T valueForNodeToAdd)
        {
            AddNode(existingNode, existingNode.Next, valueForNodeToAdd);
        }

        public void AddAfter(Node<T> existingNode, Node<T> nodeToAdd)
        {
            AddNode(existingNode, existingNode.Next, nodeToAdd.Value);
        }

        public void AddBefore(Node<T> existingNode, Node<T> nodeToAdd)
        {
            AddNode(existingNode.Previous, existingNode, nodeToAdd.Value);
        }

        public void AddBefore(Node<T> existingNode, T valueForNodeToAdd)
        {
            AddNode(existingNode.Previous, existingNode, valueForNodeToAdd);
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
            Node<T> searchNode = head;
            for (int i = 0; i <= Count; i++)
            {
                if (Comparer.Equals(node.Value, valueToCompare))
                {
                    searchNode = node;
                }
                else 
                {
                    node = node.Next;
                }
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
