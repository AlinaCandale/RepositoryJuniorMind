using System;
using Xunit;

namespace MyFirstRepository.Tests
{
    public class ProgramTest
    {
        [Fact]
        public void CheckIfFactorialIsZero()
        {
            int n = 0;
            int rez = Program.Factorial(n);
            Assert.Equal(0, rez);
        }
    }
}
