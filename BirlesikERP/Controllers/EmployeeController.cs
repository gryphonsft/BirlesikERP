using BirlesikERP.Application.DTOs.HumanResources;
using BirlesikERP.Application.Interfaces.HumanResources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirlesikERP.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employee = await _employeeService.GetAllAsync();

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto dto)
        {
            await _employeeService.CreateAsync(dto);
            return Ok("Kullanici basariyla eklendi.");
        }
    }
}
