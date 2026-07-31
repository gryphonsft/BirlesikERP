using BirlesikERP.Application.DTOs.Auth;
using BirlesikERP.Application.Interfaces.Core;
using BirlesikERP.Application.Services.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirlesikERP.Controller
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (result == null)
                return Unauthorized();

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);

             if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
