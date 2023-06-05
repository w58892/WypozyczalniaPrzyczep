using Caravans.Models;

namespace Caravans.Interfaces
{
    public interface ICaravanRepository
    {
        Task<IEnumerable<Caravan>> GetAll();
        Task<Caravan> Get(Guid id);
        Task<Caravan> Add(Caravan caravan);
        Task<Caravan> Update(Caravan caravan);
        Task Delete(Caravan caravan);
    }
}
