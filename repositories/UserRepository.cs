using System.Collections.Generic;
using System.Threading.Tasks;
using code_dotnet.database;
using code_dotnet.entities;
using Microsoft.EntityFrameworkCore;

namespace code_dotnet.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> GetUserByIdAsync(int id)
        {
            return await _context.UserEntity.FindAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            return await _context.UserEntity.ToListAsync();
        }

        public async Task AddUserAsync(UserEntity user)
        {
            await _context.UserEntity.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserEntity user)
        {
            _context.UserEntity.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.UserEntity.FindAsync(id);
            if (user != null)
            {
                _context.UserEntity.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
