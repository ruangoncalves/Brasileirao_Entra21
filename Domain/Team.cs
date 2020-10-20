using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Team 
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public List<Player> Players { get; set; } = new List<Player>();
        public int Score { get; set; } = 0;
        public int Matchs { get; set; } = 0;
        public int Wins { get; set; } = 0;
        public int Draw { get; set; } = 0;
        public int Loses { get; set; } = 0;
        public int Goals { get; set; } = 0;
        public int GoalsPro { get; set; } = 0;
        public int GoalsSofrido { get; set; } = 0;

        public Team(string name) 
        {
            Id = Guid.NewGuid();
            Name = name;       
        }
        
        public bool AddListPlayers(List<Player> players)
        {
            if(players.Count > 32 && players.Count < 16)
            {
                return false;
            }
            Players = players;
            return true;
        }

        public bool AddPlayer(Player player)
        {
            //Se existir 32 jogadores no time, não pode permitir que eu inclua mais
            if(Players.Count > 31 && Players.Count < 16)
            {
                return false;
            }
            Players.Add(player);
            return true;
        }

        public bool RemovePlayer(Player player)
        {
            //Se existir 16 jogadores no time, não pode permitir que eu exclua mais
            if(Players.Count > 32 && Players.Count < 17)
            {
                return false;
            }
            Players.Remove(player);
            return true;
        }
   

    }
}