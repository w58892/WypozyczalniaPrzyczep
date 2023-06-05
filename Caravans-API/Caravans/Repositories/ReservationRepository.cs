using Caravans.Interfaces;
using Caravans.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Caravans.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DatabaseContext _context;
        public ReservationRepository(DatabaseContext context) { _context = context; }

        public async Task<Reservation> Add(Reservation reservation)
        {

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }

        public async Task<Guid> AvailableCaravan(ReservationAdd reservation)
        {
            return await _context.Caravans
                .Where(c => c.ModelId == reservation.ModelId)
                .GroupJoin(_context.Reservations
                .Where(r => r.ReservationEnd > reservation.Begin && r.ReservationBegin < reservation.End),
                c => c.CaravanId, r => r.CaravanId,
                (c, rs) => new { Caravan = c, Reservations = rs })
                .Where(cr => !cr.Reservations.Any())
                .Select(cr => cr.Caravan.CaravanId).FirstOrDefaultAsync();
        }

        public async Task<Reservation> Get(Guid id) => await _context.Reservations.FirstOrDefaultAsync(x => x.ReservationId == id);

        public async Task<IEnumerable<Reservation>> GetAll() => await _context.Reservations.ToListAsync();

        public async Task Delete(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<Reservation> Update(Reservation reservation)
        {
            var r = await _context.Reservations
                .Where(ch => ch.ReservationId == reservation.ReservationId)
                .FirstOrDefaultAsync();

            if (r != null)
            {
                r.ReservationDate = reservation.ReservationDate;
                r.ReservationBegin = reservation.ReservationBegin;
                r.ReservationEnd = reservation.ReservationEnd;
                r.UserId = reservation.UserId;
                r.CaravanId = reservation.CaravanId;
                await _context.SaveChangesAsync();
            }
            return r;
        }

        public async Task<IEnumerable<ReservationCaravan>> GetByUser(Guid userId)
        {
            List<ReservationCaravan> reservation = new List<ReservationCaravan>();
            foreach (var item in await _context.Reservations.Where(x => x.UserId == userId).ToListAsync())
            {
                Caravan caravan = await _context.Caravans.FindAsync(item.CaravanId);
                Caravanmodel model = await _context.Caravanmodels.FindAsync(caravan.ModelId);
                reservation.Add(new ReservationCaravan
                {
                    Reservation = item,
                    Caravan = caravan,
                    Caravanmodel = model
                });
            }
            return reservation;
        }

        public async Task<byte[]> GetPdf(Guid id)
        {
            Pdf pdf = new Pdf(_context);
            return await pdf.CreatePdf(id);
        }

        public async Task<Reservation> ConfirmReservation(Guid id)
        {
            var r = await _context.Reservations
                            .Where(ch => ch.ReservationId == id)
                            .FirstOrDefaultAsync();

            if (r != null)
            {
                r.ReservationConfirmed = true;
                await _context.SaveChangesAsync();
            }
            return r;
        }
    }
}
