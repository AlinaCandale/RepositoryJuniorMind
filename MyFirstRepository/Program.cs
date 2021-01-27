using System;

namespace MyFirstRepository
{
    public class Program
    {
        static void Main()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Factorial(n));
        }

        static public int Factorial(int n)
        {
            int rez = 1;
            while (n >= 1)
            {
                rez *= n;
                n = n - 1;
            }
            return rez;
        }
    }
}
