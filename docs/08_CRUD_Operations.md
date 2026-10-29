# 8. CRUD Operations

## 8.1 Introduction

CRUD represents four basic database operations:

- Create
- Read
- Update
- Delete

The Leave Management System provides CRUD operations for all four modules.

## 8.2 Employee Management

### Create
The user enters employee name, email, and department. The employee is saved with active status.

### Read
The user can view all employees or retrieve an employee using the employee ID.

### Update
The user can update employee details. Pressing Enter without entering a new value preserves the existing value.

### Delete
The user enters an employee ID. If the employee exists, the record is deleted.

## 8.3 Leave Type Management

### Create
The user enters the leave type name and maximum number of days.

### Read
The user can view all leave types or retrieve one by ID.

### Update
The user can update the leave type name and maximum days.

### Delete
The user can delete a leave type after checking that it exists.

## 8.4 Leave Request Management

### Create
The user enters:

- Employee ID
- Leave Type ID
- Start Date
- End Date
- Reason

The request is created with `Pending` status.

### Read
The user can view all leave requests or retrieve a request by ID.

### Update
The user can change employee ID, leave type ID, dates, reason, and status.

### Delete
The user can delete a leave request by ID.

## 8.5 Leave Balance Management

### Create
The user enters employee ID, leave type ID, total days, and used days.

Remaining days are calculated as:

```csharp
RemainingDays = TotalDays - UsedDays;
```

### Read
The user can view all leave balances or retrieve a balance by ID.

### Update
The user can update employee ID, leave type ID, total days, and used days.

Remaining days are recalculated after the update.

### Delete
The user can delete a leave balance by ID.

## 8.6 Conclusion

The CRUD operations allow the user to maintain all major records required by the Leave Management System through console menus.