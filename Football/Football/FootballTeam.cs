using System;
using Xunit;

namespace Football
{
    public class FootballTeam
    {
        readonly string teamName;
        readonly int points;

        public FootballTeam(string teamName, int points)
        {
            this.teamName = teamName;
            this.points = points;
        }

        public string GetTeamName()
        {
            return teamName;
        }

        public int GetTeamNumber()
        {
            return points;
        }

    }
}
