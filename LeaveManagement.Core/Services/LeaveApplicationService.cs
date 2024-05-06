using AutoMapper;
using LeaveManagement.Core.DTOs;
using LeaveManagement.Core.Entities;
using LeaveManagement.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.Core.Services
{
    public class LeaveApplicationService : ILeaveApplicationService
    {
        private readonly ILeaveApplicationRepository _leaveRepository;
        private readonly IMapper _mapper;

        public LeaveApplicationService(ILeaveApplicationRepository leaveRepository, IMapper mapper)
        {
            _leaveRepository = leaveRepository;     
            _mapper = mapper;
        }

        public async Task<IEnumerable<LeaveApplicationDto>> GetAllLeaveApplicationsAsync()
        {
            var leaveApplications = await _leaveRepository.GetAllLeaveApplicationsAsync();
            return _mapper.Map<IEnumerable<LeaveApplicationDto>>(leaveApplications);
        }

        public async Task<LeaveApplicationDto> GetLeaveApplicationByIdAsync(Guid id)
        {
            var leaveApplication = await _leaveRepository.GetLeaveApplicationByIdAsync(id);
            return _mapper.Map<LeaveApplicationDto>(leaveApplication);
        }

        public async Task AddLeaveApplicationAsync(LeaveApplicationDto leaveApplicationDto)
        {
            var leaveApplication = _mapper.Map<LeaveApplication>(leaveApplicationDto);
            await _leaveRepository.AddLeaveApplicationAsync(leaveApplication);
        }

        public async Task UpdateLeaveApplicationAsync(Guid id, LeaveApplicationDto leaveApplicationDto)
        {
            var existingLeaveApplication = await _leaveRepository.GetLeaveApplicationByIdAsync(id);
            if (existingLeaveApplication == null)
            {
                // Handle not found scenario
                return;
            }

            _mapper.Map(leaveApplicationDto, existingLeaveApplication);
            await _leaveRepository.UpdateLeaveApplicationAsync(existingLeaveApplication);
        }

        public async Task DeleteLeaveApplicationAsync(Guid id)
        {
            await _leaveRepository.DeleteLeaveApplicationAsync(id);
        }
    }
}
