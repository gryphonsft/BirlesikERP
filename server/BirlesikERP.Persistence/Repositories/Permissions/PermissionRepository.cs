using BirlesikERP.Domain.Entities.Permissions;
using BirlesikERP.Domain.Repositories;
using BirlesikERP.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BirlesikERP.Persistence.Repositories.Permissions;

public class PermissionRepository : Repository<Permission>, IPermissionRepository
{
    private readonly AppDbContext _context;
    public PermissionRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IReadOnlyList<string>> GetPermissionsByRoleIdsAsync(
            IEnumerable<Guid> roleIds)
    {
        return await _context.RolePermissions
            .Where(x => roleIds.Contains(x.RoleId))
            .Select(x => x.Permission.Name)
            .Distinct()
            .ToListAsync();
    }
}