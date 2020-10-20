using System;
using Xunit;
using Domain;

namespace Tests
{
    public class PlayerTest
    {
        [Fact]
        public void Should_register_players()
        {
            Player Roberto  = new Player("Roberto");
                        
            Assert.NotNull(Roberto);
        }

    }
}