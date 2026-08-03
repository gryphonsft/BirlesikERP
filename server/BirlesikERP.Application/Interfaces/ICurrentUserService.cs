using BirlesikERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.Interfaces
{
    public interface ICurrentUserService
    {
        CurrentUser GetCurrentUser();
    }
}
