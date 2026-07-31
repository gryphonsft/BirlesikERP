using BirlesikERP.Domain.Common;
using BirlesikERP.Domain.Entities.HumanResources;

namespace BirlesikERP.Domain.Entities.Core
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }


        // Department üzerinden diğer koleksiyonlara ulaşabilmek için.
        public ICollection<Team> Teams { get; set; } = new List<Team>();
        public ICollection<Position> Positions { get; set; } = new List<Position>();
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
