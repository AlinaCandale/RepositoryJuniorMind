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
                .Where(g => g.Count() == 1)
                .Select(g => g.Key).First();
        }
    }
}
