using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetsSumComparedToInteger
{
    public class GetAllSubsets
    {
        int[] set;
        int sum;

        public GetAllSubsets(int[] set, int sum)
        {
            this.set = set;
            this.sum = sum;
        }

        //public int[] AllSubsetsWithSumLessThanInt()
        //{

        //    //return Enumerable.Range(1, set.Length)
        //    //    .SelectMany(length => Enumerable.Range(0, set.Length - length + 1).Select(i => set.Substring(i, length)))
        //    //    .Where(item => item.SequenceEqual(item.Reverse()))
        //    //    .ToArray();

        //    //var r = Enumerable.Range(1, text.Length);
        //    //var rr = r.SelectMany(length => Enumerable.Range(0, text.Length - length + 1).Select(i => text.Substring(i, length)));
        //    //var rrr = rr.Where(item => item.SequenceEqual(item.Reverse()));
        //    //var rrrr = rrr.ToArray();
        //    //return rrrr;

        //    //NU
        //    //return (int[])Enumerable.Range(1, set.Length)
        //    //    .SelectMany(length => Enumerable.Range(0, set.Length - length + 1).Select((i, length) => set.Sum()))
        //    //    .Where(item => item <= nr)
        //    //    .ToArray();

        //    //var r = Enumerable.Range(1, set.Length - 1);
        //    //var rr = r.SelectMany(length => Enumerable.Range(1, set.Length * set.Length - 1).Select((i, length) => set.Sum()));
        //    //var rrr = rr.Where(item => item <= nr);
        //    //var rrrr = rrr.ToArray();

        //    //return rrrr;

        //}

        public static IEnumerable<T[]> GetCombinations<T>(IEnumerable<T> source)
        {
            if (null == source)
                throw new ArgumentNullException(nameof(source));

            T[] data = source.ToArray();

            return Enumerable.Range(1, (1 << (data.Length)) - 2)
              .Select(index => data.Where((v, i) => (index & (1 << i)) != 0).ToArray());
        }



    }
}
//Pentru un șir de numere întregi și un număr întreg dat k generează toate subșirurile a căror sumă este mai mică sau egală cu k.