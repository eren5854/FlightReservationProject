namespace FlightReservationProject.DTOs;

public sealed record AddRouteDto(
    string Departure,
    string Arrival,
    DateTime DepartureTime,
    DateTime ArrivalTime,
    Guid PlaneId);
