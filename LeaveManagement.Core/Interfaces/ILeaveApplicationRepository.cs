using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeaveManagement.Core.Entities;

namespace LeaveManagement.Core.Interfaces
{
    public interface ILeaveApplicationRepository
    {
        Task<IEnumerable<LeaveApplication>> GetAllLeaveApplicationsAsync();
        Task<LeaveApplication> GetLeaveApplicationByIdAsync(Guid id);
        Task AddLeaveApplicationAsync(LeaveApplication leaveApplication);
        Task UpdateLeaveApplicationAsync(LeaveApplication leaveApplication);
        Task DeleteLeaveApplicationAsync(Guid id);
    }
}
