using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.DTOs.HumanResources
{
    public sealed record UpdateEmployeeDto
    {
        public bool IsActive { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
