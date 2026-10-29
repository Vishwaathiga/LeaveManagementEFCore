# 4. Model Explanation

## 4.1 Employee Model

The `Employee` model represents an employee in the organization.

| Property | Data Type | Description |
|---|---|---|
| EmployeeId | int | Employee identifier |
| EmployeeName | string | Employee name |
| Email | string | Employee email address |
| Department | string | Employee department |
| IsActive | bool | Indicates whether the employee is active |

The `IsActive` property defaults to `true`.

## 4.2 LeaveType Model

The `LeaveType` model represents a category of leave.

| Property | Data Type | Description |
|---|---|---|
| LeaveTypeId | int | Leave type identifier |
| LeaveTypeName | string | Name of the leave category |
| MaximumDays | int | Maximum number of leave days |
| IsActive | bool | Indicates whether the leave type is active |

The `IsActive` property defaults to `true`.

## 4.3 LeaveRequest Model

The `LeaveRequest` model represents a leave application submitted by an employee.

| Property | Data Type | Description |
|---|---|---|
| LeaveRequestId | int | Leave request identifier |
| EmployeeId | int | Employee reference |
| LeaveTypeId | int | Leave type reference |
| StartDate | DateTime | Leave starting date |
| EndDate | DateTime | Leave ending date |
| Reason | string | Reason for requesting leave |
| Status | string | Current leave request status |
| AppliedDate | DateTime | Date and time the request was created |

The default status is `Pending`.

The default applied date is `DateTime.Now`.

The status values used in the menu are:

- Pending
- Approved
- Rejected

## 4.4 LeaveBalance Model

The `LeaveBalance` model represents the leave balance of an employee for a particular leave type.

| Property | Data Type | Description |
|---|---|---|
| LeaveBalanceId | int | Leave balance identifier |
| EmployeeId | int | Employee reference |
| LeaveTypeId | int | Leave type reference |
| TotalDays | int | Total allocated leave days |
| UsedDays | int | Number of used leave days |
| RemainingDays | int | Number of remaining leave days |

Remaining days are calculated using:

```csharp
RemainingDays = TotalDays - UsedDays;
```

## 4.5 Conclusion

The model classes define the structure of the data handled by the application. Entity Framework Core uses these classes to map application objects to database records.