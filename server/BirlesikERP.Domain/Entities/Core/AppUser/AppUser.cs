using BirlesikERP.Domain.Entities.HumanResources;
using Microsoft.AspNetCore.Identity;

namespace BirlesikERP.Domain.Entities.Core.AppUser
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
