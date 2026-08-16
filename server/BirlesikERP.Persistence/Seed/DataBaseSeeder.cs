using BirlesikERP.Application.Constants;
using BirlesikERP.Domain.Entities.Core.AppRole;
using BirlesikERP.Domain.Entities.Permissions;
using BirlesikERP.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BirlesikERP.Persistence.Seed;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(
        AppDbContext context,
        RoleManager<AppRole> roleManager)
    {
        await context.Database.MigrateAsync();

        var roles = new[]
        {
            "Admin",
            "HR",
            "Employee"
        };

        foreach (var roleName in roles)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(
                    new AppRole
                    {
                        Name = roleName
                    });
            }
        }

        var permissions = new[]
        {
            PermissionConstants.EmployeeView,
            PermissionConstants.EmployeeCreate,
            PermissionConstants.EmployeeUpdate,
            PermissionConstants.EmployeeDelete,

            PermissionConstants.DepartmentView,
            PermissionConstants.DepartmentCreate,
            PermissionConstants.DepartmentUpdate,
            PermissionConstants.DepartmentDelete,

            PermissionConstants.TeamView,
            PermissionConstants.TeamCreate,
            PermissionConstants.TeamUpdate,
            PermissionConstants.TeamDelete,

            PermissionConstants.ProjectView,
            PermissionConstants.ProjectCreate,
            PermissionConstants.ProjectUpdate,
            PermissionConstants.ProjectDelete
        };

        foreach (var permissionName in permissions)
        {
            if (!await context.Permission
                    .AnyAsync(x => x.Name == permissionName))
            {
                context.Permission.Add(
                    new Permission
                    {
                        Name = permissionName
                    });
            }
        }

        await context.SaveChangesAsync();

        // =========================
        // 3. ROLE PERMISSIONS
        // =========================

        var adminRole = await roleManager.FindByNameAsync("Admin");
        var hrRole = await roleManager.FindByNameAsync("HR");
        var employeeRole = await roleManager.FindByNameAsync("Employee");

        if (adminRole == null ||
            hrRole == null ||
            employeeRole == null)
        {
            throw new Exception("Seed rolleri oluşturulamadı.");
        }

        // Admin → bütün permission'lar
        await AddPermissionsToRole(
            context,
            adminRole.Id,
            permissions);

        // HR
        await AddPermissionsToRole(
            context,
            hrRole.Id,
            new[]
            {
                PermissionConstants.EmployeeView,
                PermissionConstants.EmployeeCreate,
                PermissionConstants.EmployeeUpdate,

                PermissionConstants.DepartmentView,
                PermissionConstants.DepartmentCreate,
                PermissionConstants.DepartmentUpdate,

                PermissionConstants.TeamView,
                PermissionConstants.TeamCreate,
                PermissionConstants.TeamUpdate
            });

        // Employee
        await AddPermissionsToRole(
            context,
            employeeRole.Id,
            new[]
            {
                PermissionConstants.EmployeeView,
                PermissionConstants.ProjectView
            });

        await context.SaveChangesAsync();
    }

    private static async Task AddPermissionsToRole(
        AppDbContext context,
        Guid roleId,
        IEnumerable<string> permissionNames)
    {
        var permissions = await context.Permission
            .Where(x => permissionNames.Contains(x.Name))
            .ToListAsync();

        foreach (var permission in permissions)
        {
            var exists = await context.RolePermissions
                .AnyAsync(x =>
                    x.RoleId == roleId &&
                    x.PermissionId == permission.Id);

            if (!exists)
            {
                context.RolePermissions.Add(
                    new AppRolePermission
                    {
                        RoleId = roleId,
                        PermissionId = permission.Id
                    });
            }
        }
    }
}