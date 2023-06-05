using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Caravans.Models;

public partial class Reservation
{
    [Key]
    public Guid ReservationId { get; set; }

    [Required]
    public DateTime ReservationDate { get; set; }

    [Required]
    public DateTime ReservationBegin { get; set; }

    [Required] 
    public DateTime ReservationEnd { get; set; }

    [Required] 
    public Guid UserId { get; set; }

    [Required] 
    public Guid CaravanId { get; set; }

    public bool ReservationConfirmed { get; set; } = false;

    [JsonIgnore]
    public virtual Caravan Caravan { get; set; }

    [JsonIgnore]
    public virtual User User { get; set; }
}
