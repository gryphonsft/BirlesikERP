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
        public async Task<IActionResult> Get(int page = 1, int pageSize = 3)
        {
            var employee = await _employeeService.GetAsync(page, pageSize);
            return Ok(employee);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var employee = await _employeeService.GetByIdAsync(Id);

            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto dto)
        {
            await _employeeService.CreateAsync(dto);
            return Ok("Kullanici basariyla eklendi.");
        }
        [HttpGet]
        public async Task<IActionResult> Search(string value)
        {
            var result = await _employeeService.SearchAsync(value);

            if (!result.Any())
                return NoContent();
            return Ok(result);
        }
    }
}
