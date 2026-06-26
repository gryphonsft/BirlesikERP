using BirlesikERP.Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikERP.Persistence.Configurations.Core
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

            builder.Property(x => x.Description)
            .HasMaxLength(500);

            builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

            builder.HasIndex(x => x.Name)
            .IsUnique();

            builder.HasMany(x => x.Teams)
            .WithOne(x => x.Department)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
              new Department
              {
                  Id = Guid.Parse("0F7F72F2-31E4-4A5B-BE98-91E4B5F7F001"),
                  Name = "Yazılım Geliştirme",
                  Description = "Mobil ve Web uygulamaları geliştirme",
                  IsActive = true
              },
              new Department
              {
                  Id = Guid.Parse("1F7F72F2-31E4-4A5B-BE98-91E4B5F7F002"),
                  Name = "İnsan Kaynakları",
                  Description = "İşe alım ve çalışanlarla ilgili işler",
                  IsActive = true
              }
              );
        }
    }
}
