using BirlesikERP.Application.DTOs.Core;
using BirlesikERP.Application.Interfaces.Core;
using Microsoft.AspNetCore.Mvc;

namespace BirlesikERP.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var position = await _positionService.GetAllAsync();

            if (position == null)
                return NotFound();

            return Ok(position);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var position = await _positionService.GetByIdAsync(Id);

            return Ok(position);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePositionDto dto)
        {
            await _positionService.CreateAsync(dto);
            return Ok("Pozisyon basariyla eklendi");
        }
        
    }
}
