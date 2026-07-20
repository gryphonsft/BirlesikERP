using BirlesikERP.Domain.Common;

namespace BirlesikERP.Domain.Entities.HumanResources
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
