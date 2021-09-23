using System;
using System.Collections.Generic;
using System.Linq;

namespace MostFrequentlyAppearingChar
{
    public class CharWIthMaxAppearances
    {
        string text;

        public CharWIthMaxAppearances(string sentence)
        {
            this.text = sentence;
        }

        public char FindCharWIthMaxAppearances()
        {
            //return text.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
            
            var group = text.GroupBy(x => x);
            return group.Where(x => x.Count() == group.Max(b => b.Count())).First().Key;
        }
    }
}
