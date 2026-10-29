
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

builder.Services.AddScoped<LeaveTypeRepository>();
builder.Services.AddScoped<LeaveTypeService>();
builder.Services.AddScoped<LeaveTypeMenu>();

using var host = builder.Build();

using var scope = host.Services.CreateScope();

EmployeeMenu employeeMenu =
    scope.ServiceProvider.GetRequiredService<EmployeeMenu>();

LeaveTypeMenu leaveTypeMenu =
    scope.ServiceProvider.GetRequiredService<LeaveTypeMenu>();

while (true)
{
    Console.WriteLine("\n===== LEAVE MANAGEMENT SYSTEM =====");
    Console.WriteLine("1. Employee Management");
    Console.WriteLine("2. Leave Type Management");
    Console.WriteLine("3. Exit");
    Console.Write("Enter your choice: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            await employeeMenu.ShowMenuAsync();
            break;

        case "2":
            await leaveTypeMenu.ShowMenuAsync();
            break;

        case "3":
            return;

        default:
            Console.WriteLine("Invalid choice. Try again.");
            break;
    }
}
