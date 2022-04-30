using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using TeamProject.Data;
using TeamProject.Models;

namespace TeamProject.Repositories
{
    public class PlayerRepository: IPlayerRepository
    {

        private MysqlConfiguration _connectionString;

        public PlayerRepository(MysqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<Player> CreatePlayer(Player player)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO player(name, age, team_id)
                VALUES (@name, @age, @teamId); SELECT LAST_INSERT_ID()";

            player.Id = await db.QuerySingleAsync<int>(sql, new { player.Name, player.Age, player.TeamId });

            return player;
        }

        public async Task<bool> DeletePlayer(int id)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM player WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new { id });

            return result > 0;

        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM player";

            return await db.QueryAsync<Player>(sql, new { });
        }

        public async Task<Player> GetPlayer(int id)
        {
            var db = dbConnection();

            var sql = @"SELEC * FROM player WHERE id = @id";

            return await db.QueryFirstAsync<Player>(sql, new { id });
        }

        public async Task<bool> UpdatePlayer(Player player, int id)
        {
            var db = dbConnection();

            var sql = @"UPDATE player SET name = @name, age = @age, team_id = @teamId WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new { player.Name, player.Age, player.TeamId, id });

            return result > 0;
        }
    }
}
