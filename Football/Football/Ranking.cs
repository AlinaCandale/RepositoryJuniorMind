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
            for (int j = 0; j <= list.Length - 2; j++)
            {

                for (int i = 0; i <= list.Length - 2; i++)
                {
                    if (list[i].CompareTeamsPoints(list[i + 1]))
                    {
                        FootballTeam temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                    }
                }
            }
        }
    }
}
