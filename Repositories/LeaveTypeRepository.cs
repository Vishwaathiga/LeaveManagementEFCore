using System;
using System.Collections.Generic;
using System.Text;


using LeaveManagementEFCore.Data;
using LeaveManagementEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementEFCore.Repositories;

public class LeaveTypeRepository
{
    private readonly AppDbContext _context;

    public LeaveTypeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddLeaveTypeAsync(LeaveType leaveType)
    {
        await _context.LeaveTypes.AddAsync(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task<List<LeaveType>> GetAllLeaveTypesAsync()
    {
        return await _context.LeaveTypes.ToListAsync();
    }

    public async Task<LeaveType?> GetLeaveTypeByIdAsync(int leaveTypeId)
    {
        return await _context.LeaveTypes
            .FirstOrDefaultAsync(l => l.LeaveTypeId == leaveTypeId);
    }

    public async Task UpdateLeaveTypeAsync(LeaveType leaveType)
    {
        _context.LeaveTypes.Update(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteLeaveTypeAsync(int leaveTypeId)
    {
        LeaveType? leaveType =
            await GetLeaveTypeByIdAsync(leaveTypeId);

        if (leaveType != null)
        {
            _context.LeaveTypes.Remove(leaveType);
            await _context.SaveChangesAsync();
        }
    }
}
