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
            MyList.AddAtPosition(40, 2);
            MyList.Find(20);
            MyList.RemoveLast();

        }
    }
}
