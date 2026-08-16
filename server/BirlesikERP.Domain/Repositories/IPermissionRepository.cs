using BirlesikERP.Domain.Entities.Permissions;

namespace BirlesikERP.Domain.Repositories;

public interface IPermissionRepository : IRepository<Permission>
{
    Task<IReadOnlyList<string>> GetPermissionsByRoleIdsAsync(IEnumerable<Guid> roleIds);
}