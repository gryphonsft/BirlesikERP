using BirlesikERP.Application.DTOs.Core;
using BirlesikERP.Application.Interfaces.Core;
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

            return Ok(team);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var team = await _teamService.GetByIdAsync(Id);

            return Ok(team);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTeamDto dto)
        {
            await _teamService.CreateAsync(dto);
            return Ok("Takım basariyla eklendi");
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(Guid Id, [FromBody] UpdateTeamDto dto)
        {
            await _teamService.UpdateAsync(Id, dto);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteById(Guid Id)
        {
            await _teamService.DeleteByIdAsync(Id);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await _teamService.DeleteAllAsync();
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> AssignEmployee(AssignEmployeeRequest request)
        {
            await _teamService.AssignEmployee(request);
            return NoContent();
        }
    }
}
