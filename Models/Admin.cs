using System.ComponentModel.DataAnnotations;

namespace flightTicket.Models;

public sealed class Admin
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Display(Name = "E-Mail: ")]
    public string Email { get; set; }
    [Required]
    [Display(Name = "Password: ")]
    public string Password { get; set; }

}
