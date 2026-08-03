using BirlesikERP.Domain.Entities.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Domain.Repositories
{
    public interface IAuditRepository
    {
        Task AddAsync(AuditLog auditLog);
        Task<List<AuditLog>> GetRecentAsync(int count = 10);
        Task<List<AuditLog>> GetByActionAsync(AuditAction action);
    }
}
