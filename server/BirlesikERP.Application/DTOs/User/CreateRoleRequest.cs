using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.DTOs.User
{
    public sealed record  CreateRoleRequest
    {
        public string roleName { get; set; } = null!;
    }
}
