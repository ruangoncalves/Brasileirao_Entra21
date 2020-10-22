using System;

namespace Domain
{
    public class Match
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string HomeTeam { get; private set; }
        public string VisitingTeam { get; private set; }
        public int GoalsHomeTeam { get; private set; }
        public int GoalsVisitingTeam { get; private set; }

        public Match(Guid id, string homeTeam, string visitingTeam, int goalsHomeTeam, int goalsVisitingTeam)
        {
            Id = Guid.NewGuid();
            HomeTeam = homeTeam;
            VisitingTeam = visitingTeam;
            GoalsHomeTeam = goalsHomeTeam;
            GoalsVisitingTeam = goalsVisitingTeam;
        }
    }
}

