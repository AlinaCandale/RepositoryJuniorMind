using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstUniqueChar
{
    public class FindFirstUniqueChar
    {
        string sentence;

        public FindFirstUniqueChar(string sentence)
        {
            this.sentence = sentence;
        }

        public string SearhForFirstUniqueChar()
        {
            return sentence.GroupBy(c => c.ToString(), c => c, StringComparer.OrdinalIgnoreCase)
                .First(g => g.Count() == 1).Key;
        }
    }
}