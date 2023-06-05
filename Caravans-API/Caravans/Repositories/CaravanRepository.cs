using Caravans.Interfaces;
using Caravans.Models;
using Microsoft.EntityFrameworkCore;

namespace Caravans.Repositories
{
    public class CaravanRepository : ICaravanRepository
    {
        private readonly DatabaseContext _context;
        public CaravanRepository(DatabaseContext context) { _context = context; }

        public async Task<Caravan> Add(Caravan caravan)
        {
            _context.Add(caravan);
            await _context.SaveChangesAsync();

            return caravan;
        }

        public async Task<Caravan> Get(Guid id)
        {
            return await _context.Caravans.FirstOrDefaultAsync(x => x.CaravanId == id);
        }

        public async Task<IEnumerable<Caravan>> GetAll() => await _context.Caravans.ToListAsync();

        public async Task Delete(Caravan caravan)
        {
            _context.Caravans.Remove(caravan);
            await _context.SaveChangesAsync();
        }

        public async Task<Caravan> Update(Caravan caravan)
        {
            var c = await Get(caravan.CaravanId);

            if (c != null)
            {
                c.NumberPlate = caravan.NumberPlate;
                c.ModelId = caravan.ModelId;
                await _context.SaveChangesAsync();
            }
            return c;
        }
    }
}
