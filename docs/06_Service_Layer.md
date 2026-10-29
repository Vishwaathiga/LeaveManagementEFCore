# 6. Service Layer

## 6.1 Introduction

The Service layer contains application operations used by the console menus.

It receives requests from the Menu layer and calls the corresponding Repository methods.

## 6.2 Responsibilities

The Service layer:

- Provides operations to the menus.
- Calls repository methods.
- Returns data to the menus.
- Coordinates application operations.
- Contains business rules implemented in the project.

## 6.3 Service Classes

The project includes service classes for:

- Employee Management
- Leave Type Management
- Leave Request Management
- Leave Balance Management

## 6.4 Example Service Operations

The Employee menu uses service methods such as:

```csharp
AddEmployeeAsync()
GetAllEmployeesAsync()
GetEmployeeByIdAsync()
UpdateEmployeeAsync()
DeleteEmployeeAsync()
```

The other modules follow a similar CRUD pattern.

## 6.5 Application Flow

```text
Console Menu
     |
     v
   Service
     |
     v
 Repository
     |
     v
 AppDbContext
     |
     v
 SQL Server
```

## 6.6 Conclusion

The Service layer connects the Menu layer with the Repository layer and helps keep the application organized.