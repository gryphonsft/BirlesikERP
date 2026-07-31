using BirlesikERP.Domain.Entities.HumanResources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BirlesikERP.Persistence.Configurations.Core
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasOne(p => p.Employee)
                    .WithOne(e => e.Person)
                    .HasForeignKey<Person>(p => p.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.FirstName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.LastName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.Phone)
                   .HasMaxLength(20);

            builder.Property(p => p.Email)
                   .HasMaxLength(150);
        }
    }
}
