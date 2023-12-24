using FlightReservationProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightReservationProject.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");// Users adli tablo oluşturulur.

        //Users Tablosunun sütun ayarları.
        builder.Property(p => p.FirstName).IsRequired().HasColumnType("varchar(100)");
        builder.Property(p => p.LastName).IsRequired().HasColumnType("varchar(100)");
        builder.Property(p => p.Email).IsRequired().HasColumnType("varchar(200)");
        builder.Property(p => p.Password).IsRequired().HasColumnType("varchar(50)");

        builder.HasIndex(x => x.Email).IsUnique();//Email aynı isimle birden fazla kayıt olmaması için Unique yapılır.
    }
}
