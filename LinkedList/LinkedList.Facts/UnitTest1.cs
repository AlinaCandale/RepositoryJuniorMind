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

            MyList.Add(10);
            MyList.RemoveFirst();
            MyList.Add(20);
            MyList.AddFirst(30);
            MyList.AddBefore(20, 15);
            MyList.AddAfter(15, 35);
            MyList.RemoveLast();

        }
    }
}
