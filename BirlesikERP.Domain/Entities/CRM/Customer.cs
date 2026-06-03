using BirlesikERP.Domain.Common;
using BirlesikERP.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Domain.Entities.CRM
{
    public class Customer : BaseEntity
    {
        public string CompanyName { get; set; } = string.Empty;

        public ICollection<Project> Projects = new List<Project>();
    }
}
