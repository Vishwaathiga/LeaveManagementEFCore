
using LeaveManagementEFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        "Server=.\\SQLEXPRESS;Database=LeaveManagementEFCoreDB;Trusted_Connection=True;TrustServerCertificate=True;"));

using var host = builder.Build();

await host.RunAsync();
