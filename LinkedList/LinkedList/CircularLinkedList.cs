using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class CircularLinkedList<T> : ICollection<T>
    {
        public int Count { get; private set; } = 0;
        public bool IsReadOnly => false;

        public Node<T> head;

        public CircularLinkedList()
        {
            head = new Node<T>();
            head.Next = head;
            head.Previous = head;
        }

        public void AddFirst(T newElement)
        {
            Node<T> newNode = new Node<T>(newElement);
            newNode.Value = newElement;

            newNode.Next = head.Next;
            newNode.Previous = head;
            head.Next.Previous = newNode;
            head.Next = newNode;

            Count++;
        }

        public void Add(T newElement)
        {
            Node<T> newNode = new Node<T>(newElement);
            newNode.Value = newElement;

            newNode.Next = head;
            newNode.Previous = head.Previous;
            head.Previous.Next = newNode;
            head.Previous = newNode;

            Count++;
        }

        public void AddAtPosition(T newElement, int position)
        {
            Node<T> newNode = new Node<T>(newElement);
            newNode.Value = newElement;
            Node<T> temp;

            if (position < 1 || position > (Count + 1))
            {
                Console.Write("\nInvalid position.");
            }
            else if (position == 1)
            {
                AddFirst(newElement);
            }
            else
            {
                temp = head;
                for (int i = 1; i < position; i++)
                {
                    temp = temp.Next;
                }
                newNode.Next = temp.Next;
                newNode.Previous = temp;
                temp.Next.Previous = newNode;
                temp.Next = newNode;
            }
            
            Count++;
        }

        public void Clear()
        {
            while (true && Count != 0)
            {
                Count--;
                //Remove(head.Next.Value);
                RemoveFirst();
            }
        }
        
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
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

        //public void RemoveAll(T item)
        //{
        //    bool removed = false;
        //    do
        //    {
        //        removed = this.Remove(item);
        //    } while (removed);
        //}


        public bool RemoveFirst()
        {
            return RemoveNode(head.Next);
        }

        public bool RemoveLast()
        {
            return RemoveNode(head.Previous);
        }
    }
}
