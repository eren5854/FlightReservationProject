namespace FlightReservationV3.Models;

public class Flight
{
    public int Id { get; set; }
    public string? FlightNumber { get; set; }
    public City? City1 { get; set; }
    public City? City2 { get; set; }
    public Plane? Plane { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ReturnDate { get; set; }
}
