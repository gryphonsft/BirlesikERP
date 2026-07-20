using BirlesikERP.Application.DTOs.Core;
using BirlesikERP.Application.Interfaces.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirlesikERP.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var team = await _teamService.GetAllAsync();

            if (team == null)
                return NotFound();

            return Ok(team);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTeamDto dto)
        {
            await _teamService.CreateAsync(dto);
            return Ok("Takım basariyla eklendi");
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteById(Guid Id)
        {
            await _teamService.DeleteByIdAsync(Id);
            return NoContent();
        }
    }
}
