using System.ComponentModel.DataAnnotations;

namespace flightTicket.Models;

public class EconomySeat
{
    [Key]
    public int EconomySeatId { get; set; }
    public string Number { get; set; }
    public bool IsEmpty { get; set; }
}
