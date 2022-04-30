using System.Collections.Generic;
using System.Threading.Tasks;
using TeamProject.Models;

namespace TeamProject.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllTeams();

        Task<Team> GetTeam(int id);

        Task<bool> UpdateTeam(Team team, int id);

        Task<Team> CreateTeam(Team team);

        Task<bool> DeleteTeam(int id);

        Task<TeamWithPlayers> GetTeamWithPlayers(int id);
    }
}
