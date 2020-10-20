using System;
using Xunit;
using Domain;
using System.Collections.Generic;

namespace Tests
{
    public class ChampionshipTest
    {
        [Fact]
        public void Should_create_matchs()
        {
            var champ = new Championship();
            var teams = new List<string>{"Palmeiras","Vasco","Santos","Flamengo"};

            var expected = champ.CreateMatchs(teams);

            Assert.NotNull(expected);
        }
    }
}