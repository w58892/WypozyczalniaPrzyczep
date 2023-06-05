using Caravans.Interfaces;
using Caravans.Models;
using Microsoft.EntityFrameworkCore;

namespace Caravans.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;
        public UserRepository(DatabaseContext context) { _context = context; }

        public async Task<User> Add(User user)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

            User u = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = passwordHash,
            };
            _context.Add(u);
            await _context.SaveChangesAsync();

            return u;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _context.Users
                .Where(s => s.Email == email)
                .FirstOrDefaultAsync();
            return user;
        }
        public async Task<User> Get(Guid id) => await _context.Users.FindAsync(id);

        public async Task<IEnumerable<User>> GetAll() => await _context.Users.ToListAsync();

        public async Task<User> Delete(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task<User> Update(User user)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var u = await _context.Users
                .Where(ch => ch.UserId == user.UserId)
                .FirstOrDefaultAsync();

            if (u != null)
            {
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.Email = user.Email;
                u.Password = passwordHash;
                await _context.SaveChangesAsync();
            }
            return u;
        }
    }
}
