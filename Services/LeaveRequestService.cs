using LeaveManagementEFCore.Data;
using LeaveManagementEFCore.Models;
using LeaveManagementEFCore.Repositories;

namespace LeaveManagementEFCore.Services;

public class LeaveRequestService
{
    private readonly LeaveRequestRepository _leaveRequestRepository;
    private readonly AppDbContext _context;

    public LeaveRequestService(
        LeaveRequestRepository leaveRequestRepository,
        AppDbContext context)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _context = context;
    }

    public async Task AddLeaveRequestAsync(LeaveRequest leaveRequest)
    {
        using var transaction =
            await _context.Database.BeginTransactionAsync();

        try
        {
            // Add the leave request
            await _leaveRequestRepository
                .AddLeaveRequestAsync(leaveRequest);

            // Save the leave request and generate its ID
            await _context.SaveChangesAsync();

            // Create the audit log
            AuditLog auditLog = new AuditLog
            {
                Action = "Created",
                EntityName = "LeaveRequest",
                EntityId = leaveRequest.LeaveRequestId,
                Details = $"Leave request created for Employee ID: {leaveRequest.EmployeeId}",
                ActionDate = DateTime.Now
            };

            // Add and save the audit log
            await _context.AuditLogs.AddAsync(auditLog);

            await _context.SaveChangesAsync();

            // Commit both operations
            await transaction.CommitAsync();
        }
        catch
        {
            // Roll back both operations if anything fails
            await transaction.RollbackAsync();

            throw;
        }
    }

    public async Task<List<LeaveRequest>> GetAllLeaveRequestsAsync()
    {
        return await _leaveRequestRepository
            .GetAllLeaveRequestsAsync();
    }

    public async Task<LeaveRequest?> GetLeaveRequestByIdAsync(
        int leaveRequestId)
    {
        return await _leaveRequestRepository
            .GetLeaveRequestByIdAsync(leaveRequestId);
    }

    public async Task UpdateLeaveRequestAsync(
        LeaveRequest leaveRequest)
    {
        await _leaveRequestRepository
            .UpdateLeaveRequestAsync(leaveRequest);
    }

    public async Task DeleteLeaveRequestAsync(int leaveRequestId)
    {
        await _leaveRequestRepository
            .DeleteLeaveRequestAsync(leaveRequestId);
    }
}