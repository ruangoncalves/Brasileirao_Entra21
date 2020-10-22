using System;
using System.Collections.Generic;

namespace Domain
{
    public class Championship 
    {
        public bool championshipStart {get; protected set; } = false;
        public int Rodada { get; private set; }
        private List<Team> teams { get; set; } = new List<Team>();
        public IReadOnlyCollection<Team> Teams => teams;

        public void CreateMatchs(List<Team> teams)
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

        public void TeamRegister()
        {

        }


    }
}