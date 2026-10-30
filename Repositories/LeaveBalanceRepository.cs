
using LeaveManagementEFCore.Data;
using LeaveManagementEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementEFCore.Repositories;

public class LeaveBalanceRepository
{
    private readonly AppDbContext _context;

    public LeaveBalanceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddLeaveBalanceAsync(LeaveBalance leaveBalance)
    {
        await _context.LeaveBalances.AddAsync(leaveBalance);
        await _context.SaveChangesAsync();
    }

    public async Task<List<LeaveBalance>> GetAllLeaveBalancesAsync()
    {
        return await _context.LeaveBalances.ToListAsync();
    }

    public async Task<LeaveBalance?> GetLeaveBalanceByIdAsync(int leaveBalanceId)
    {
        return await _context.LeaveBalances
             .AsNoTracking()
            .FirstOrDefaultAsync(l => l.LeaveBalanceId == leaveBalanceId);
    }

    public async Task UpdateLeaveBalanceAsync(LeaveBalance leaveBalance)
    {
        _context.LeaveBalances.Update(leaveBalance);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteLeaveBalanceAsync(int leaveBalanceId)
    {
        LeaveBalance? leaveBalance =
            await GetLeaveBalanceByIdAsync(leaveBalanceId);

        if (leaveBalance != null)
        {
            _context.LeaveBalances.Remove(leaveBalance);
            await _context.SaveChangesAsync();
        }
    }
}
