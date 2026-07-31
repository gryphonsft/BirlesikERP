namespace BirlesikERP.Application.DTOs.HumanResources
{
    public sealed record CreateEmployeeDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }

        public Guid DepartmentId { get; set; }
        public Guid TeamId { get; set; }
        public Guid PositionId { get; set; }
    }
}
