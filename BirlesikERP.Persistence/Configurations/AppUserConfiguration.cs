using BirlesikERP.Domain.Entities.Core.AppUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Persistence.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasIndex(x => x.EmployeeId)
              .IsUnique();

            builder.HasOne(u => u.Employee)
                   .WithOne(e => e.AppUser)
                   .HasForeignKey<AppUser>(u => u.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
