using BirlesikERP.Application.Interfaces;
using BirlesikERP.Domain.Entities.Core.AppRole;
using BirlesikERP.Domain.Entities.Core.AppUser;
using BirlesikERP.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BirlesikERP.Infrastructure.Security
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IPermissionRepository _permissionRepository;

        public JwtTokenService(
        IOptions<JwtSettings> jwtSettings,
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager,
        IPermissionRepository permissionRepository)
        {
            _jwtSettings = jwtSettings.Value;
            _userManager = userManager;
            _roleManager = roleManager;
            _permissionRepository = permissionRepository;
        }

        public async Task<string> GenerateToken(AppUser user)
        {
            var roleNames = await _userManager.GetRolesAsync(user);

            var roleIds = new List<Guid>();

            foreach (var roleName in roleNames)
            {
                var role = await _roleManager.FindByNameAsync(roleName);

                if (role != null)
                {
                    roleIds.Add(role.Id);
                }
            }

            var permissions =
                await _permissionRepository
                    .GetPermissionsByRoleIdsAsync(roleIds);

            var claims = new List<Claim>
    {
        new Claim(
            ClaimTypes.NameIdentifier,
            user.Id.ToString()),

        new Claim(
            ClaimTypes.Name,
            user.FullName),

        new Claim(
            ClaimTypes.Email,
            user.Email!)
    };

            foreach (var role in roleNames)
            {
                claims.Add(
                    new Claim(
                        ClaimTypes.Role,
                        role));
            }

            foreach (var permission in permissions)
            {
                claims.Add(
                    new Claim(
                        "permission",
                        permission));
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    _jwtSettings.ExpireMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}
