using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class CircularLinkedList<T>
    {
        public int Count { get { return Count; } private set { } }
        public Node<T> head;

        public CircularLinkedList()
        {
            head = null;
            Count = 0;
         }

        //public void AddElement(T item)
        //{
        //    Node<T> tmp = new Node<T>(item);
        //    tmp.Next = Head;
        //    tmp.Previous = Tail;
        //    if (Count < 1)
        //    {
        //        Head = tmp;
        //        Tail = tmp;
        //    }
        //    else
        //    {
        //        tmp.Previous.Next = tmp;
        //        Head.Previous = tmp;
        //        Tail = tmp;

        //    }
        //    Count++;
        // }

        public void AddFirst(T newElement)
        {
            Node<T> newNode = new Node<T>(newElement)
            {
                Value = newElement,
                Next = null,
                Previous = null
            };

            if (head == null)
            {
                head = newNode;
                newNode.Next = head;
                newNode.Previous = head;
            }
            else
            {
                Node<T> temp = new Node<T>(newElement);
                temp = head;
                while (temp.Next != head)
                {
                    temp = temp.Next;
                }
                temp.Next = newNode;
                newNode.Previous = temp;
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
            Count++;
        }

        public void AddLast(T newElement)
        {
            Node<T> newNode = new Node<T>(newElement);
            newNode.Value = newElement;
            newNode.Next = null;
            newNode.Previous = null;
            if (head == null)
            {
                head = newNode;
                newNode.Next = head;
                newNode.Previous = head;
            }
            else
            {
                Node<T> temp = new Node<T>(newElement);
                temp = head;
                while (temp.Next != head)
                {
                    temp = temp.Next;
                }
                temp.Next = newNode;
                newNode.Next = head;
                newNode.Previous = temp;
                head.Previous = newNode;
            }
            Count++;
        }

        public void AddAtPosition(T newElement, int position)
        {
            Node<T> newNode = new Node<T>(newElement);
            newNode.Value = newElement;
            newNode.Next = null;
            Node<T> temp = head;
            
            if (position < 1 || position > (Count + 1))
            {
                Console.Write("\nInvalid position.");
            }
            else if (position == 1)
            {
                if (head == null)
                {
                    head = newNode;
                    head.Next = head;
                    head.Previous = head;
                }
                else
                {
                    while (temp.Next != head)
                    {
                        temp = temp.Next;
                    }
                    temp.Next = newNode;
                    newNode.Previous = temp;
                    newNode.Next = head;
                    head.Previous = newNode;
                    head = newNode;
                }
            }
            else
            {
                temp = head;
                for (int i = 1; i < position - 1; i++)
                    temp = temp.Next;
                newNode.Next = temp.Next;
                newNode.Next.Previous = newNode;
                newNode.Previous = temp;
                temp.Next = newNode;
            }
        }


    }
}
