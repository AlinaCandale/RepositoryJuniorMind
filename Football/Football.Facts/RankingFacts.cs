using System;
using Xunit;

namespace Football.Facts
{
    public class RankingFacts
    {
        FootballTeam first = new FootballTeam("Steaua", 4);
        FootballTeam second = new FootballTeam("UCluj", 5);
        FootballTeam third = new FootballTeam("Chiajna", 0);
        FootballTeam fourth = new FootballTeam("Astra", 1);
        FootballTeam fifth = new FootballTeam("Otelul", 4);

        [Fact]
        public void AddTeamWorks()
        {
            Ranking teamList = new Ranking();
            teamList.AddTeam(first);

            Assert.Equal("Steaua", teamList.CHeckTeamAtASpecifiedPozition(1));
        }

        [Fact]
        public void CheckIfTeamIsOnMentionedPozition()
        {
            Ranking teamList = new Ranking();
            teamList.AddTeam(first);
            teamList.AddTeam(second);

            Assert.Equal(2, teamList.CheckPozition("UCluj"));
        }

        [Fact]
        public void CheckIfTeamIsNotInTheList()
        {
            Ranking teamList = new Ranking();
            teamList.AddTeam(first);
            teamList.AddTeam(second);

            Assert.Equal(-1, teamList.CheckPozition("Chiajna"));
        }

        [Fact]
        public void CheckWhatTeamIsOnSpecifiedPozition()
        {
            Ranking teamList = new Ranking();
            teamList.AddTeam(first);
            teamList.AddTeam(second);

            Assert.Equal(1, teamList.CheckPozition("Steaua"));
        }

        [Fact]
        public void CheckIfRankingIsSorted()
        {
            Ranking teamList = new Ranking();
            teamList.AddTeam(first);
            teamList.AddTeam(second);
            teamList.AddTeam(third);
            teamList.AddTeam(fourth);
            teamList.AddTeam(fifth);

            teamList.TeamsRanking();

            Assert.Equal(1, teamList.CheckPozition("UCluj"));
            Assert.Equal(2, teamList.CheckPozition("Steaua"));
            Assert.Equal(3, teamList.CheckPozition("Otelul"));
            Assert.Equal(4, teamList.CheckPozition("Astra"));
            Assert.Equal(5, teamList.CheckPozition("Chiajna"));

        }
    }
}
