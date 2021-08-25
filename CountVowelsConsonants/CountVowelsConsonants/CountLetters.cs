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

        public (int, int) GetNrOfVowelsAndConsonant()
        {
            return sentence.Aggregate((0, 0), (seed, c) => Char.IsLetter(c) ? 
                                        "aeiou".Contains(c) ? (++seed.Item1, seed.Item2) : (seed.Item1, ++seed.Item2) : seed,
                                        seed => seed);
        }
    }
}
