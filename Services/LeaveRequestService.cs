
using LeaveManagementEFCore.Models;
using LeaveManagementEFCore.Repositories;

namespace LeaveManagementEFCore.Services;

public class LeaveRequestService
{
    private readonly LeaveRequestRepository _leaveRequestRepository;

    public LeaveRequestService(
        LeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
    }

    public async Task AddLeaveRequestAsync(LeaveRequest leaveRequest)
    {
        await _leaveRequestRepository.AddLeaveRequestAsync(leaveRequest);
    }

    public async Task<List<LeaveRequest>> GetAllLeaveRequestsAsync()
    {
        return await _leaveRequestRepository.GetAllLeaveRequestsAsync();
    }

    public async Task<LeaveRequest?> GetLeaveRequestByIdAsync(int leaveRequestId)
    {
        return await _leaveRequestRepository
            .GetLeaveRequestByIdAsync(leaveRequestId);
    }

    public async Task UpdateLeaveRequestAsync(LeaveRequest leaveRequest)
    {
        await _leaveRequestRepository.UpdateLeaveRequestAsync(leaveRequest);
    }

    public async Task DeleteLeaveRequestAsync(int leaveRequestId)
    {
        await _leaveRequestRepository.DeleteLeaveRequestAsync(leaveRequestId);
    }
}
