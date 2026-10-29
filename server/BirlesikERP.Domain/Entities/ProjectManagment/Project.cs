using BirlesikERP.Domain.Common;

namespace BirlesikERP.Domain.Entities.ProjectManagment
{
    public class Project : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime DueDate { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public ICollection<ProjectTask> ProjectTask { get; set; } = new List<ProjectTask>();
    }
}
