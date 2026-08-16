using BirlesikERP.Domain.Entities.Audit;
using BirlesikERP.Domain.Entities.Core;
using BirlesikERP.Domain.Entities.Core.AppRole;
using BirlesikERP.Domain.Entities.Core.AppUser;
using BirlesikERP.Domain.Entities.HumanResources;
using BirlesikERP.Domain.Entities.Permissions;
using BirlesikERP.Domain.Entities.ProjectManagment;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BirlesikERP.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectTask> ProjectTask { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<AuditLog> AuditLog { get; set; }

        public DbSet<Permission> Permission { get; set; }
        public DbSet<AppRolePermission> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
