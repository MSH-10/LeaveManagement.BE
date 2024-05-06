using LeaveManagement.Core.DTOs;
using LeaveManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task AddUserAsync(UserDto userDto);
        Task UpdateUserAsync(Guid id, UserDto userDto);
        Task DeleteUserAsync(Guid id);
    }
}
