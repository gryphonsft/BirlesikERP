namespace BirlesikERP.Application.DTOs.ProjectManagment
{
    public sealed record  CreateProjectDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime DueDate { get; set; }
        public Guid CustomerId { get; set; }
    }
}
