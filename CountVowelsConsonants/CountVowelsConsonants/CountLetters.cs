using System;
using System.Collections.Generic;
using System.Linq;

namespace CountVowelsConsonants
{
    public class CountLetters
    {
        string sentence;

        public CountLetters(string sentence)
        {
            this.sentence = sentence.ToLower();
        }

        public Tuple<int, int> GetNrOfVowelsAndConsonant()
        {
            return new Tuple<int, int>(sentence.Count(c => "aeiou".Contains(c)), 
                sentence.Count(c => Char.IsLetter(c) && !"aeiou".Contains(c)));
        }
    }
}
