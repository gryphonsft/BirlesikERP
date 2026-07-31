using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.DTOs.User
{
    public sealed record AssignRoleRequest
    {
        public Guid Id { get; set; }
        public string roleName { get; set; } = null!;
    }
}
