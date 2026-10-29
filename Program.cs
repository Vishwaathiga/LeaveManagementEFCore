
using LeaveManagementEFCore.Data;
using LeaveManagementEFCore.Menus;
using LeaveManagementEFCore.Repositories;
using LeaveManagementEFCore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// Database connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        "Server=.\\SQLEXPRESS;Database=LeaveManagementEFCoreDB;Trusted_Connection=True;TrustServerCertificate=True;"));

// Employee Management
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<EmployeeMenu>();

// Leave Type Management
builder.Services.AddScoped<LeaveTypeRepository>();
builder.Services.AddScoped<LeaveTypeService>();
builder.Services.AddScoped<LeaveTypeMenu>();

// Leave Request Management
builder.Services.AddScoped<LeaveRequestRepository>();
builder.Services.AddScoped<LeaveRequestService>();
builder.Services.AddScoped<LeaveRequestMenu>();

// Leave Balance Management
builder.Services.AddScoped<LeaveBalanceRepository>();
builder.Services.AddScoped<LeaveBalanceService>();
builder.Services.AddScoped<LeaveBalanceMenu>();

// Build the application
using var host = builder.Build();

using var scope = host.Services.CreateScope();

// Get Employee Menu
EmployeeMenu employeeMenu =
    scope.ServiceProvider.GetRequiredService<EmployeeMenu>();

// Get Leave Type Menu
LeaveTypeMenu leaveTypeMenu =
    scope.ServiceProvider.GetRequiredService<LeaveTypeMenu>();

// Get Leave Request Menu
LeaveRequestMenu leaveRequestMenu =
    scope.ServiceProvider.GetRequiredService<LeaveRequestMenu>();

// Get Leave Balance Menu
LeaveBalanceMenu leaveBalanceMenu =
    scope.ServiceProvider.GetRequiredService<LeaveBalanceMenu>();

// Main Menu
while (true)
{
    Console.WriteLine("\n===== LEAVE MANAGEMENT SYSTEM =====");
    Console.WriteLine("1. Employee Management");
    Console.WriteLine("2. Leave Type Management");
    Console.WriteLine("3. Leave Request Management");
    Console.WriteLine("4. Leave Balance Management");
    Console.WriteLine("5. Exit");
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
            await leaveRequestMenu.ShowMenuAsync();
            break;

        case "4":
            await leaveBalanceMenu.ShowMenuAsync();
            break;

        case "5":
            return;

        default:
            Console.WriteLine("Invalid choice. Try again.");
            break;
    }
}
