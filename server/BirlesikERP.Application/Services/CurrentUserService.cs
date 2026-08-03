using BirlesikERP.Application.Interfaces;
using BirlesikERP.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BirlesikERP.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CurrentUser GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var userIdClaim = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            if (user == null || user.Identity?.IsAuthenticated != true)
            {
                return new CurrentUser();
            }
            Console.WriteLine($"UserId Claim : {userIdClaim}");
            Console.WriteLine($"UserName Claim : {user.FindFirst(ClaimTypes.Name)?.Value}");
            return new CurrentUser
            {
                userId = Guid.Parse(
                    user.FindFirst(ClaimTypes.NameIdentifier)?.Value
                    ?? Guid.Empty.ToString()),

                userName = user.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty,

                Email =
                    user.FindFirst(ClaimTypes.Email)?.Value
                    ?? string.Empty,

                Role = user.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty
            };
        }
    }
}
