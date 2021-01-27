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

        [Fact]
        public void CheckIfFactorialIsOne()
        {
            int n = 1;
            int rez = Program.Factorial(n);
            Assert.Equal(1, rez);
        }

        [Fact]
        public void CheckIfFactorialIsCorrectIfnIsBiggerThanOne()
        {
            int n = 6;
            int rez = Program.Factorial(n);
            Assert.Equal(720, rez);
        }
    }
}
