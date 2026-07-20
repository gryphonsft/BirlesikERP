using BirlesikERP.Domain.Common;
using BirlesikERP.Domain.Entities.HumanResources;

namespace BirlesikERP.Domain.Entities.Core
{
    public class Position : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
