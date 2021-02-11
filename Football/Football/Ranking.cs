using System;
using System.Collections.Generic;
using System.Text;

namespace Football
{
    public class Ranking
    {
        FootballTeam[] List = { };

        public void AddTeam(FootballTeam team)
        {
            FootballTeam[] NewList = new FootballTeam[List.Length + 1];
            for (int i = 0; i < List.Length; i++)
            {
                NewList[i] = List[i];
            }
            NewList[NewList.Length - 1] = team;
            List = NewList;
        }

        public int CheckPozition(string team)
        {
            if (List.Length == 0)
            {
                return -1;
            }

            for (int i = 0; i < List.Length; i++)
            {
                if (List[i].GetTeamName() == team)
                {
                    return i + 1;
                }
            }

            return -1;
        }

        public string CHeckTeamAtASpecifiedPozition(int pozition)
        {
            if (List.Length == 0 || pozition > List.Length && pozition != 0)
            {
                return "";
            }
            
            return List[pozition - 1].GetTeamName();
            
        }

        public void TeamsRanking()
        {
            int x = 0;
            while (x == 0)
            {
                x = 1;
                for (int i = 0; i < List.Length - 1; i++)
                {
                    for (int j = i + 1; j < List.Length; j++)
                    {
                        if (List[j].GetTeamNumber() > List[j - 1].GetTeamNumber())
                        {
                            Swap(List, j, j - 1);
                            x = 0;
                        }
                    }
                }
                
            }
        }

        static void Swap(FootballTeam[] List, int firstIndex, int secondIndex)
        {
            (int minIndex, int maxIndex) = GetMinMaxIndex(firstIndex, secondIndex);

            FootballTeam temp = List[minIndex];
            List[minIndex] = List[maxIndex];
            List[maxIndex] = temp;
        }

        static (int minIndex, int maxIndex) GetMinMaxIndex(int firstIndex, int secondIndex)
        {
            if (firstIndex < secondIndex)
            {
                return (secondIndex, firstIndex);
            }

            return (firstIndex, secondIndex);
        }
    }
}
