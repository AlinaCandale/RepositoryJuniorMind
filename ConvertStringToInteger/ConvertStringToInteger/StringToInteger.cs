using System;
using System.Linq;

namespace ConvertStringToInteger
{
    public class StringToInteger
    {
        string[] text;

        public StringToInteger(string[] sentence)
        {
            this.text = sentence;
        }

        public int[] GetIntFromString()
        {
            //return text.Split().Select(s => Convert.ToInt32(s)).ToArray();
            //return text.Select(s => int.TryParse(s, out int result) ? result : 0);
            
            int i = 0;
            var a = text.SelectMany(s => int.TryParse(s, out i) ? new[] { i } : new int[0]).ToArray();
            return a;
        }
    }
}
