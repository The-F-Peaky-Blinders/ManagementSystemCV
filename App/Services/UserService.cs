/* using AutoMapper;
using ManagementSystemCV.App.Implements;
using ManagementSystemCV.App.Interfaces;
using ManagementSystemCV.Infraestructures.Context;
using ManagementSystemCV.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagementSystemCV.App.Services
{
    public class UserService : IUser
    {
        private readonly UserRepository _userRepository; // Asegúrate de que UserService tenga una referencia a UserRepository

        public UserService(ManagementContext context, IMapper mapper)
        {
            _userRepository = new UserRepository(context, mapper); // Aquí es donde debes proporcionar context y mapper
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
 */