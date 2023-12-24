using FlightReservationProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightReservationProject.Configurations;

public sealed class PlaneConfiguration : IEntityTypeConfiguration<Plane>
{
    public void Configure(EntityTypeBuilder<Plane> builder)
    {
        builder.ToTable("Planes");//Planes adli tablo oluşturulur.

        //Planes Tablosunun sütun ayarları.
        builder.Property(p => p.TailNumber).IsRequired().HasColumnType("varchar(50)");
        builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(50)");
        builder.Property(p => p.TotalSeats).IsRequired();
        builder.Property(p => p.SeatConfiguration).IsRequired().HasColumnType("varchar(5)");

        builder.HasIndex(x => x.TailNumber).IsUnique();//Uçağın kuyruk numarası aynı isimle birden fazla kayıt olmaması için Unique yapılır.
    }
}
