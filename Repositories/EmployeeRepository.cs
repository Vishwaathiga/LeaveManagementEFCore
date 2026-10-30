using System;
using System.Collections.Generic;
using System.Text;


using LeaveManagementEFCore.Data;
using LeaveManagementEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementEFCore.Repositories;

public class EmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Employee>> GetAllEmployeesAsync()
    {
        return await _context.Employees
            .AsNoTracking()
            .ToListAsync();
            
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int employeeId)
    {
        return await _context.Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(int employeeId)
    {
        Employee? employee = await GetEmployeeByIdAsync(employeeId);

        if (employee != null)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
