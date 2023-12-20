using FlightReservationV3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel.Resolution;

namespace FlightReservationV3.Context;

public sealed class AppDbContext: IdentityDbContext<AppUser, AppRole, Guid>
{
    public AppDbContext(DbContextOptions options): base(options)
    {

    }

    public DbSet<City> Cities { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Plane> Planes { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<UserFlight> UserFlights { get; set; }
}
