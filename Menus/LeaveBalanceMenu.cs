
using LeaveManagementEFCore.Models;
using LeaveManagementEFCore.Services;

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
            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();

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
        Console.Write("Enter Employee ID: ");
        int employeeId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Leave Type ID: ");
        int leaveTypeId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Total Days: ");
        int totalDays = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Used Days: ");
        int usedDays = Convert.ToInt32(Console.ReadLine());

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
        Console.Write("Enter Leave Balance ID: ");
        int leaveBalanceId = Convert.ToInt32(Console.ReadLine());

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
        Console.Write("Enter Leave Balance ID to update: ");
        int leaveBalanceId = Convert.ToInt32(Console.ReadLine());

        LeaveBalance? leaveBalance =
            await _leaveBalanceService.GetLeaveBalanceByIdAsync(leaveBalanceId);

        if (leaveBalance == null)
        {
            Console.WriteLine("Leave balance not found.");
            return;
        }

        Console.Write("Enter new Employee ID: ");
        leaveBalance.EmployeeId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter new Leave Type ID: ");
        leaveBalance.LeaveTypeId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter new Total Days: ");
        leaveBalance.TotalDays = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter new Used Days: ");
        leaveBalance.UsedDays = Convert.ToInt32(Console.ReadLine());

        leaveBalance.RemainingDays =
            leaveBalance.TotalDays - leaveBalance.UsedDays;

        await _leaveBalanceService.UpdateLeaveBalanceAsync(leaveBalance);

        Console.WriteLine("Leave balance updated successfully!");
    }

    private async Task DeleteLeaveBalanceAsync()
    {
        Console.Write("Enter Leave Balance ID to delete: ");
        int leaveBalanceId = Convert.ToInt32(Console.ReadLine());

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
