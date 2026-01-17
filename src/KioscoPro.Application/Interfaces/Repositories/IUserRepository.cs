using KioscoPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioscoPro.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        Task<User?> GetUserByIdAsync(Guid id);
        Task<List<User>> GetAllUsersAsync();
        Task<bool> ExistsUserByEmail(string email);
    }
}
