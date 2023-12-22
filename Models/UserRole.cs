﻿namespace FlightReservationProject.Models;

public sealed class UserRole
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public Guid RoleId { get; set; } = Guid.NewGuid();
}