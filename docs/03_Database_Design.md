# 3. Database Design

## 3.1 Database Details

Database Name: `LeaveManagementEFCoreDB`

Database Management System: SQL Server

The application uses Entity Framework Core to communicate with SQL Server.

## 3.2 Entity Sets

The `AppDbContext` class contains the following DbSet properties:

```csharp
public DbSet<Employee> Employees { get; set; }

public DbSet<LeaveType> LeaveTypes { get; set; }

public DbSet<LeaveRequest> LeaveRequests { get; set; }

public DbSet<LeaveBalance> LeaveBalances { get; set; }
```

These properties represent the entity sets managed by Entity Framework Core.

## 3.3 Employees Table

Stores employee information.

| Column | Description |
|---|---|
| EmployeeId | Employee identifier |
| EmployeeName | Employee name |
| Email | Employee email |
| Department | Department name |
| IsActive | Employee active status |

## 3.4 LeaveTypes Table

Stores leave category information.

| Column | Description |
|---|---|
| LeaveTypeId | Leave type identifier |
| LeaveTypeName | Leave category name |
| MaximumDays | Maximum leave days |
| IsActive | Leave type active status |

## 3.5 LeaveRequests Table

Stores employee leave applications.

| Column | Description |
|---|---|
| LeaveRequestId | Leave request identifier |
| EmployeeId | Employee reference |
| LeaveTypeId | Leave category reference |
| StartDate | Leave starting date |
| EndDate | Leave ending date |
| Reason | Reason for leave |
| Status | Leave request status |
| AppliedDate | Date the request was applied |

## 3.6 LeaveBalances Table

Stores employee leave balance information.

| Column | Description |
|---|---|
| LeaveBalanceId | Leave balance identifier |
| EmployeeId | Employee reference |
| LeaveTypeId | Leave category reference |
| TotalDays | Total allocated leave days |
| UsedDays | Used leave days |
| RemainingDays | Remaining leave days |

## 3.7 Logical Relationships

The ID properties indicate these logical relationships:

- `LeaveRequest.EmployeeId` refers to an employee.
- `LeaveRequest.LeaveTypeId` refers to a leave type.
- `LeaveBalance.EmployeeId` refers to an employee.
- `LeaveBalance.LeaveTypeId` refers to a leave type.

The exact foreign-key configuration should be verified from the EF Core model configuration or database migrations.

## 3.8 Conclusion

The database contains four main entity sets. Each entity set stores a specific category of information required by the Leave Management System.