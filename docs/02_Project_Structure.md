# 2. Project Structure

## 2.1 Overview

The Leave Management System is organized into separate folders based on functionality.

The project uses Models, Data, Repositories, Services, Menus, and Helpers.

## 2.2 Project Folder Structure

```text
LeaveManagementEFCore/
│
├── Data/
│   └── AppDbContext.cs
│
├── Models/
│   ├── Employee.cs
│   ├── LeaveType.cs
│   ├── LeaveRequest.cs
│   └── LeaveBalance.cs
│
├── Repositories/
│   ├── EmployeeRepository.cs
│   ├── LeaveTypeRepository.cs
│   ├── LeaveRequestRepository.cs
│   └── LeaveBalanceRepository.cs
│
├── Services/
│   ├── EmployeeService.cs
│   ├── LeaveTypeService.cs
│   ├── LeaveRequestService.cs
│   └── LeaveBalanceService.cs
│
├── Menus/
│   ├── EmployeeMenu.cs
│   ├── LeaveTypeMenu.cs
│   ├── LeaveRequestMenu.cs
│   └── LeaveBalanceMenu.cs
│
├── Helpers/
│   └── ConsoleHelper.cs
│
├── Program.cs
└── Docs/
    └── Project Documentation
```

The repository and service filenames shown above should match the corresponding files in the actual solution.

## 2.3 Folder Responsibilities

### Data

The Data folder contains `AppDbContext.cs`.

It is responsible for connecting the entity classes with the database through Entity Framework Core.

### Models

The Models folder contains the entity classes used by the application.

Each model represents a type of record stored in the database.

### Repositories

The Repositories folder contains classes responsible for database operations.

Repositories communicate with `AppDbContext` to retrieve, add, update, and delete records.

### Services

The Services folder contains application service classes.

Services are called by menus and use repositories to perform the required operations.

### Menus

The Menus folder contains console menu classes.

Each menu displays options for its module and calls the corresponding service methods.

### Helpers

The Helpers folder contains the shared `ConsoleHelper` class.

It provides reusable methods for required text input and ID validation.

### Program.cs

The `Program.cs` file configures the application and starts the main menu.

## 2.4 Application Flow

```text
Program.cs
    |
    v
Main Menu
    |
    v
Module Menu
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

This structure separates responsibilities and makes the application easier to maintain.