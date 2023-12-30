namespace FlightReservationProject.DTOs;

public sealed record GetRouteDto(
    string Departure,
    string Arrival,
    DateTime Date);
