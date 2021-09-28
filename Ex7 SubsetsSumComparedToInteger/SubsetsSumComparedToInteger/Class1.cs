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

        public static void GetRequiredSumSubArray(int[] set, int sum)
        {
            List<int> subArray = new();
            int temp = 0;
            for (int i = 0; i < set.Length; i++)
            {
                for (int j = i, j < set.Length; j++)
                {
                    temp += set[j];
                    subArray.Add(set[j]);
                    
                    if (temp == sum)
                    {
                        Console.WriteLine(string.Join(", ", subArray));
                    }
                    
                    if (temp > sum)
                    {
                        subArray.Clear(); 
                        temp = 0;
                        break;
                    }
                }
            }
        }
    }
}
//Pentru un șir de numere întregi și un număr întreg dat k generează toate subșirurile a căror sumă este mai mică sau egală cu k.