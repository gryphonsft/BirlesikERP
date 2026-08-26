namespace BirlesikERP.Application.DTOs.Core
{
    public sealed record UpdateTeamDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}