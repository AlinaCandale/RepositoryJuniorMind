using System;
using Xunit;

namespace Football
{
    public class FootballTeam
    {
        readonly string teamName;
        int points;

        public FootballTeam(string teamName, int points)
        {
            this.teamName = teamName;
            this.points = points;
        }

        public bool CompareTeamsPoints(FootballTeam secondTeam)
        {
            return this.points < secondTeam.points;
        }

        public void AddPoints(int points)
        {
            this.points += points;
        }
    }
}
