namespace BirlesikERP.Domain.Entities.Audit;

public class AuditLog
{
    public Guid Id { get; set; }
    public AuditAction Action { get; set; }
    public AuditEntity Entity { get; set; }
    public Guid? entityId { get; set; }
    public Guid? userId { get; set; }
    public string? userName { get; set; } 
    public string? Description { get; set; } 
    public string? DepartmentName { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}
public enum AuditAction
{
    Create,
    Update,
    Delete,
    Login,
    Logout,
    Approve,
    Reject
}
public enum AuditEntity
{
    Employee,
    Department,
    Team,
    Position,
    Role,
    User
}
