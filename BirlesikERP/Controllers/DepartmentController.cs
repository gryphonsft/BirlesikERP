using BirlesikERP.Application.DTOs.Core;
using BirlesikERP.Application.Interfaces.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirlesikERP.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var department = await _departmentService.GetAllAsync();

            if (department == null)
                return NotFound();

            return Ok(department);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var department = await _departmentService.GetByIdAsync(Id);

            return Ok(department);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTeams(Guid Id)
        {
            var department = await _departmentService.GetTeamsAsync(Id);

            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentDto dto)
        {
            await _departmentService.CreateAsync(dto);
            return Ok("Departman basariyla eklendi");
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(Guid Id,[FromBody]UpdateDepartmentDto dto)
        {
            await _departmentService.UpdateAsync(Id, dto);

            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteById(Guid Id)
        {
            await _departmentService.DeleteByIdAsync(Id);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> Search(string value)
        {
            var result = await _departmentService.SearchAsync(value);

            if (!result.Any())
                return NoContent();

            return Ok(result);
        }
    }
}
