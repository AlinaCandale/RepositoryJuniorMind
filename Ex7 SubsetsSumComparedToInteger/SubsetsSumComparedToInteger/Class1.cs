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

        public List<int[]> GetRequiredSumSubArray(int[] set, int sum)
        {
            return Enumerable.Range(0, set.Length)
                .SelectMany(i => Enumerable.Range(i, set.Length - i).Select(j => set[i..(j + 1)]))
                .Where(x => x.Sum() <= sum).ToList();
        }
    }
}
//Pentru un șir de numere întregi și un număr întreg dat k generează toate subșirurile a căror sumă este mai mică sau egală cu k.