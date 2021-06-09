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
            head.list = this;
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
            this.AddAfter(head, new Node<T>(valueForNodeToAdd));
        }

        public void AddFirst(Node<T> nodeToAdd)
        {
            this.AddAfter(head, nodeToAdd);
        }

        public void AddLast(Node<T> nodeToAdd)
        {
            this.AddAfter(head.Previous, nodeToAdd);
        }

        public void Add(T valueForNodeToAdd)
        {
            AddLast(new Node<T>(valueForNodeToAdd));
        }
        
        public void AddAfter(Node<T> existingNode, T valueForNodeToAdd)
        {
            this.AddAfter(existingNode, new Node<T>(valueForNodeToAdd));
        }
        
        public void AddBefore(Node<T> existingNode, Node<T> nodeToAdd)
        {
            if (existingNode == null)
            {
                throw new ArgumentNullException();
            }
            this.AddAfter(existingNode.Previous, nodeToAdd);
        }

        public void AddBefore(Node<T> existingNode, T valueForNodeToAdd)
        {
            AddBefore(existingNode, new Node<T>(valueForNodeToAdd));
        }

        public void Clear()
        {
            head.Next = head;
            head.Previous = head;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return this.Find(item) != null;
        }

        public Node<T> Find(T valueToCompare)
        {
            Node<T> node = new Node<T>();
            for (node = head.Next; node != head; node = node.Next)
            {
                if (Comparer.Equals(node.Value, valueToCompare))
                {
                    return node;
                }
            }

            return node;
        }

        public Node<T> FindLast(T valueToCompare)
        {
            Node<T> node = new Node<T>();
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
            Node<T> nodeToRemove = this.Find(item);
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
            if (existingNode == null)
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
            for (Node<T> node = head.Next; node != head; node = node.Next)
            {
                yield return node.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
