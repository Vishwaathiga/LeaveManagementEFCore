
using LeaveManagementEFCore.Models;
using LeaveManagementEFCore.Services;

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
            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();

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
        Console.Write("Enter Employee ID: ");
        int employeeId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Leave Type ID: ");
        int leaveTypeId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Start Date (yyyy-MM-dd): ");
        DateTime startDate = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Enter End Date (yyyy-MM-dd): ");
        DateTime endDate = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Enter Reason: ");
        string reason = Console.ReadLine() ?? string.Empty;

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
        Console.Write("Enter Leave Request ID: ");
        int leaveRequestId = Convert.ToInt32(Console.ReadLine());

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
        Console.Write("Enter Leave Request ID to update: ");
        int leaveRequestId = Convert.ToInt32(Console.ReadLine());

        LeaveRequest? leaveRequest =
            await _leaveRequestService.GetLeaveRequestByIdAsync(leaveRequestId);

        if (leaveRequest == null)
        {
            Console.WriteLine("Leave request not found.");
            return;
        }

        Console.Write("Enter new Employee ID: ");
        leaveRequest.EmployeeId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter new Leave Type ID: ");
        leaveRequest.LeaveTypeId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter new Start Date (yyyy-MM-dd): ");
        leaveRequest.StartDate = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Enter new End Date (yyyy-MM-dd): ");
        leaveRequest.EndDate = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Enter new Reason: ");
        leaveRequest.Reason = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter new Status (Pending/Approved/Rejected): ");
        leaveRequest.Status = Console.ReadLine() ?? "Pending";

        await _leaveRequestService.UpdateLeaveRequestAsync(leaveRequest);

        Console.WriteLine("Leave request updated successfully!");
    }

    private async Task DeleteLeaveRequestAsync()
    {
        Console.Write("Enter Leave Request ID to delete: ");
        int leaveRequestId = Convert.ToInt32(Console.ReadLine());

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
