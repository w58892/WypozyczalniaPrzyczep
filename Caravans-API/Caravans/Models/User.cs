using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Caravans.Models;

public partial class User
{
    [Key]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "Imię jest wymagane")]
    [MaxLength(50, ErrorMessage = "Imię nie może być dłuższe niż 50 znaków")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Nazwisko jest wymagane")]
    [MaxLength(50, ErrorMessage = "Nazwisko nie może być dłuższe niż 50 znaków")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "E-mail jest wymagany")]
    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Nieprawidłowy e-mail")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Hasło nie może być puste")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Hasło musi zawierać conajmiej 8 znaków w tym duże litery i znaki specjalne")]
    public string Password { get; set; }

    [JsonIgnore]
    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
