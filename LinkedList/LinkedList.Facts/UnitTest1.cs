using System;
using Xunit;

namespace LinkedList.Facts
{
    public class UnitTest1
    {
        [Fact]
        public void CheckAdd()
        {
            CircularLinkedList<int> MyList = new CircularLinkedList<int>();
            
            MyList.AddFirst(11);
            MyList.Add(10);
            MyList.AddLast(20);
            MyList.AddFirst(30);
            MyList.AddBefore(MyList.Find(20), 15);
            MyList.AddAfter(MyList.Find(15), 35);
            MyList.AddAfter(MyList.Find(15), new Node<int>(8));
            MyList.RemoveFirst();
            MyList.RemoveLast();
            MyList.Find(30);

        }
    }
}
