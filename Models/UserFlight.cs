namespace FlightReservationV3.Models;

public sealed class UserFlight
{
    public int Id { get; set; }
    public AppUser? User { get; set; }
    public Flight? Flight { get; set; }
    public string PNR { get; set; }
}
