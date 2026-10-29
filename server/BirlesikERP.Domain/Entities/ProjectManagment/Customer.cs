using BirlesikERP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Domain.Entities.ProjectManagment
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string TaxNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public CustomerType Type { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Project> Projects { get; set; } = new List<Project>();

    }
    public enum CustomerType
    {
        Individual,
        Company
    }
}
