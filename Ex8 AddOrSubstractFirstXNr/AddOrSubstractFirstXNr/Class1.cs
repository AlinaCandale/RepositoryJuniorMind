using System;
using System.Collections.Generic;
using System.Linq;

namespace AddOrSubstractFirstXNr
{
    public class GetResultK
    {
        public static string[] AllSignsCombinations(int n, int k)
        {
            IEnumerable<string> sign = new string[] { "" };
            return Enumerable.Range(1, n)
                .Aggregate(sign, (x, y) => x.SelectMany(z => new string[] { z + "-", z + "+" }))
                .Where(combination => Enumerable.Range(0, n).Aggregate(0, (sum, number) => combination[number] == '+' ? sum + (number + 1) : sum - (number + 1)) == k).ToArray();
        }
    } 
}

// Dându-se două numere întregi n și k tipărește toate combinațiile de forma: ±1±2±3±...±n = k
