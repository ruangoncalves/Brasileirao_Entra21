using System;

namespace Domain
{
    public class Match
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Team HomeTeam { get; private set; }
        public Team VisitingTeam { get; private set; }
        public int GoalsHomeTeam { get; private set; }
        public int GoalsVisitingTeam { get; private set; }

        public void AddHomeTeamToMatch(Team homeTeam)
        {
            HomeTeam = homeTeam;
        }

        public void AddVisitingTeamToMatch(Team visitingTeam)
        {
            VisitingTeam = visitingTeam;
        }
        public void ScoreGoalsHomeTeam(int goal)
        {
            GoalsHomeTeam = goal;
        }

        public void ScoreGoalsVisitingTeam(int goal)
        {
            GoalsVisitingTeam = goal;
        }
    }
}

