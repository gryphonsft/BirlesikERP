using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.DTOs.Dashboard
{
    public sealed record DashboardDto
    {
        public int EmployeeCount { get; set; }
        public int DepartmentCount { get; set; }
        public int TeamCount { get; set; }
        public int PositionCount { get; set; }
    }
}
