namespace Caravans.Models
{
    public class ReservationCaravan
    {
        public virtual Reservation Reservation { get; set; }
        public virtual Caravan Caravan { get; set; }
        public virtual Caravanmodel Caravanmodel { get; set; }
    }
}
