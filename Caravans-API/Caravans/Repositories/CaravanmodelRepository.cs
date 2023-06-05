using Caravans.Interfaces;
using Caravans.Models;
using Microsoft.EntityFrameworkCore;

namespace Caravans.Repositories
{
    public class CaravanmodelRepository : ICaravanmodelRepository
    {
        private readonly DatabaseContext _context;
        public CaravanmodelRepository(DatabaseContext context) { _context = context; }

        public async Task<Caravanmodel> Add(Caravanmodel caravanmodel)
        {
            _context.Add(caravanmodel);
            await _context.SaveChangesAsync();

            return caravanmodel;
        }

        public async Task<Caravanmodel> Get(Guid id) => await _context.Caravanmodels.FirstOrDefaultAsync(x => x.ModelId == id);

        public async Task<IEnumerable<Caravanmodel>> GetAll() => await _context.Caravanmodels.ToListAsync();

        public async Task Delete(Caravanmodel caravanmodel)
        {
            _context.Caravanmodels.Remove(caravanmodel);
            await _context.SaveChangesAsync();
        }

        public async Task<Caravanmodel> Update(Caravanmodel caravanmodel)
        {

            var c = await _context.Caravanmodels
                .Where(ch => ch.ModelId == caravanmodel.ModelId)
                .FirstOrDefaultAsync();

            if (c != null)
            {
                c.ModelId = caravanmodel.ModelId;
                c.Producer = caravanmodel.Producer;
                c.Model = caravanmodel.Model;
                c.Price = caravanmodel.Price;
                c.Weight = caravanmodel.Weight;
                c.Length = caravanmodel.Length;
                c.LengthInside = caravanmodel.LengthInside;
                c.Width = caravanmodel.Width;
                c.WidthInside = caravanmodel.WidthInside;
                c.People = caravanmodel.People;
                c.Water = caravanmodel.Water;
                c.HotWater = caravanmodel.HotWater;
                c.Shower = caravanmodel.Shower;
                c.Fridge = caravanmodel.Fridge;
                c.Picture = caravanmodel.Picture;
                await _context.SaveChangesAsync();
            }
            return c;
        }
    }
}
