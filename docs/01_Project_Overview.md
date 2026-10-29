# 1. Project Overview

## 1.1 Project Name

Leave Management System using Entity Framework Core

## 1.2 Introduction

The Leave Management System is a console-based application developed using C# and Entity Framework Core.

The application is designed to manage employee details, leave categories, leave applications, and leave balances. It stores information in a SQL Server database and allows users to perform CRUD operations through console menus.

The project uses a layered architecture to separate database operations, business logic, and user interaction.

## 1.3 Problem Statement

Managing employee leave information manually can lead to data inconsistency, difficulty in tracking leave requests, and challenges in maintaining leave balances.

A centralized application is required to store employee and leave-related information and provide a structured way to manage these records.

## 1.4 Objectives

The main objectives are:

- To maintain employee details.
- To manage leave categories and maximum leave days.
- To record employee leave requests.
- To maintain employee leave balances.
- To perform CRUD operations using Entity Framework Core.
- To connect the application with SQL Server.
- To organize the application using separate layers.

## 1.5 Scope

The current application includes four modules:

1. Employee Management
2. Leave Type Management
3. Leave Request Management
4. Leave Balance Management

Each module provides options to add, view, update, and delete records.

## 1.6 Current Business Rules

The current implementation includes the following rules:

- New leave requests are initialized with the status `Pending`.
- The application date is initialized using `DateTime.Now`.
- The leave request end date must not be earlier than the start date.
- Leave balance remaining days are calculated as:

```csharp
RemainingDays = TotalDays - UsedDays;
```

- Used leave days must not exceed total leave days.

Automatic leave balance deduction after approval is not part of the documented current implementation.

## 1.7 Conclusion

The project provides a structured way to manage employee leave information using C#, Entity Framework Core, and SQL Server. It demonstrates CRUD operations and separation of responsibilities through a layered architecture.