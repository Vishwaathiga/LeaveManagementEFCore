
using LeaveManagementEFCore.Data;
using LeaveManagementEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementEFCore.Repositories;

public class LeaveRequestRepository
{
    private readonly AppDbContext _context;

    public LeaveRequestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddLeaveRequestAsync(LeaveRequest leaveRequest)
    {
        await _context.LeaveRequests.AddAsync(leaveRequest);
        await _context.SaveChangesAsync();
    }

    public async Task<List<LeaveRequest>> GetAllLeaveRequestsAsync()
    {
        return await _context.LeaveRequests.ToListAsync();
    }

    public async Task<LeaveRequest?> GetLeaveRequestByIdAsync(int leaveRequestId)
    {
        return await _context.LeaveRequests
            .FirstOrDefaultAsync(l => l.LeaveRequestId == leaveRequestId);
    }

    public async Task UpdateLeaveRequestAsync(LeaveRequest leaveRequest)
    {
        _context.LeaveRequests.Update(leaveRequest);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteLeaveRequestAsync(int leaveRequestId)
    {
        LeaveRequest? leaveRequest =
            await GetLeaveRequestByIdAsync(leaveRequestId);

        if (leaveRequest != null)
        {
            _context.LeaveRequests.Remove(leaveRequest);
            await _context.SaveChangesAsync();
        }
    }
}
