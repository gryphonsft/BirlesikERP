using BirlesikERP.Domain.Entities.Audit;

namespace BirlesikERP.Application.DTOs.Audit
{
    public sealed record RecentActivityDto
    {
        public Guid Id { get; set; }
        public AuditAction Action { get; set; }
        public AuditEntity Entity { get; set; }
        public string? userName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
