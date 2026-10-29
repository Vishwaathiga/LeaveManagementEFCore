# 11. Setup and Execution

## 11.1 Requirements

The following software is required:

- Visual Studio
- .NET SDK matching the project's target framework
- SQL Server Express
- SQL Server Management Studio (SSMS)
- Entity Framework Core SQL Server provider

## 11.2 SQL Server Configuration

The project uses SQL Server Express.

The server instance used in the project context is:

```text
.\SQLEXPRESS
```

The database name is:

```text
LeaveManagementEFCoreDB
```

The connection string must be configured in the application's configuration or service registration.

## 11.3 AppDbContext

The `AppDbContext` class is located in the Data folder.

```csharp
using LeaveManagementEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementEFCore.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<LeaveType> LeaveTypes { get; set; }

    public DbSet<LeaveRequest> LeaveRequests { get; set; }

    public DbSet<LeaveBalance> LeaveBalances { get; set; }
}
```

The context receives its configuration through `DbContextOptions<AppDbContext>`.

## 11.4 Running the Application

1. Open the solution in Visual Studio.
2. Verify the SQL Server connection string.
3. Ensure SQL Server Express is running.
4. Build the solution.
5. Run the console application.
6. Select a module from the main menu.
7. Choose the required CRUD operation.

## 11.5 Database Migrations

If the project uses EF Core migrations, apply the migrations that already exist in the project to the configured database.

Do not create a new migration unless the model or database schema has changed.

## 11.6 Conclusion

The application can be executed through Visual Studio after configuring the SQL Server connection and ensuring that the database schema is available.