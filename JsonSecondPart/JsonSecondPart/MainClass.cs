using System;

namespace JsonSecondPart
{
    class MainClass
    {
        static void Main(string[] args)
        {
            foreach (var item in args)
            {
                string text = System.IO.File.ReadAllText(@item);

                var a = new Value();
                if (a.Match(text).Success())
                {
                    Console.WriteLine("You have a valid Json value");
                }
                else
                {
                    Console.WriteLine("You don't have a valid Json value");
                }
            }

        }
    }

}