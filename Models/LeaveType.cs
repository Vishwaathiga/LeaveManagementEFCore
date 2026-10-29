using System;
using System.Collections.Generic;
using System.Text;


namespace LeaveManagementEFCore.Models;

public class LeaveType
{
    public int LeaveTypeId { get; set; }

    public string LeaveTypeName { get; set; } = string.Empty;

    public int MaximumDays { get; set; }

    public bool IsActive { get; set; } = true;
}
