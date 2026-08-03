using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Domain.Entities
{
    public class CurrentUser
    {
        public Guid userId { get; set; }
        public string userName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Role { get; set; }
    }
}
