namespace FlightReservationProject.DTOs;

public sealed record AddTicketDto(
    Guid RouteId,
    int SeatNumber);
