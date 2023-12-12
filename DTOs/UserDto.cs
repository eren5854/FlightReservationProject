using System.ComponentModel.DataAnnotations;

namespace flightTicket.DTOs;

public sealed class UserDto
{
    [Required]
    [Display(Name = "E-Mail")]
    public string Email { get; set; }
    [Required]
    [Display(Name = "Password")]
    public string Password { get; set; }

}
