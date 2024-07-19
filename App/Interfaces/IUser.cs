using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementSystemCV.Models;

namespace ManagementSystemCV.App.Interfaces
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task RegisterUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        //Task<User> GetUserByIdAsync(int userId);
        //Task UpdateUserAsync(User user);
        //Task DeleteUserAsync(int userId);
    }
}
