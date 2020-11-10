using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Users;

namespace Domain
{
    public class Championship 
    {
//     <~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~[Proprieties]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

        public bool championshipStart {get; protected set; } = false;
        public List<Match> Matches { get; private set; } = new List<Match>();
        public List<Round> Rounds { get; private set; } = new List<Round>();
        private List<Team> teams { get; set; } = new List<Team>();
        public IReadOnlyCollection<Team> Teams => teams;
        public int Round {get; private set;} = 0;
        public User CurrentUser {get; private set;}
        public int MatchesPerRounds {get; private set;}


//     <~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~[Register]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>


        public void RegisterUser(string name, Profile profile)
        {
            CurrentUser = new User(name, profile);
        }
        public bool RegisterTeams(User user, List<Team> newTeams)
        {
            if(!user.CBF)
            {
                return false;
            }
            else if(championshipStart == true)
            {
                return false;
            }

            teams = newTeams;
            return true;
        }

        public bool RemovePlayer(User user, Player player, Guid IdTeam)
        {
            if(!CurrentUser.CBF)
            {
                return false;
            }
            if(teams.Count < 0 )
            {
                return false;
            }
            teams.Find(x => x.Id == IdTeam).RemovePlayer(player);
            return true;
        }

        public bool AddPlayer(User user, Player player, Guid IdTeam)
        {
            if(!CurrentUser.CBF)
            {
                return false;
            }

            teams.Find(x => x.Id == IdTeam).AddPlayer(player);
            return true;
        }
        
        private bool CalculateMatchesPerRound()
        {
            var teamsPerMatche = 2;

            if(teams.Count % 2 != 0)
            {
                return false;
            }
            var matchesPerRound = teams.Count / teamsPerMatche;
            MatchesPerRounds = matchesPerRound;
            return true;
        }

        private int RoundsNumber()
        {
            var roundsNumber = ((teams.Count * (teams.Count - 1)) / 2) / MatchesPerRounds;

            Round = roundsNumber;
            return roundsNumber;
        }
        
        // private bool playRound(User user)
        // {
        //     if(!CurrentUser.CBF)
        //     {
        //         return false;
        //     }
        //     if (Rounds.Count.Equals(0))
        //     {
        //         return false;   
        //     }
        //     if (Round > RoundsNumber())
        //     {
        //         return false;
        //     }

        //     var CurrentRound = Rounds.First( round => round.PlayedRound == false);
            
        //     foreach (var match in CurrentRound.Matches)
        //     {
        //        match.PlayMatch();
        //     }
            
        //     CurrentRound.PlayedRound = true;
        //     return true;
        // }

        private bool CreateMatches()
        {
            if(teams.Count < 8)
            {
                return false;
            }
            // var rand = new Random();
        
            // for(int i = 0;i < teams.Count;i++)
            // {
            //     var x = rand.Next(teams.Count);
            //     var temp = teams[i];
            //     teams[i] = teams[x];
            //     teams[x] = temp;
            // }


            for (int i = 0; i < teams.Count; i++)
            { 
                for (int j = i + 1; j < teams.Count; j++)
                {
                    if(i != j)
                    {
                        Matches.Add(new Match(teams[i], teams[j]) );
                    } 
                }
            }
            
            return true;
        }

        

        private bool CreateRound()
        {
            if (Matches.Count % MatchesPerRounds != 0)
            {
                return false;
            }
            // if (Round == RoundsNumber())
            // {
            //     return false;
            // }

            var RoundMatches = new List<Match>();
            
            for (int i = 0; i < MatchesPerRounds; i++)
            {
                var temp = new Random().Next(Matches.Count);
                RoundMatches.Add(Matches[temp]);

                Rounds.Add(new Round(RoundMatches));
                Matches.RemoveAt(temp);
            }
            Round++;
            return true;
        }
        public bool ChampionshipStart(User user, Player player, int gol)
        {
            if(!CurrentUser.CBF)
            {
                return false;
            }

            CalculateMatchesPerRound();
            RoundsNumber();
            CreateMatches();
            CreateRound();
            
            championshipStart = true;

            var rdn = new Random();

            for(int j = 0; j < gol; j++)
            {
                player.GiveGoal();
            }

            return true;
          
        }
    

//     <~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~[Showing]~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~>

        public List<Player>  GetTopScorers()
        {
            var TopScorers = new List<Player>();

            foreach (var team in Teams)
            {
                TopScorers.AddRange(team.Players);
            }

            return TopScorers.OrderByDescending(player => player.Goals).ToList();
        }
        public List<Team> DisplayTable()
        {
            var TeamOrdered = teams.OrderByDescending(x => x.Table.Score).ThenByDescending(x => x.Table.GoalsDifference).ThenByDescending(x => x.Table.MakedGoals);
            
            return TeamOrdered.ToList();

        }
        public List<Team> QualifiedTeams()
        {
            var TeamOrdered = teams.OrderByDescending(x => x.Table.Score).ThenByDescending(x => x.Table.GoalsDifference).ThenByDescending(x => x.Table.MakedGoals);
            
            return TeamOrdered.Take(4).ToList();

        }
        public List<Team> DisqualifiedTeams()
        {
            var TeamOrdered = teams.OrderByDescending(x => x.Table.Score).ThenByDescending(x => x.Table.GoalsDifference).ThenByDescending(x => x.Table.MakedGoals);
            
            return TeamOrdered.TakeLast(4).ToList();

        }    
        public List<Match> ShowResultRound()
        {
            var MatchesResult = new List<Match>();

            foreach (var round in Rounds)
            {
                if(round.PlayedRound)
                {
                    MatchesResult.AddRange(round.Matches);
                }
            }

            return MatchesResult;
        }
        public Player GetPlayerById(Guid playerId, Guid teamId)
        {
            var findedTeam = GetTeamById(teamId);

            return findedTeam.Players.First(player => player.Id == playerId);
        }
        public Guid GetPlayerIdByName(string playerName, Guid teamId)
        {
            var findedTeam = GetTeamById(teamId);

            return findedTeam.Players.First(player => player.Name == playerName).Id;
        }
        public Team GetTeamById(Guid teamId)
        {
            return Teams.First(team => team.Id == teamId);
        }
        public Guid GetTeamIdByName(string teamName)
        {
            return Teams.First(team => team.TeamName == teamName).Id;
        }
     }
 }