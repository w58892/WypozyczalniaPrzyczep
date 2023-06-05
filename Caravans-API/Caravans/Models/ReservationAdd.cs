using System.ComponentModel.DataAnnotations;

namespace Caravans.Models
{
    public partial class ReservationAdd
    {

        [Required]
        public DateTime Begin { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ModelId { get; set; }
    }
}
