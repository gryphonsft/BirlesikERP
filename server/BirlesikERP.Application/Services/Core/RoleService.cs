using BirlesikERP.Application.Exceptions;
using BirlesikERP.Application.Interfaces.Core;
using BirlesikERP.Domain.Entities.Core.AppRole;
using BirlesikERP.Domain.Entities.Core.AppUser;
using Microsoft.AspNetCore.Identity;

namespace BirlesikERP.Application.Services.Core
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public RoleService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> AssignRole(Guid Id,string roleName)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());

            if (user is null)
                throw new NotFoundException("Boyle bir kullanici bulunamadi.");

            if (!await _roleManager.RoleExistsAsync(roleName))
                throw new NotFoundException("Boyle bir rol bulunamadi");

            if (await _userManager.IsInRoleAsync(user,roleName))
                return true;

            var result = await _userManager.AddToRoleAsync(user,roleName);

            return result.Succeeded;
        }
        public async Task<bool> CreateRole(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName))
                return true;

            var result = await _roleManager.CreateAsync(new AppRole
            {
                Name = roleName
            });
            return result.Succeeded;
        }
    }
}
