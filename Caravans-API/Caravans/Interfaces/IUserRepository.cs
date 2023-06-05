using Caravans.Models;

namespace Caravans.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Get(Guid id);
        Task<User> GetByEmail(string email);
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task<User> Delete(Guid id);
    }
}
