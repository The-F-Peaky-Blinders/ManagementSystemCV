using ManagementSystemCV.App.Interfaces;
using ManagementSystemCV.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagementSystemCV.App.Services
{
    public class UserService : IUser
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task RegisterUserAsync(User user)
        {
            await _userRepository.RegisterUserAsync(user);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }
    }
}
