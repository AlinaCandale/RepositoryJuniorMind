using System;
using System.Collections.Generic;
using System.Text;

namespace IntArray
{
    public class ExceptionTestClass
    {
        public static double Division(double x, double y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException();
            }

            return x / y;
        }
    }
}
