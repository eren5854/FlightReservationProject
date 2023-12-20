namespace FlightReservationV3.Models;

public sealed class Plane
{
    public int Id { get; set; }
    public string PlaneName { get; set; }
    public string PlaneDescription { get; set;}
    public Seat? Seat { get; set; }
    public bool IsActive { get; set; }
}