using BirlesikERP.Domain.Entities.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Application.Interfaces.Audit
{
    public interface IAuditService
    {
        Task LogAsync(
        AuditAction action,
        AuditEntity entity,
        Guid? entityId,
        string description,
        string? departmentName = null);
    }
}
