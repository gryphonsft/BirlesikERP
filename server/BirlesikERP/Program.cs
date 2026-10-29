using BirlesikERP.Application.Interfaces;
using BirlesikERP.Application.Interfaces.Audit;
using BirlesikERP.Application.Interfaces.Core;
using BirlesikERP.Application.Interfaces.Dashboard;
using BirlesikERP.Application.Interfaces.HumanResources;
using BirlesikERP.Application.Interfaces.ProjectManagment;
using BirlesikERP.Application.Interfaces.UnitOfWork;
using BirlesikERP.Application.Mappings;
using BirlesikERP.Application.Services;
using BirlesikERP.Application.Services.Audit;
using BirlesikERP.Application.Services.Core;
using BirlesikERP.Application.Services.Dashboard;
using BirlesikERP.Application.Services.HumanResources;
using BirlesikERP.Application.Services.ProjectManagment;
using BirlesikERP.Authorization;
using BirlesikERP.Domain.Entities.Core.AppRole;
using BirlesikERP.Domain.Entities.Core.AppUser;
using BirlesikERP.Domain.Repositories;
using BirlesikERP.Extensions;
using BirlesikERP.Infrastructure.Security;
using BirlesikERP.Persistence.Context;
using BirlesikERP.Persistence.Repositories;
using BirlesikERP.Persistence.Repositories.Audit;
using BirlesikERP.Persistence.Repositories.Core;
using BirlesikERP.Persistence.Repositories.HumanResources;
using BirlesikERP.Persistence.Repositories.Permissions;
using BirlesikERP.Persistence.Repositories.ProjectManagment;
using BirlesikERP.Persistence.Seed;
using BirlesikERP.Persistence.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region Serilog


//Log.Logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(builder.Configuration)
//    .WriteTo.MSSqlServer(
//        connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
//        sinkOptions: new MSSqlServerSinkOptions
//        {
//            TableName = "Logs",
//            AutoCreateSqlTable = true
//        })
//    .CreateLogger();

//builder.Host.UseSerilog();

#endregion
#region Database

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        connectionString,
        sql =>
        {
            sql.MigrationsAssembly("BirlesikERP.Persistence");
        });
});
#endregion

#region Http Context

builder.Services.AddHttpContextAccessor();

#endregion

#region Identity

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

#endregion

#region Jwt Settings

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("Jwt"));

var jwtSettings =
    builder.Configuration
           .GetSection("Jwt")
           .Get<JwtSettings>()
    ?? throw new InvalidOperationException("Jwt configuration not found.");

#endregion

#region Authentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme =
        JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,

            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Key))
        };
});

builder.Services.AddAuthorization();

#endregion

#region Dependency Injection

builder.Services.AddAutoMapper(cfg =>
{
    cfg.LicenseKey = builder.Configuration["AutoMapper:LisansAnahtari"];
}, typeof(MappingProfile).Assembly);

builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
builder.Services.AddScoped(typeof(IRepository<>),
                           typeof(Repository<>));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IAuditRepository, AuditRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IAuditService, AuditService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


#endregion

#region Cors

builder.Services.AddCors(options =>
{
    options.AddPolicy("Vue", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

#endregion

#region Controllers

builder.Services
    .AddControllers()
    .AddNewtonsoftJson();

#endregion


#region OpenApi

builder.Services.AddOpenApi();

#endregion

var app = builder.Build();

#region SeedData
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AppDbContext>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();

    await DatabaseSeeder.SeedAsync(
        context,
        roleManager);
}
#endregion
#region Middleware Pipeline

app.MapOpenApi();

app.MapScalarApiReference();

app.UseHttpsRedirection();

app.UseGlobalExceptionMiddleware();

app.UseCors("Vue");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();
