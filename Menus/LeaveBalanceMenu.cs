
using LeaveManagementEFCore.Models;
using LeaveManagementEFCore.Services;
using LeaveManagementEFCore.Helpers;

namespace LeaveManagementEFCore.Menus;

public class LeaveBalanceMenu
{
    private readonly LeaveBalanceService _leaveBalanceService;

    public LeaveBalanceMenu(LeaveBalanceService leaveBalanceService)
    {
        _leaveBalanceService = leaveBalanceService;
    }

    public async Task ShowMenuAsync()
    {
        while (true)
        {
            Console.WriteLine("\n===== LEAVE BALANCE MANAGEMENT =====");
            Console.WriteLine("1. Add Leave Balance");
            Console.WriteLine("2. View All Leave Balances");
            Console.WriteLine("3. View Leave Balance By ID");
            Console.WriteLine("4. Update Leave Balance");
            Console.WriteLine("5. Delete Leave Balance");
            Console.WriteLine("6. Back");

            string choice = ConsoleHelper.ReadRequiredInput("Enter your choice: ");

            switch (choice)
            {
                case "1":
                    await AddLeaveBalanceAsync();
                    break;

                case "2":
                    await ViewAllLeaveBalancesAsync();
                    break;

                case "3":
                    await ViewLeaveBalanceByIdAsync();
                    break;

                case "4":
                    await UpdateLeaveBalanceAsync();
                    break;

                case "5":
                    await DeleteLeaveBalanceAsync();
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private async Task AddLeaveBalanceAsync()
    {
        if (!ConsoleHelper.TryReadId("Enter Employee ID: ", out int employeeId))
        {
            return;
        }

        if (!ConsoleHelper.TryReadId("Enter Leave Type ID: ", out int leaveTypeId))
        {
            return;
        }

        Console.Write("Enter Total Days: ");

        if (!int.TryParse(Console.ReadLine(), out int totalDays) || totalDays < 0)
        {
            Console.WriteLine("Invalid total days. Enter zero or a positive number.");
            return;
        }

        Console.Write("Enter Used Days: ");

        if (!int.TryParse(Console.ReadLine(), out int usedDays) ||
            usedDays < 0 || usedDays > totalDays)
        {
            Console.WriteLine("Invalid used days. Used days must be between zero and total days.");
            return;
        }

        int remainingDays = totalDays - usedDays;

        LeaveBalance leaveBalance = new LeaveBalance
        {
            EmployeeId = employeeId,
            LeaveTypeId = leaveTypeId,
            TotalDays = totalDays,
            UsedDays = usedDays,
            RemainingDays = remainingDays
        };

        await _leaveBalanceService.AddLeaveBalanceAsync(leaveBalance);

        Console.WriteLine("Leave balance added successfully!");
    }

    private async Task ViewAllLeaveBalancesAsync()
    {
        List<LeaveBalance> leaveBalances =
            await _leaveBalanceService.GetAllLeaveBalancesAsync();

        if (leaveBalances.Count == 0)
        {
            Console.WriteLine("No leave balances found.");
            return;
        }

        foreach (LeaveBalance leaveBalance in leaveBalances)
        {
            DisplayLeaveBalance(leaveBalance);
        }
    }

    private async Task ViewLeaveBalanceByIdAsync()
    {
        if (!ConsoleHelper.TryReadId("Enter Leave Balance ID: ", out int leaveBalanceId))
        {
            return;
        }

        LeaveBalance? leaveBalance =
            await _leaveBalanceService.GetLeaveBalanceByIdAsync(leaveBalanceId);

        if (leaveBalance == null)
        {
            Console.WriteLine("Leave balance not found.");
            return;
        }

        DisplayLeaveBalance(leaveBalance);
    }

    private async Task UpdateLeaveBalanceAsync()
    {
        if (!ConsoleHelper.TryReadId("Enter Leave Balance ID to update: ", out int leaveBalanceId))
        {
            return;
        }

        LeaveBalance? leaveBalance =
            await _leaveBalanceService.GetLeaveBalanceByIdAsync(leaveBalanceId);

        if (leaveBalance == null)
        {
            Console.WriteLine("Leave balance not found.");
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

        Console.Write("Enter new Total Days: ");

        if (!int.TryParse(Console.ReadLine(), out int totalDays) || totalDays < 0)
        {
            Console.WriteLine("Invalid total days. Enter zero or a positive number.");
            return;
        }

        Console.Write("Enter new Used Days: ");

        if (!int.TryParse(Console.ReadLine(), out int usedDays) ||
            usedDays < 0 || usedDays > totalDays)
        {
            Console.WriteLine("Invalid used days. Used days must be between zero and total days.");
            return;
        }

        leaveBalance.EmployeeId = employeeId;
        leaveBalance.LeaveTypeId = leaveTypeId;
        leaveBalance.TotalDays = totalDays;
        leaveBalance.UsedDays = usedDays;
        leaveBalance.RemainingDays = totalDays - usedDays;

        await _leaveBalanceService.UpdateLeaveBalanceAsync(leaveBalance);

        Console.WriteLine("Leave balance updated successfully!");
    }

    private async Task DeleteLeaveBalanceAsync()
    {
        if (!ConsoleHelper.TryReadId("Enter Leave Balance ID to delete: ", out int leaveBalanceId))
        {
            return;
        }

        LeaveBalance? leaveBalance =
            await _leaveBalanceService.GetLeaveBalanceByIdAsync(leaveBalanceId);

        if (leaveBalance == null)
        {
            Console.WriteLine("Leave balance not found.");
            return;
        }

        await _leaveBalanceService.DeleteLeaveBalanceAsync(leaveBalanceId);

        Console.WriteLine("Leave balance deleted successfully!");
    }

    private void DisplayLeaveBalance(LeaveBalance leaveBalance)
    {
        Console.WriteLine("\n------------------------------");
        Console.WriteLine($"Leave Balance ID : {leaveBalance.LeaveBalanceId}");
        Console.WriteLine($"Employee ID      : {leaveBalance.EmployeeId}");
        Console.WriteLine($"Leave Type ID    : {leaveBalance.LeaveTypeId}");
        Console.WriteLine($"Total Days       : {leaveBalance.TotalDays}");
        Console.WriteLine($"Used Days        : {leaveBalance.UsedDays}");
        Console.WriteLine($"Remaining Days   : {leaveBalance.RemainingDays}");
        Console.WriteLine("------------------------------");
    }
}
