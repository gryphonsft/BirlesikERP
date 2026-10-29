namespace BirlesikERP.Application.DTOs.ProjectManagment
{
    public sealed record ProjectDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime DueDate { get; set; }
    }
}
