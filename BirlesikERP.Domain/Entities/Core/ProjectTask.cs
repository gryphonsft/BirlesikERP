using BirlesikERP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Domain.Entities.Core
{
    public class ProjectTask : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        
        public DateTime DueDate { get; set; }

        public Status Status { get; set; }
        public Priority Priority { get; set; }


    }
    public enum Status
    {
        ToDo,
        InProgress,
        Done
    }
    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
