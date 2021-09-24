using System;
using System.Collections.Generic;
using System.Linq;

namespace StringPalindrome
{
    public class AllPalindromPartitionInString
    {
        string text;

        public AllPalindromPartitionInString(string sentence)
        {
            this.text = sentence;
        }

        public string[] GenerateAllPalindromPartitionInString()
        {
            return Enumerable.Range(1, text.Length)
                .SelectMany(length => Enumerable.Range(0, text.Length - length + 1).Select(i => text.Substring(i, length)))
                .Where(item => item.SequenceEqual(item.Reverse()))
                .ToArray();

            //var r = Enumerable.Range(1, text.Length);
            //var rr = r.SelectMany(length => Enumerable.Range(0, text.Length - length + 1).Select(i => text.Substring(i, length)));
            //var rrr = rr.Where(item => item.SequenceEqual(item.Reverse()));
            //var rrrr = rrr.ToArray();

            //return rrrr;
        }
    }
}
