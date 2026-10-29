# 5. Repository Layer

## 5.1 Introduction

The Repository layer is responsible for handling database operations.

It separates database access logic from the Service and Menu layers.

## 5.2 Responsibilities

The Repository layer performs operations such as:

- Retrieving records from the database.
- Adding new records.
- Updating existing records.
- Deleting records.
- Saving changes through Entity Framework Core.

## 5.3 Repository Classes

The project contains repository classes for the following modules:

- Employee
- Leave Type
- Leave Request
- Leave Balance

Each repository works with its corresponding model and database set.

## 5.4 Application Flow

```text
Menu
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

## 5.5 Advantages

- Separates database operations from other application logic.
- Makes code easier to maintain.
- Reduces repeated database code.
- Makes the application structure clearer.

## 5.6 Conclusion

The Repository layer provides a structured way to access the database and supports the layered architecture of the Leave Management System.