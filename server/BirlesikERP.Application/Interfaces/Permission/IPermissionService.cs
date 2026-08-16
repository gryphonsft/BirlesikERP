using BirlesikERP.Domain.Entities.Core.AppUser;

namespace BirlesikERP.Application.Interfaces.Permission;

public interface IPermissionService
{
    Task<IReadOnlyList<string>> GetUserPermissionsAsync(AppUser user);
}