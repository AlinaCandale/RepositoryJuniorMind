using System;

namespace JsonSecondPart
{
    class MainClass
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please give as argument a path to a Json file");
            }
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