using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeamProject.Models;

namespace TeamProject.Repositories
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetAllPlayers();

        Task<Player> GetPlayer(int id);

        Task<bool> UpdatePlayer(Player player, int id);

        Task<Player> CreatePlayer(Player player);

        Task<bool> DeletePlayer(int id);
    }
}
