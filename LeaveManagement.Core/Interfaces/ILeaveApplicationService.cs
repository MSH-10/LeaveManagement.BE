using LeaveManagement.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.Core.Services
{
    public interface ILeaveApplicationService
    {
        Task<IEnumerable<LeaveApplicationDto>> GetAllLeaveApplicationsAsync();
        Task<LeaveApplicationDto> GetLeaveApplicationByIdAsync(Guid id);
        Task AddLeaveApplicationAsync(LeaveApplicationDto leaveApplicationDto);
        Task UpdateLeaveApplicationAsync(Guid id, LeaveApplicationDto leaveApplicationDto);
        Task DeleteLeaveApplicationAsync(Guid id);
    }
}
