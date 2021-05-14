using System;
using Xunit;

namespace IntArray.Facts
{
    public class ExceptionTestClassFacts
    {
        [Fact]
        public void CheckDivision()
        {
            double a = 98, b = 0;
            double result;

            try
            {
                result = ExceptionTestClass.Division(a, b);
                Console.WriteLine("{0} divided by {1} = {2}", a, b, result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Attempted divide by zero.");
                result = 0;
            }
            Assert.Equal(0, result);
        }

        [Fact]
        public void CheckDivisionByZero()
        {
            double a = 98, b = 0;
            double result;
            Assert.Throws<DivideByZeroException>(() => result = ExceptionTestClass.Division(a, b));
        }
    }
}
