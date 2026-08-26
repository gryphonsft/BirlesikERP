using BirlesikERP.Application.DTOs.HumanResources;
using BirlesikERP.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.DTOs.Core
{
    public sealed record TeamListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public Guid DepartmentId { get; set; }
        public DepartmentSummaryDto? Department { get; set; }
        public List<EmployeeSummaryDto> Employees { get; set; } = new();
        public DateTime CreatedAt { get; set; }
    }
}
