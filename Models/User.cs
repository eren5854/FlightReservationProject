using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace flightTicket.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    [Display(Name = "User Name")]
    public string Name { get; set; }
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
    [Required]
    [Display(Name = "Password")]
    public string Password { get; set; }
    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    [Required]
    [Display(Name = "Birth Date")]
    public DateTime BirthDate { get; set; }
    [Required]
    [Display(Name = "T.C. Number")]
    public string TCNo { get; set; }

}
