﻿using DentistBooking.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistBooking.Data.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Total).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Created_at).HasDefaultValueSql("getutcdate()");
            //builder.HasOne(x => x.Created_by).WithOne(x => x.Booking).HasForeignKey<User>(x=>x.BookingId);
            //builder.HasMany(x => x.BookingDetail).WithOne(x => x.Booking).HasForeignKey(x=>x.BookingId);


        }
    }
}
