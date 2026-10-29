using BirlesikERP.Application.DTOs.ProjectManagment;
using BirlesikERP.Application.Interfaces.ProjectManagment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirlesikERP.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectService.GetAllAsync();
            return Ok(projects);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var project = await _projectService.GetByIdAsync(Id);

            return Ok(project);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateProjectDto dto)
        {
            await _projectService.CreateAsync(dto);
            return NoContent();
        }

    }
}
