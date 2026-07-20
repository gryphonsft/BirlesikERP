namespace BirlesikERP.Application.DTOs.Core
{
    public sealed record PositionDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DepartmentDto Department { get; set; } = new();
    }
}
