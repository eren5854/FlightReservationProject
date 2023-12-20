using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FlightReservationV3.Models;

public class AppUser : IdentityUser<Guid>
{
    [Required]
    [Display(Name = "Ad: ")]
    [StringLength(100)]
    public string UserFirstName { get; set; }

    [Required]
    [Display(Name = "Soyad: ")]
    [StringLength(100)]
    public string UserLastName { get; set; }
}
