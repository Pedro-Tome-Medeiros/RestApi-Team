using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Models;
using TeamProject.Repositories;

namespace TeamProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPlayersAync()
        {
            return Ok(await _playerRepository.GetAllPlayers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer(int id)
        {
            return Ok(await _playerRepository.GetPlayer(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] Player player)
        {
            if (player == null)
            {
                return BadRequest();
            }

            var created = await _playerRepository.CreatePlayer(player);

            return Created("Created", created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer([FromBody] Player player, int id)
        {
            if (player == null)
            {
                return BadRequest();
            }

            await _playerRepository.UpdatePlayer(player, id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            await _playerRepository.DeletePlayer(id);

            return NoContent();
        }
    }
}
