using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetsSumComparedToInteger
{
    public class GetAllSubsets
    {
        int[] set;

        public GetAllSubsets(int[] set)//, int sum)
        {
            this.set = set;
        }

        public List<int[]> GetRequiredSumSubArray(int[] set)
        {
            //List<int> subArray = new();
            List<int[]> result = new();

            for (int i = 0; i < set.Length; i++)
            {
                //subArray.Clear();
                
                for (int j = i; j < set.Length; j++)
                {
                    result.Add(set[i..(j+1)]);
                    //subArray.Add(set[j]);
                    //result.Add(new List<int>(subArray));
                }
            }

            return result;
        }
    }
}
//Pentru un șir de numere întregi și un număr întreg dat k generează toate subșirurile a căror sumă este mai mică sau egală cu k.