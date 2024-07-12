using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using managementcv.Models;

namespace managementcv.App.Interfaces
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}