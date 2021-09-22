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
            return text.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
        }
    }
}
