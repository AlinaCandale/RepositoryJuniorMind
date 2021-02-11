using System;
using Xunit;

namespace Football.Facts
{
    public class FootballTeamFacts
    {
        [Fact]
        public void CheckIfTeamNameIsCorrect()
        {
            Football.FootballTeam x = new Football.FootballTeam("Astra", 3);
            Assert.Equal("Astra", x.GetTeamName());
        }

        [Fact]
        public void CheckIfTeamPointsAreCorrect()
        {
            Football.FootballTeam x = new Football.FootballTeam("Astra", 3);
            Assert.Equal(3, x.GetTeamNumber());
        }
    }
}
