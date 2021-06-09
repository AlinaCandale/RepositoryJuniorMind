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

        public void AddAfter(Node<T> existingNode, Node<T> nodeToAdd)
        {
            ThrowArgumentNullException(existingNode, nodeToAdd);
            ThrowInvalidOperationException(existingNode, nodeToAdd);

            nodeToAdd.Next = existingNode.Next;
            nodeToAdd.Previous = existingNode;
            existingNode.Next.Previous = nodeToAdd;
            existingNode.Next = nodeToAdd;

            Count++;
        }

        public void AddFirst(T valueForNodeToAdd)
        {
            AddAfter(head, new Node<T>(valueForNodeToAdd));
        }

        public void AddFirst(Node<T> nodeToAdd)
        {
            AddAfter(head, nodeToAdd);
        }

        public void AddLast(Node<T> nodeToAdd)
        {
            AddAfter(head.Previous, nodeToAdd);
        }

        public void Add(T valueForNodeToAdd)
        {
            AddAfter(head.Previous, valueForNodeToAdd);    
        }
        
        public void AddAfter(Node<T> existingNode, T valueForNodeToAdd)
        {
            AddAfter(existingNode, new Node<T>(valueForNodeToAdd));
        }
        
        public void AddBefore(Node<T> existingNode, Node<T> nodeToAdd)
        {
            AddAfter(existingNode.Previous, nodeToAdd);
        }

        public void AddBefore(Node<T> existingNode, T valueForNodeToAdd)
        {
            AddAfter(existingNode.Previous, new Node<T>(valueForNodeToAdd));
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

        public Node<T> FindLast(T item)
        {
            Node<T> node = FindNode(head, item);
            return node;
        }

        Node<T> FindLastNode(Node<T> node, T valueToCompare)
        {
            for (node = head.Previous; node != head; node = node.Previous)
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
            Node<T> node = nodeToRemove.Previous;
            node.Next = nodeToRemove.Next;
            nodeToRemove.Next.Previous = nodeToRemove.Previous;

            Count--;
            return true;
        }

        public void RemoveFirst()
        {
            ThrowInvalidOperationException();
            RemoveNode(head.Next);
        }

        public void RemoveLast()
        {
            ThrowInvalidOperationException();
            RemoveNode(head.Previous);
        }

        void ThrowInvalidOperationException()
        {
            if (head.Next == head)
            {
                throw new InvalidOperationException("The linked list is empty.");
            }
        }

        void ThrowArgumentNullException(Node<T> existingNode, Node<T> nodeToAdd)
        {
            if (existingNode == null || nodeToAdd == null)
            {
                throw new ArgumentNullException();
            }
        }

        void ThrowInvalidOperationException(Node<T> existingNode, Node<T> nodeToAdd)
        {
            Node<T> node = FindNode(head, existingNode.Value);
            if (node != existingNode)
            {
                throw new InvalidOperationException("Node doesn't belongs to this list");
            }
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
