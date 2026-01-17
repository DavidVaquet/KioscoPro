using KioscoPro.Application.Interfaces.Repositories;
using KioscoPro.Domain.Entities;
using KioscoPro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioscoPro.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }
        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users
                                 .AsNoTracking()
                                 .ToListAsync();
        }
        public async Task<bool> ExistsUserByEmail(string email)
        {
            return await _context.Users
                                 .AsNoTracking()
                                 .AnyAsync(u => u.UserEmail.ToLower() == email.ToLower());
        }
    }
}