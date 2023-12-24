﻿using FlightReservationProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightReservationProject.Configurations;

public sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(50)");
        builder.HasIndex(x => x.Name).IsUnique();
    }
}
