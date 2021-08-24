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
            this.sentence = sentence;
        }

        public int GetNrOfVowels()
        {
            return sentence.Count(c => "aeiou".Contains(Char.ToLower(c)));
        }

        public int GetNrOfConsonant()
        {
            return sentence.Where(c => Char.IsLetter(c)).Count(c => !"aeiou".Contains(Char.ToLower(c)));
        }
    }
}
