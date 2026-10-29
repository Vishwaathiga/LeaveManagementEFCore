using System;
using System.Collections.Generic;
using System.Text;


using LeaveManagementEFCore.Models;
using LeaveManagementEFCore.Repositories;

namespace LeaveManagementEFCore.Services;

public class EmployeeService
{
    private readonly EmployeeRepository _employeeRepository;

    public EmployeeService(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        await _employeeRepository.AddEmployeeAsync(employee);
    }

    public async Task<List<Employee>> GetAllEmployeesAsync()
    {
        return await _employeeRepository.GetAllEmployeesAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int employeeId)
    {
        return await _employeeRepository.GetEmployeeByIdAsync(employeeId);
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        await _employeeRepository.UpdateEmployeeAsync(employee);
    }

    public async Task DeleteEmployeeAsync(int employeeId)
    {
        await _employeeRepository.DeleteEmployeeAsync(employeeId);
    }
}
