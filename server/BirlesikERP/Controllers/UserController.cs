using BirlesikERP.Application.Constants;
using BirlesikERP.Application.DTOs.User;
using BirlesikERP.Application.Exceptions;
using BirlesikERP.Application.Interfaces.Core;
using BirlesikERP.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BirlesikERP.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public UserController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleRequest request)
        {
            var role = await _roleService.AssignRole(request.Id, request.roleName);

            if (!role)
                throw new BusinessException("Bir hata oldu.");

            return Ok(role);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            var role = await _roleService.CreateRole(request.roleName);

            if (!role)
                throw new BusinessException("Bir hata oldu.");

            return Ok(role);
        }
    }
}
