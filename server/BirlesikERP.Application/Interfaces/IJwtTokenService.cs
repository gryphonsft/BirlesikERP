using BirlesikERP.Domain.Entities.Core.AppUser;

namespace BirlesikERP.Application.Interfaces
{
    public interface IJwtTokenService
    {
        Task<string> GenerateToken(AppUser user);
    }
}
