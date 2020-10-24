using System;
using System.Collections.Generic;

namespace Domain
{
    public class Championship 
    {
        public bool championshipStart {get; protected set; } = false;
        public int Round { get; private set; }
        private List<Team> _teams { get; set; } = new List<Team>();
        public IReadOnlyCollection<Team> Teams => _teams;

        public void CreateMatches(List<Team> teams)
        {
            var rand = new Random();
            
            for(int i = 0;i < teams.Count;i++)
            {
                var x = rand.Next(teams.Count);
                var temp = teams[i];
                teams[i] = teams[x];
                teams[x] = temp;
            }
        }

        public bool ChampionshipStart(User user)
        {
            if(user.Profile.Equals("Torcedor"))
            {
                return championshipStart;
            }

            return !championshipStart;
        } 

        public bool TeamRegister(User user, List<Team> teams)
        {
            if(user.Profile.Equals("Torcedor"))
            {
                return false;
            }
            else if(championshipStart == true)
            {
                return false;
            }
            else if(teams.Count < 7)
            {
                return false;
            }

            _teams = teams;
            championshipStart = true;
            return true;
        }

        public bool RemovePlayerTeam(User user, Player player, Guid IdTeam)
        {
            if(user.Profile.Equals("Torcedor"))
            {
                return false;
            }

            _teams.Find(x => x.Id == IdTeam).RemovePlayer(player);
            return true;
        }

        public bool AddPlayerTeam(User user, Player player, Guid IdTeam)
        {
            if(user.Profile.Equals("Torcedor"))
            {
                return false;
            }

            _teams.Find(x => x.Id == IdTeam).AddPlayer(player);
            return true;
        }

        public List<string> DisplayTable(User user)
        {
            if(user.Profile.Equals("Torcedor"))
            {
                return null;
            }



        }

        public List<string> ShowTeamsQualified(User user)
        {

        }

        public List<string> ShowTeamsDesqualified(User user)
        {
            
        }
        
        public List<string> ShowPlayerScorer(User user)
        {
            
        }

        public List<string> ShowResultRound(User user)
        {
            
        }


        private void CreateRound(int qttRound)
        {
            
        }

    }
}