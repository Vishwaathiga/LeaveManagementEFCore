
using LeaveManagementEFCore.Models;
using LeaveManagementEFCore.Services;
using LeaveManagementEFCore.Helpers;

namespace LeaveManagementEFCore.Menus;

public class LeaveRequestMenu
{
    private readonly LeaveRequestService _leaveRequestService;

    public LeaveRequestMenu(LeaveRequestService leaveRequestService)
    {
        _leaveRequestService = leaveRequestService;
    }

    public async Task ShowMenuAsync()
    {
        while (true)
        {
            Console.WriteLine("\n===== LEAVE REQUEST MANAGEMENT =====");
            Console.WriteLine("1. Add Leave Request");
            Console.WriteLine("2. View All Leave Requests");
            Console.WriteLine("3. View Leave Request By ID");
            Console.WriteLine("4. Update Leave Request");
            Console.WriteLine("5. Delete Leave Request");
            Console.WriteLine("6. Back");

            string choice = ConsoleHelper.ReadRequiredInput("Enter your choice: ");

            switch (choice)
            {
                case "1":
                    await AddLeaveRequestAsync();
                    break;

                case "2":
                    await ViewAllLeaveRequestsAsync();
                    break;

                case "3":
                    await ViewLeaveRequestByIdAsync();
                    break;

                case "4":
                    await UpdateLeaveRequestAsync();
                    break;

                case "5":
                    await DeleteLeaveRequestAsync();
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private async Task AddLeaveRequestAsync()
    {
        if (!ConsoleHelper.TryReadId("Enter Employee ID: ", out int employeeId))
        {
            return;
        }

        if (!ConsoleHelper.TryReadId("Enter Leave Type ID: ", out int leaveTypeId))
        {
            return;
        }

        Console.Write("Enter Start Date (yyyy-MM-dd): ");

        if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
        {
            Console.WriteLine("Invalid start date.");
            return;
        }

        Console.Write("Enter End Date (yyyy-MM-dd): ");

        if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
        {
            Console.WriteLine("Invalid end date.");
            return;
        }

        string reason = ConsoleHelper.ReadRequiredInput("Enter Reason: ");

        if (endDate.Date < startDate.Date)
        {
            Console.WriteLine("End date cannot be earlier than start date.");
            return;
        }

        LeaveRequest leaveRequest = new LeaveRequest
        {
            EmployeeId = employeeId,
            LeaveTypeId = leaveTypeId,
            StartDate = startDate,
            EndDate = endDate,
            Reason = reason,
            Status = "Pending",
            AppliedDate = DateTime.Now
        };

        await _leaveRequestService.AddLeaveRequestAsync(leaveRequest);

        Console.WriteLine("Leave request added successfully!");
    }

    private async Task ViewAllLeaveRequestsAsync()
    {
        List<LeaveRequest> leaveRequests =
            await _leaveRequestService.GetAllLeaveRequestsAsync();

        if (leaveRequests.Count == 0)
        {
            Console.WriteLine("No leave requests found.");
            return;
        }

        foreach (LeaveRequest leaveRequest in leaveRequests)
        {
            DisplayLeaveRequest(leaveRequest);
        }
    }

    private async Task ViewLeaveRequestByIdAsync()
    {
        if (!ConsoleHelper.TryReadId("Enter Leave Request ID: ", out int leaveRequestId))
        {
            return;
        }

        LeaveRequest? leaveRequest =
            await _leaveRequestService.GetLeaveRequestByIdAsync(leaveRequestId);

        if (leaveRequest == null)
        {
            Console.WriteLine("Leave request not found.");
            return;
        }

        DisplayLeaveRequest(leaveRequest);
    }

    private async Task UpdateLeaveRequestAsync()
    {
        if (!ConsoleHelper.TryReadId("Enter Leave Request ID to update: ", out int leaveRequestId))
        {
            return;
        }

        LeaveRequest? leaveRequest =
            await _leaveRequestService.GetLeaveRequestByIdAsync(leaveRequestId);

        if (leaveRequest == null)
        {
            Console.WriteLine("Leave request not found.");
            return;
        }

        if (!ConsoleHelper.TryReadId("Enter new Employee ID: ", out int employeeId))
        {
            return;
        }

        if (!ConsoleHelper.TryReadId("Enter new Leave Type ID: ", out int leaveTypeId))
        {
            return;
        }

        Console.Write("Enter new Start Date (yyyy-MM-dd): ");

        if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
        {
            Console.WriteLine("Invalid start date.");
            return;
        }

        Console.Write("Enter new End Date (yyyy-MM-dd): ");

        if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
        {
            Console.WriteLine("Invalid end date.");
            return;
        }

        if (endDate.Date < startDate.Date)
        {
            Console.WriteLine("End date cannot be earlier than start date.");
            return;
        }

        string reason = ConsoleHelper.ReadRequiredInput("Enter new Reason: ");
        string status = ConsoleHelper.ReadRequiredInput("Enter new Status (Pending/Approved/Rejected): ");

        if (status != "Pending" && status != "Approved" && status != "Rejected")
        {
            Console.WriteLine("Invalid status.");
            return;
        }

        leaveRequest.EmployeeId = employeeId;
        leaveRequest.LeaveTypeId = leaveTypeId;
        leaveRequest.StartDate = startDate;
        leaveRequest.EndDate = endDate;
        leaveRequest.Reason = reason;
        leaveRequest.Status = status;

        await _leaveRequestService.UpdateLeaveRequestAsync(leaveRequest);

        Console.WriteLine("Leave request updated successfully!");
    }

    private async Task DeleteLeaveRequestAsync()
    {
        if (!ConsoleHelper.TryReadId("Enter Leave Request ID to delete: ", out int leaveRequestId))
        {
            return;
        }

        LeaveRequest? leaveRequest =
            await _leaveRequestService.GetLeaveRequestByIdAsync(leaveRequestId);

        if (leaveRequest == null)
        {
            Console.WriteLine("Leave request not found.");
            return;
        }

        await _leaveRequestService.DeleteLeaveRequestAsync(leaveRequestId);

        Console.WriteLine("Leave request deleted successfully!");
    }

    private void DisplayLeaveRequest(LeaveRequest leaveRequest)
    {
        Console.WriteLine("\n------------------------------");
        Console.WriteLine($"Leave Request ID : {leaveRequest.LeaveRequestId}");
        Console.WriteLine($"Employee ID      : {leaveRequest.EmployeeId}");
        Console.WriteLine($"Leave Type ID    : {leaveRequest.LeaveTypeId}");
        Console.WriteLine($"Start Date       : {leaveRequest.StartDate:yyyy-MM-dd}");
        Console.WriteLine($"End Date         : {leaveRequest.EndDate:yyyy-MM-dd}");
        Console.WriteLine($"Reason           : {leaveRequest.Reason}");
        Console.WriteLine($"Status           : {leaveRequest.Status}");
        Console.WriteLine($"Applied Date     : {leaveRequest.AppliedDate:yyyy-MM-dd}");
        Console.WriteLine("------------------------------");
    }
}
