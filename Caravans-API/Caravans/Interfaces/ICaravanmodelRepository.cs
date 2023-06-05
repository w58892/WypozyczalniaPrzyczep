using Caravans.Models;

namespace Caravans.Interfaces
{
    public interface ICaravanmodelRepository
    {
        Task<IEnumerable<Caravanmodel>> GetAll();
        Task<Caravanmodel> Get(Guid id);
        Task<Caravanmodel> Add(Caravanmodel caravanmodel);
        Task<Caravanmodel> Update(Caravanmodel caravanmodel);
        Task Delete(Caravanmodel caravanmodel);
    }
}
