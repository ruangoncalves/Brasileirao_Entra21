using System;
using Xunit;
using Domain;
using System.Collections.Generic;

namespace Tests
{
    public class TeamTest
    {
        [Fact]
        public void Should_register_team()
        {
            Team Palmeiras = new Team("Palmeiras");
                        
            Assert.NotNull(Palmeiras);
        }

        [Fact]
        public void Should_add_list_players()
        {
            Team Palmeiras = new Team("Palmeiras");
            List<Player> player = new List<Player>()
            {
                new Player("Roberto"),
                new Player("Luis"),
                new Player("Arnaldo"),
                new Player("Ramalho"),
                new Player("Ednei"),
                new Player("Rafael"),
                new Player("Eduardo"),
                new Player("Raul"),
                new Player("Bento"),
                new Player("Wagner"),
                new Player("Nei"),
                new Player("André"),
                new Player("Carlo"),
                new Player("Jonas"),
                new Player("Marcelo"),
                new Player("Gustavo"),
                new Player("Diego"),
                new Player("Cicero"),
                new Player("Marcos"),
                new Player("Tiago"),
            };

            var expected = Palmeiras.AddListPlayers(player);

            Assert.True(expected);
            Assert.Equal(20,Palmeiras.Players.Count);
        }

        [Fact]
        public void Should_add_player()
        {
            Team Palmeiras = new Team("Palmeiras");
            Player player = new Player("Robson");

            var expected = Palmeiras.AddPlayer(player);
                        
            Assert.True(expected);
        }

        [Fact]
        public void Should_remove_player()
        {
            Team Palmeiras = new Team("Palmeiras");
            Player player = new Player("Robson");

            var expected = Palmeiras.RemovePlayer(player);
                        
            Assert.True(expected);
        }
    }
}