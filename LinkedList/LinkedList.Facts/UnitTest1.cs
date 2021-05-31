using System;
using Xunit;

namespace LinkedList.Facts
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            CircularLinkedList<int> MyList = new CircularLinkedList<int>();

            MyList.AddLast(10);
            MyList.AddLast(20);
            MyList.AddFirst(30);
        }
    }
}
