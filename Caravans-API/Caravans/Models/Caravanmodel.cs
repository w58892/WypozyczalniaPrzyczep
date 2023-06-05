using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Caravans.Models;

public partial class Caravanmodel
{
    [Key]
    public Guid ModelId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Producer { get; set; }

    [Required]
    [MaxLength(50)]
    public string Model { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required] 
    public int Weight { get; set; }

    [Required] 
    public int Length { get; set; }

    [Required] 
    public int LengthInside { get; set; }

    [Required] 
    public int Width { get; set; }

    [Required] 
    public int WidthInside { get; set; }

    [Required] 
    public int People { get; set; }

    [Required] 
    public int Water { get; set; }

    [Required] 
    public bool HotWater { get; set; }

    [Required] 
    public bool Shower { get; set; }

    [Required] 
    public bool Fridge { get; set; }

    [Required]
    [MaxLength(100)]
    public string Picture { get; set; }

    [JsonIgnore]
    public virtual ICollection<Caravan> Caravans { get; } = new List<Caravan>();
}
