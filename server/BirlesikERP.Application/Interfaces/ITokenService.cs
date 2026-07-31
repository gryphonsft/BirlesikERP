using BirlesikERP.Domain.Entities.Core.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(AppUser user);
    }
}
