using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Caravans.Models;

public partial class Caravan
{
    [Key]
    public Guid CaravanId { get; set; }

    [Required]
    [MaxLength(7, ErrorMessage = "Tablica rejestracyjna nie może mieć więcej niż 7 znaków")]
    public string NumberPlate { get; set; }

    [Required]
    public Guid ModelId { get; set; }

    [JsonIgnore]
    public virtual Caravanmodel Model { get; set; }

    [JsonIgnore]
    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
