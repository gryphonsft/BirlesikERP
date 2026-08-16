using BirlesikERP.Domain.Entities.Core.AppRole;

namespace BirlesikERP.Domain.Entities.Permissions
{
    public class AppRolePermission
    {
        public Guid RoleId { get; set; }
        public AppRole Role { get; set; } = null!;
        public int PermissionId { get; set; }
        public Permission Permission { get; set; } = null!;
    }
}
