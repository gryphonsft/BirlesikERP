using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.Interfaces.Core
{
    public interface IRoleService
    {
        Task<bool> AssignRole(Guid Id, string roleName);
        Task<bool> CreateRole(string roleName);
    }
}
