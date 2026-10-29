
using LeaveManagementEFCore.Data;
using LeaveManagementEFCore.Menus;
using LeaveManagementEFCore.Repositories;
using LeaveManagementEFCore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        "Server=.\\SQLEXPRESS;Database=LeaveManagementEFCoreDB;Trusted_Connection=True;TrustServerCertificate=True;"));

builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<EmployeeMenu>();

using var host = builder.Build();

using var scope = host.Services.CreateScope();

EmployeeMenu employeeMenu =
    scope.ServiceProvider.GetRequiredService<EmployeeMenu>();

await employeeMenu.ShowMenuAsync();
