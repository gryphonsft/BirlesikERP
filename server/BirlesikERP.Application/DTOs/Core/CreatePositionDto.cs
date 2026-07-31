using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.DTOs.Core
{
    public sealed record CreatePositionDto
    {
        public string Name { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
    }
}
