using flightTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace flightTicket.Context;

public sealed class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=EREN-DESKTOP\\SQLEXPRESS;Initial Catalog=FlightReservationV1Db;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Plane> Planes { get; set; }
    public DbSet<EconomySeat> EconomySeats { get; set; }
    public DbSet<BusinessSeat> BusinessSeats { get; set; }
}
