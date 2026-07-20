using BirlesikERP.Domain.Common;
using BirlesikERP.Domain.Entities.Core;
using BirlesikERP.Domain.Entities.Core.AppUser;

namespace BirlesikERP.Domain.Entities.HumanResources
{
    public class Employee : BaseEntity
    {
        public bool IsActive { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public Guid? TeamId { get; set; }
        public Team? Team { get; set; } 

        public Guid PositionId {  get; set; }
        public Position Position { get; set;  } = null!;

        public AppUser? AppUser { get; set; }
        public Person Person { get; set; } = null!;
    }
}
