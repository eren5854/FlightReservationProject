using FlightReservationProject.Models;

namespace FlightReservationProject.DTOs;

public sealed record RouteDto
{
    public IEnumerable<Route> Routes { get; set; } = new List<Route>();
    public IEnumerable<Plane> Planes { get; set; } = new List<Plane>();
    public IEnumerable<Ticket> Ticket { get; set; } = new List<Ticket>();
}
