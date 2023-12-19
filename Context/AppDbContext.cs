using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationProjectV2.Context;

public class AppDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=EREN-DESKTOP\\SQLEXPRESS;Initial Catalog=FlightReservationV2Db;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<CityDetail> CityDetails { get; set; }
    public DbSet<FlightDetail> FlightDetails { get; set; }
    public DbSet<PlaneDetail> PlaneDetails { get; set; }
    public DbSet<SeatDetail> SeatDetails { get; set; }
    public DbSet<UserDetail> UserDetails { get; set; }
    public DbSet<UserFlightDetail> UserFlightDetails { get; set; }
}
