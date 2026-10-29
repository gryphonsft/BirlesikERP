namespace BirlesikERP.Application.DTOs.ProjectManagment
{
    public sealed record CustomerDto
    {
        public string Name { get; set; } = string.Empty;
        public string TaxNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public CustomerType Type { get; set; }
        public bool IsActive { get; set; }
    }
    public enum CustomerType
    {
        Individual,
        Company
    }
}
