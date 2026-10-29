# 7. Menu and ConsoleHelper

## 7.1 Menu Layer

The Menu layer provides console-based interaction.

Each module has its own menu:

- `EmployeeMenu`
- `LeaveTypeMenu`
- `LeaveRequestMenu`
- `LeaveBalanceMenu`

The menus display options and call the corresponding service methods.

## 7.2 Employee Menu

The Employee menu provides:

1. Add Employee
2. View All Employees
3. View Employee by ID
4. Update Employee
5. Delete Employee
6. Back

## 7.3 Leave Type Menu

The Leave Type menu provides:

1. Add Leave Type
2. View All Leave Types
3. View Leave Type by ID
4. Update Leave Type
5. Delete Leave Type
6. Back

## 7.4 Leave Request Menu

The Leave Request menu provides:

1. Add Leave Request
2. View All Leave Requests
3. View Leave Request by ID
4. Update Leave Request
5. Delete Leave Request
6. Back

## 7.5 Leave Balance Menu

The Leave Balance menu provides:

1. Add Leave Balance
2. View All Leave Balances
3. View Leave Balance by ID
4. Update Leave Balance
5. Delete Leave Balance
6. Back

## 7.6 ConsoleHelper

The `ConsoleHelper` class is located in the Helpers folder.

It contains reusable methods for console input.

### ReadRequiredInput()

```csharp
ConsoleHelper.ReadRequiredInput("Enter employee name: ");
```

This method keeps asking for input until the user enters a non-empty value.

### TryReadId()

```csharp
ConsoleHelper.TryReadId("Enter employee ID: ", out int employeeId);
```

This method checks whether the entered ID is a positive integer.

It returns:

- `true` when the ID is valid.
- `false` when the ID is invalid.

## 7.7 Validation

The menus also perform validation for:

- Numeric values.
- Date input.
- Leave request date order.
- Leave request status.
- Leave balance day values.

## 7.8 Conclusion

The Menu layer handles user interaction, while `ConsoleHelper` provides reusable input methods to reduce repeated code.