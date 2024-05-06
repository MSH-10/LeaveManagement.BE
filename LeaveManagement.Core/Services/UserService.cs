using AutoMapper;
using LeaveManagement.Core.DTOs;
using LeaveManagement.Core.DTOs;
using LeaveManagement.Core.Entities;
using LeaveManagement.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveManagement.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task AddUserAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(Guid id, UserDto userDto)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                // Handle not found error
            }

            _mapper.Map(userDto, existingUser);
            await _userRepository.UpdateUserAsync(existingUser);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
