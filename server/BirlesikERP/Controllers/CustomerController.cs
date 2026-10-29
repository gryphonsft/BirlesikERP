using BirlesikERP.Application.DTOs.ProjectManagment;
using BirlesikERP.Application.Interfaces.ProjectManagment;
using Microsoft.AspNetCore.Mvc;

namespace BirlesikERP.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetAllAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto dto)
        {
            await _customerService.CreateAsync(dto);
            return Ok("Customer basariyla eklendi");
        }
    }
}
