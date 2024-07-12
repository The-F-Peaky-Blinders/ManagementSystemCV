using AutoMapper;
using managementcv.App.Interfaces;
using managementcv.Infraestructures.Context;
using managementcv.Models;
using Microsoft.EntityFrameworkCore;

namespace managementcv.App.Implements
{
    public class UserRepository : IUser
    {
        public readonly ManagementContext _context;
        public readonly IMapper _mapper;
        public UserRepository(ManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Sobrecarga de metodos
        public UserRepository(){}

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task RegisterUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        
    }
}