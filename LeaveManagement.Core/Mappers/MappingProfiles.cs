using AutoMapper;
using LeaveManagement.Core.DTOs;
using LeaveManagement.Core.Entities;

namespace LeaveManagement.Core.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<LeaveApplication, LeaveApplicationDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            // Add more mappings as needed
        }
    }
}
