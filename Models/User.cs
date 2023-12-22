namespace FlightReservationProject.Models;

public sealed class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

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

}

public sealed class Plane
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string TailNumber { get; set; } = string.Empty;
    public int TotalSeats { get; set; } = 0;
    public string SeatConfiguration {  get; set; } = string.Empty;
}