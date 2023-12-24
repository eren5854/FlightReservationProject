namespace FlightReservationProject.Models;

public sealed class Route
{
    public Route()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Departure { get; set; } = string.Empty;
    public string Arrival { get; set; } = string.Empty;
    public DateTime DepartureTime { get; set; }
    public Guid PlaneId { get; set; }
    public Plane? Plane { get; set; }
}
