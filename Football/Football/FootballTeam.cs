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

        public bool CompareTeamsPoints(FootballTeam secondTeam)
        {
            if (this.points > secondTeam.points)
            {
                return false;
            }

            return true;
        }
    }
}
