using BirlesikERP.Domain.Common;
using BirlesikERP.Domain.Entities.Core;
using BirlesikERP.Domain.Entities.Core.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Domain.Entities.HumanResources
{
    public class Employee : BaseEntity
    {
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public Guid TeamId { get; set; }
        public Team Team { get; set; } = null!;
    }
}
