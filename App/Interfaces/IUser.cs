using System.Collections.Generic;
using System.Threading.Tasks;
using managementcv.Models;

namespace managementcv.App.Interfaces
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task RegisterUserAsync(User user);
        //Task<User> GetUserByIdAsync(int userId);
        //Task UpdateUserAsync(User user);
        //Task DeleteUserAsync(int userId);
    }
}
