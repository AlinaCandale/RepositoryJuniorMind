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

        public (int vowelsNr, int consonantNr) GetNrOfVowelsAndConsonant()
        {
            return sentence.Aggregate((vowelNr : 0, consonantNr : 0), (seed, c) => Char.IsLetter(c) ? 
                    "aeiou".Contains(c) ? (++seed.vowelNr, seed.consonantNr) : (seed.vowelNr, ++seed.consonantNr) : 
                    seed, seed => seed);
        }
    }
}
