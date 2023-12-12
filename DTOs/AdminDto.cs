using System.ComponentModel.DataAnnotations;

namespace flightTicket.DTOs;

public sealed class AdminDto
{
    public string Name { get; set; }
    [Required]
    [Display(Name = "E-Mail")]
    public string Email { get; set; }
    [Required]
    [Display(Name = "Password")]
    public string Password { get; set; }
}
