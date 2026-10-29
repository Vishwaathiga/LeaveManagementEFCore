using System;
using System.Collections.Generic;
using System.Text;


using LeaveManagementEFCore.Models;
using LeaveManagementEFCore.Services;

namespace LeaveManagementEFCore.Menus;

public class LeaveTypeMenu
{
    private readonly LeaveTypeService _leaveTypeService;

    public LeaveTypeMenu(LeaveTypeService leaveTypeService)
    {
        _leaveTypeService = leaveTypeService;
    }

    public async Task ShowMenuAsync()
    {
        while (true)
        {
            Console.WriteLine("\n===== LEAVE TYPE MANAGEMENT =====");
            Console.WriteLine("1. Add Leave Type");
            Console.WriteLine("2. View All Leave Types");
            Console.WriteLine("3. View Leave Type by ID");
            Console.WriteLine("4. Update Leave Type");
            Console.WriteLine("5. Delete Leave Type");
            Console.WriteLine("6. Back");
            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await AddLeaveTypeAsync();
                    break;

                case "2":
                    await ViewAllLeaveTypesAsync();
                    break;

                case "3":
                    await ViewLeaveTypeByIdAsync();
                    break;

                case "4":
                    await UpdateLeaveTypeAsync();
                    break;

                case "5":
                    await DeleteLeaveTypeAsync();
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private async Task AddLeaveTypeAsync()
    {
        Console.Write("Enter leave type name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter maximum days: ");

        if (!int.TryParse(Console.ReadLine(), out int maximumDays))
        {
            Console.WriteLine("Invalid number of days.");
            return;
        }

        LeaveType leaveType = new LeaveType
        {
            LeaveTypeName = name,
            MaximumDays = maximumDays,
            IsActive = true
        };

        await _leaveTypeService.AddLeaveTypeAsync(leaveType);

        Console.WriteLine("Leave type added successfully!");
    }

    private async Task ViewAllLeaveTypesAsync()
    {
        List<LeaveType> leaveTypes =
            await _leaveTypeService.GetAllLeaveTypesAsync();

        if (leaveTypes.Count == 0)
        {
            Console.WriteLine("No leave types found.");
            return;
        }

        foreach (LeaveType leaveType in leaveTypes)
        {
            DisplayLeaveType(leaveType);
        }
    }

    private async Task ViewLeaveTypeByIdAsync()
    {
        Console.Write("Enter leave type ID: ");

        if (!int.TryParse(Console.ReadLine(), out int leaveTypeId))
        {
            Console.WriteLine("Invalid leave type ID.");
            return;
        }

        LeaveType? leaveType =
            await _leaveTypeService.GetLeaveTypeByIdAsync(leaveTypeId);

        if (leaveType == null)
        {
            Console.WriteLine("Leave type not found.");
            return;
        }

        DisplayLeaveType(leaveType);
    }

    private async Task UpdateLeaveTypeAsync()
    {
        Console.Write("Enter leave type ID to update: ");

        if (!int.TryParse(Console.ReadLine(), out int leaveTypeId))
        {
            Console.WriteLine("Invalid leave type ID.");
            return;
        }

        LeaveType? leaveType =
            await _leaveTypeService.GetLeaveTypeByIdAsync(leaveTypeId);

        if (leaveType == null)
        {
            Console.WriteLine("Leave type not found.");
            return;
        }

        Console.Write($"Enter new name ({leaveType.LeaveTypeName}): ");
        string? name = Console.ReadLine();

        Console.Write($"Enter new maximum days ({leaveType.MaximumDays}): ");
        string? daysInput = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(name))
        {
            leaveType.LeaveTypeName = name;
        }

        if (!string.IsNullOrWhiteSpace(daysInput))
        {
            if (!int.TryParse(daysInput, out int maximumDays))
            {
                Console.WriteLine("Invalid number of days.");
                return;
            }

            leaveType.MaximumDays = maximumDays;
        }

        await _leaveTypeService.UpdateLeaveTypeAsync(leaveType);

        Console.WriteLine("Leave type updated successfully!");
    }

    private async Task DeleteLeaveTypeAsync()
    {
        Console.Write("Enter leave type ID to delete: ");

        if (!int.TryParse(Console.ReadLine(), out int leaveTypeId))
        {
            Console.WriteLine("Invalid leave type ID.");
            return;
        }

        LeaveType? leaveType =
            await _leaveTypeService.GetLeaveTypeByIdAsync(leaveTypeId);

        if (leaveType == null)
        {
            Console.WriteLine("Leave type not found.");
            return;
        }

        await _leaveTypeService.DeleteLeaveTypeAsync(leaveTypeId);

        Console.WriteLine("Leave type deleted successfully!");
    }

    private void DisplayLeaveType(LeaveType leaveType)
    {
        Console.WriteLine("\n----------------------------");
        Console.WriteLine($"Leave Type ID: {leaveType.LeaveTypeId}");
        Console.WriteLine($"Name: {leaveType.LeaveTypeName}");
        Console.WriteLine($"Maximum Days: {leaveType.MaximumDays}");
        Console.WriteLine($"Active: {leaveType.IsActive}");
        Console.WriteLine("----------------------------");
    }
}

