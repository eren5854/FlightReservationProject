using FlightReservationProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightReservationProject.Configurations;

public sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles");//UserRoles Adli tablo oluşturulur.
        builder.HasKey(x => new { x.UserId, x.RoleId });//birden fazla primary key vermek için bu yapı kullanılır.
    }
}