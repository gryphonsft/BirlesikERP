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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentDto dto)
        {
            await _departmentService.CreateAsync(dto);
            return Ok("Departman basariyla eklendi");
        }
    }
}
