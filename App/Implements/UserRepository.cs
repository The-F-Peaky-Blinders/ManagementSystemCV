using AutoMapper;
using managementcv.App.Interfaces;
using managementcv.Infraestructures.Context;
using managementcv.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace managementcv.App.Implements
{
    public class UserRepository : IUser
    {
        private readonly ManagementContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task RegisterUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
