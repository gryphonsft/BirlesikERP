using BirlesikERP.Domain.Entities.Permissions;
using Microsoft.AspNetCore.Identity;

namespace BirlesikERP.Domain.Entities.Core.AppRole
{
    public class AppRole : IdentityRole<Guid>
    {
        public ICollection<AppRolePermission> RolePermissions { get; set; } = new List<AppRolePermission>();
    }
}
