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
            SortTeamsByPoints();
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

        public FootballTeam GetTeamAtPosition(int position)
        {
            if (list.Length == 0 || position > list.Length && position != 0)
            {
                return null;
            }
            
            return list[position - 1];
            
        }

        void SortTeamsByPoints()
        {
            for (int i = 0; i < list.Length - 1; i++)
            {
                bool swapped = false;
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (list[j - 1].CompareTeamsPoints(list[j]))
                    {
                        FootballTeam temp = list[j];
                        list[j] = list[j - 1];
                        list[j - 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
        }
    }
}
