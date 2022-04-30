using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Models;
using TeamProject.Repositories;

namespace TeamProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController: ControllerBase
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTeamsAync()
        {
            return Ok(await _teamRepository.GetAllTeams());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            return Ok(await _teamRepository.GetTeam(id));
        }

        [HttpGet("{id}/teamwithplayers")]
        public async Task<IActionResult> GetTeam(int id)
        {
            return Ok(await _teamRepository.GetTeam(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] Team team)
        {
            if (team == null)
            {
                return BadRequest(); 
            }

            var created = await _teamRepository.CreateTeam(team);

            return Created("Created", created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam([FromBody] Team team, int id)
        {
            if (team == null)
            {
                return BadRequest();
            }

            await _teamRepository.UpdateTeam(team, id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamRepository.DeleteTeam(id);

            return NoContent();
        }
    }
}
