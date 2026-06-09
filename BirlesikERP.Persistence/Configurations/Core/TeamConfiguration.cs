using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BirlesikERP.Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BirlesikERP.Persistence.Configurations.Core
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

            builder.Property(x => x.Description)
            .HasMaxLength(500);

            builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

            builder.HasIndex(x => new { x.DepartmentId, x.Name })
            .IsUnique();

            builder.HasOne(x => x.Department)
            .WithMany(x => x.Teams)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Employees)
            .WithOne(x => x.Team)
            .HasForeignKey(x => x.TeamId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
