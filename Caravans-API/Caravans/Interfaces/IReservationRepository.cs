using Caravans.Models;

namespace Caravans.Interfaces
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAll();
        Task<Reservation> Get(Guid id);
        Task<Reservation> Add(Reservation reservation);
        Task<Reservation> Update(Reservation reservation);
        Task Delete(Reservation reservation);
        Task<byte[]> GetPdf(Reservation reservation);
        Task<Reservation> ConfirmReservation(Guid id);
        Task<IEnumerable<ReservationCaravan>> GetByUser(Guid userId);
        Task<Guid> AvailableCaravan(ReservationAdd reservation);

    }
}
