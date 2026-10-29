
using LeaveManagementEFCore.Models;
using LeaveManagementEFCore.Repositories;

namespace LeaveManagementEFCore.Services;

public class LeaveBalanceService
{
    private readonly LeaveBalanceRepository _leaveBalanceRepository;

    public LeaveBalanceService(
        LeaveBalanceRepository leaveBalanceRepository)
    {
        _leaveBalanceRepository = leaveBalanceRepository;
    }

    public async Task AddLeaveBalanceAsync(LeaveBalance leaveBalance)
    {
        await _leaveBalanceRepository.AddLeaveBalanceAsync(leaveBalance);
    }

    public async Task<List<LeaveBalance>> GetAllLeaveBalancesAsync()
    {
        return await _leaveBalanceRepository.GetAllLeaveBalancesAsync();
    }

    public async Task<LeaveBalance?> GetLeaveBalanceByIdAsync(int leaveBalanceId)
    {
        return await _leaveBalanceRepository
            .GetLeaveBalanceByIdAsync(leaveBalanceId);
    }

    public async Task UpdateLeaveBalanceAsync(LeaveBalance leaveBalance)
    {
        await _leaveBalanceRepository.UpdateLeaveBalanceAsync(leaveBalance);
    }

    public async Task DeleteLeaveBalanceAsync(int leaveBalanceId)
    {
        await _leaveBalanceRepository.DeleteLeaveBalanceAsync(leaveBalanceId);
    }
}
