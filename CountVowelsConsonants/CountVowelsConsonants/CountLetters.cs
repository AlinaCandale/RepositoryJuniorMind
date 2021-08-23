using System;
using System.Collections.Generic;
using System.Linq;

namespace CountVowelsConsonants
{
    public class CountLetters
    {
        string sentence;
        int vowelCount;
        int consonantCount;

        public CountLetters(string sentence)
        {
            this.sentence = sentence;
            CountVowelsandCOnsonants();
        }

        public int GetNrOfVowels()
        {
            return vowelCount;
        }

        public int GetNrOfConsonant()
        {
            return consonantCount;
        }
        
        void CountVowelsandCOnsonants()
        {
            foreach (char c in sentence.ToLower())
            {
                if (Char.IsLetter(c))
                {
                    if ("aeiou".Contains(c))
                    {
                        vowelCount++;
                    }
                    else
                    {
                        consonantCount++;
                    }
                }
            }
        }
    }
}
//int vowelCount = sentence.Count(c => "aeiou".Contains(Char.ToLower(c)));

//int letterCount = sentence.Count(c => Char.IsLetter(c));
//int vowelCount = sentence.Count(c => "aeiou".Contains(Char.ToLower(c)));
//string test = "abbbb";
//char[] vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };
//var result = test.ToCharArray().Where(c => vowels.Contains(c));
//Console.WriteLine(result.Count());
//Console.ReadLine();


//foreach (var consonant in line.Where(charInString => !charArray.Contains(charInString)).Distinct())
//{
//    consonantCounts.Add(consonant, line.Count(charInString => consonant == charInString));
//}