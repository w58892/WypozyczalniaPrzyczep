using Caravans.Models;

namespace Caravans.Interfaces
{
    public interface IJwtAutenticationManager
    {
        string Authenticate(User user);
    }
}
