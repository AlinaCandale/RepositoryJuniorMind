using System;
using System.Collections.Generic;
using System.Text;

namespace Football
{
    public class Ranking
    {
        FootballTeam[] list = { };

        public void AddTeam(FootballTeam team)
        {
            Array.Resize(ref list, list.Length + 1);
            list[list.Length - 1] = team;
        }

        public int GetTeamPosition(FootballTeam team)
        {
            if (list.Length == 0)
            {
                return -1;
            }

            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == team)
                {
                    return i + 1;
                }
            }

            return -1;
        }

        public FootballTeam GetTeamAtPosition(int pozition)
        {
            if (list.Length == 0 || pozition > list.Length && pozition != 0)
            {
                return null;
            }
            
            return list[pozition - 1];
            
        }

        public void TeamsRanking()
        {
            int x = 0;
            while (x == 0)
            {
                x = 1;
                for (int i = 0; i < list.Length - 1; i++)
                {
                    for (int j = i + 1; j < list.Length; j++)
                    {
                        if (list[j].GetTeamNumber() > list[j - 1].GetTeamNumber())
                        {
                            Swap(list, j, j - 1);
                            x = 0;
                        }
                    }
                }
                
            }
        }

        void Swap(FootballTeam[] List, int firstIndex, int secondIndex)
        {
            if (firstIndex < secondIndex)
            {
                FootballTeam temp = List[firstIndex];
                List[firstIndex] = List[secondIndex];
                List[secondIndex] = temp;
            }
        }
    }
}
