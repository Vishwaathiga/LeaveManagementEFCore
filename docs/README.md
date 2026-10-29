# Leave Management System using Entity Framework Core

## Project Overview

The Leave Management System is a console-based application developed using C# and Entity Framework Core. The application helps manage employee information, leave types, leave requests, and employee leave balances.

The system uses SQL Server as its database and follows a layered architecture consisting of Models, Repositories, Services, Menus, Helpers, and a Data layer.

The application allows users to perform Create, Read, Update, and Delete (CRUD) operations through a console-based menu.

## Objectives

- To maintain employee information in a centralized database.
- To manage different types of leave.
- To record and manage employee leave requests.
- To maintain employee leave balances.
- To use Entity Framework Core for database operations.
- To organize the application using a layered architecture.
- To improve code reusability through a shared console helper.

## Technologies Used

| Technology | Purpose |
|---|---|
| C# | Application programming language |
| .NET | Application development platform |
| Entity Framework Core | Object-relational mapping |
| SQL Server | Database management system |
| Visual Studio | Development environment |
| Git | Version control |
| GitHub | Source code repository |

## Features

### 1. Employee Management
- Add employee details.
- View all employees.
- View an employee by ID.
- Update employee details.
- Delete an employee.

### 2. Leave Type Management
- Add leave types.
- View all leave types.
- View a leave type by ID.
- Update leave type details.
- Delete a leave type.

### 3. Leave Request Management
- Create leave requests.
- View all leave requests.
- View a leave request by ID.
- Update leave request details.
- Delete a leave request.
- Maintain request status as Pending, Approved, or Rejected.

### 4. Leave Balance Management
- Add leave balance details.
- View all leave balances.
- View a leave balance by ID.
- Update leave balance details.
- Delete a leave balance.
- Calculate remaining days using Total Days minus Used Days.

## Project Architecture

The application follows a layered architecture.

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

Each layer has a separate responsibility, making the application easier to understand, maintain, and extend.

## Database

Database Name: `LeaveManagementEFCoreDB`

The application manages the following entity sets:

- Employees
- LeaveTypes
- LeaveRequests
- LeaveBalances

## Documentation

Detailed documentation is available in the `Docs` folder.

| Document | Description |
|---|---|
| 01_Project_Overview.md | Project introduction and objectives |
| 02_Project_Structure.md | Explanation of project folders |
| 03_Database_Design.md | Database tables and relationships |
| 04_Model_Explanation.md | Explanation of model classes |
| 05_Repository_Layer.md | Repository layer details |
| 06_Service_Layer.md | Service layer details |
| 07_Menu_and_ConsoleHelper.md | Console menus and helper methods |
| 08_CRUD_Operations.md | CRUD functionality |
| 09_SQL_Queries.md | SQL table creation and insert queries |
| 10_Git_Workflow.md | Git workflow and commits |
| 11_Setup_and_Execution.md | Setup and execution instructions |

## Future Enhancements

- Automatically update leave balances when leave requests are approved.
- Add validation to prevent overlapping leave requests.
- Add employee and administrator login.
- Generate leave reports.
- Add a graphical user interface.
- Add notifications for leave request status changes.

## Conclusion

The Leave Management System demonstrates the use of C#, Entity Framework Core, and SQL Server in developing a console-based application. It provides CRUD functionality for employee details, leave types, leave requests, and leave balances while following a layered application structure.