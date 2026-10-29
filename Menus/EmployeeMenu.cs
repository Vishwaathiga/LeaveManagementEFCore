using System;
using System.Collections.Generic;
using System.Text;


using LeaveManagementEFCore.Models;
using LeaveManagementEFCore.Services;

namespace LeaveManagementEFCore.Menus;

public class EmployeeMenu
{
    private readonly EmployeeService _employeeService;

    public EmployeeMenu(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task ShowMenuAsync()
    {
        while (true)
        {
            Console.WriteLine("\n===== EMPLOYEE MANAGEMENT =====");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. View All Employees");
            Console.WriteLine("3. View Employee by ID");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. Back");
            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await AddEmployeeAsync();
                    break;

                case "2":
                    await ViewAllEmployeesAsync();
                    break;

                case "3":
                    await ViewEmployeeByIdAsync();
                    break;

                case "4":
                    await UpdateEmployeeAsync();
                    break;

                case "5":
                    await DeleteEmployeeAsync();
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private async Task AddEmployeeAsync()
    {
        Console.Write("Enter employee name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter email: ");
        string email = Console.ReadLine() ?? "";

        Console.Write("Enter department: ");
        string department = Console.ReadLine() ?? "";

        Employee employee = new Employee
        {
            EmployeeName = name,
            Email = email,
            Department = department,
            IsActive = true
        };

        await _employeeService.AddEmployeeAsync(employee);

        Console.WriteLine("Employee added successfully!");
    }

    private async Task ViewAllEmployeesAsync()
    {
        List<Employee> employees =
            await _employeeService.GetAllEmployeesAsync();

        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }

        foreach (Employee employee in employees)
        {
            DisplayEmployee(employee);
        }
    }

    private async Task ViewEmployeeByIdAsync()
    {
        Console.Write("Enter employee ID: ");

        if (!int.TryParse(Console.ReadLine(), out int employeeId))
        {
            Console.WriteLine("Invalid employee ID.");
            return;
        }

        Employee? employee =
            await _employeeService.GetEmployeeByIdAsync(employeeId);

        if (employee == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        DisplayEmployee(employee);
    }

    private async Task UpdateEmployeeAsync()
    {
        Console.Write("Enter employee ID to update: ");

        if (!int.TryParse(Console.ReadLine(), out int employeeId))
        {
            Console.WriteLine("Invalid employee ID.");
            return;
        }

        Employee? employee =
            await _employeeService.GetEmployeeByIdAsync(employeeId);

        if (employee == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        Console.Write($"Enter new name ({employee.EmployeeName}): ");
        string? name = Console.ReadLine();

        Console.Write($"Enter new email ({employee.Email}): ");
        string? email = Console.ReadLine();

        Console.Write($"Enter new department ({employee.Department}): ");
        string? department = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(name))
        {
            employee.EmployeeName = name;
        }

        if (!string.IsNullOrWhiteSpace(email))
        {
            employee.Email = email;
        }

        if (!string.IsNullOrWhiteSpace(department))
        {
            employee.Department = department;
        }

        await _employeeService.UpdateEmployeeAsync(employee);

        Console.WriteLine("Employee updated successfully!");
    }

    private async Task DeleteEmployeeAsync()
    {
        Console.Write("Enter employee ID to delete: ");

        if (!int.TryParse(Console.ReadLine(), out int employeeId))
        {
            Console.WriteLine("Invalid employee ID.");
            return;
        }

        Employee? employee =
            await _employeeService.GetEmployeeByIdAsync(employeeId);

        if (employee == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        await _employeeService.DeleteEmployeeAsync(employeeId);

        Console.WriteLine("Employee deleted successfully!");
    }

    private void DisplayEmployee(Employee employee)
    {
        Console.WriteLine("\n----------------------------");
        Console.WriteLine($"Employee ID: {employee.EmployeeId}");
        Console.WriteLine($"Name: {employee.EmployeeName}");
        Console.WriteLine($"Email: {employee.Email}");
        Console.WriteLine($"Department: {employee.Department}");
        Console.WriteLine($"Active: {employee.IsActive}");
        Console.WriteLine("----------------------------");
    }
}

