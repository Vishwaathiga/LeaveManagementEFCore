using System;
using System.Collections.Generic;
using System.Text;


using LeaveManagementEFCore.Models;
using LeaveManagementEFCore.Repositories;

namespace LeaveManagementEFCore.Services;

public class LeaveTypeService
{
    private readonly LeaveTypeRepository _leaveTypeRepository;

    public LeaveTypeService(LeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task AddLeaveTypeAsync(LeaveType leaveType)
    {
        await _leaveTypeRepository.AddLeaveTypeAsync(leaveType);
    }

    public async Task<List<LeaveType>> GetAllLeaveTypesAsync()
    {
        return await _leaveTypeRepository.GetAllLeaveTypesAsync();
    }

    public async Task<LeaveType?> GetLeaveTypeByIdAsync(int leaveTypeId)
    {
        return await _leaveTypeRepository.GetLeaveTypeByIdAsync(leaveTypeId);
    }

    public async Task UpdateLeaveTypeAsync(LeaveType leaveType)
    {
        await _leaveTypeRepository.UpdateLeaveTypeAsync(leaveType);
    }

    public async Task DeleteLeaveTypeAsync(int leaveTypeId)
    {
        await _leaveTypeRepository.DeleteLeaveTypeAsync(leaveTypeId);
    }
}

