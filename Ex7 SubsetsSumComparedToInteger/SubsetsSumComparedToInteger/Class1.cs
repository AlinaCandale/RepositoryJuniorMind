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

        public List<List<int>> GetRequiredSumSubArray(int[] set, int sum)
        {
            List<int> subArray = new();
            List<List<int>> result = new();

            for (int i = 0; i < set.Length; i++)
            {
                int temp = 0;
                subArray.Clear();

                for (int j = i; j < set.Length; j++)
                {
                    temp += set[j];
                    
                    if (temp <= sum)
                    {
                        subArray.Add(set[j]);
                        result.Add(new List<int>(subArray));
                    }
                    
                    if (temp > sum)
                    {
                        subArray.Clear(); 
                        temp = 0;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
//Pentru un șir de numere întregi și un număr întreg dat k generează toate subșirurile a căror sumă este mai mică sau egală cu k.