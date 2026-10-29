using System;
using System.Collections.Generic;
using System.Text;


namespace LeaveManagementEFCore.Models;

public class LeaveBalance
{
    public int LeaveBalanceId { get; set; }

    public int EmployeeId { get; set; }

    public int LeaveTypeId { get; set; }

    public int TotalDays { get; set; }

    public int UsedDays { get; set; }

    public int RemainingDays { get; set; }
}

