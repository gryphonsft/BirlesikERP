using BirlesikERP.Application.DTOs.HumanResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.DTOs.Core
{
    public sealed record TeamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;

        public List<EmployeeDto> Employees { get; set; } = new();

    }
}
