using LeaveManagement.Core.Entities;
using LeaveManagement.Core.Interfaces;
using LeaveManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.Infrastructure.Repositories
{
    public class LeaveApplicationRepository : ILeaveApplicationRepository
    {
        private readonly LeaveManagementDbContext _context;

        public LeaveApplicationRepository(LeaveManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LeaveApplication>> GetAllLeaveApplicationsAsync()
        {
            return await _context.LeaveApplications.ToListAsync();
        }

        public async Task<LeaveApplication> GetLeaveApplicationByIdAsync(Guid id)
        {
            return await _context.LeaveApplications.FindAsync(id);
        }

        public async Task AddLeaveApplicationAsync(LeaveApplication leaveApplication)
        {
            leaveApplication.CreatedUserId = leaveApplication.ApplicantUserId;
            _context.LeaveApplications.Add(leaveApplication);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLeaveApplicationAsync(LeaveApplication leaveApplication)
        {
            leaveApplication.ModifiedUserId = leaveApplication.ApplicantUserId;
            _context.Entry(leaveApplication).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLeaveApplicationAsync(Guid id)
        {
            var leaveApplication = await _context.LeaveApplications.FindAsync(id);
            if (leaveApplication != null)
            {
                _context.LeaveApplications.Remove(leaveApplication);
                await _context.SaveChangesAsync();
            }
        }
    }
}
