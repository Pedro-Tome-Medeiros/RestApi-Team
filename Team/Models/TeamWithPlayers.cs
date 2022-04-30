using System.Collections.Generic;

namespace TeamProject.Models
{
    public class TeamWithPlayers
    {
        public Team Team { get; set; }

        public IEnumerable<Player> Players { get; set; }

        public TeamWithPlayers(Team team, IEnumerable<Player> players)
        {
            Team = team;
            Players = players;
        }
    }
}
