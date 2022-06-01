using DentistBooking.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistBooking.Data.Configurations
{
    public class BookingDetailConfiguration : IEntityTypeConfiguration<BookingDetail>
    {
        public void Configure(EntityTypeBuilder<BookingDetail> builder)
        {
            builder.ToTable("Booking_Details");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Note).HasMaxLength(300);

            builder
                .HasOne<Booking>(x => x.Booking)
                .WithMany(x => x.BookingDetails)
                .HasForeignKey(x => x.BookingId);

            builder
                .HasOne<Service>(x => x.Service)
                .WithMany(x => x.BookingDetails)
                .HasForeignKey(x => x.ServiceId);

            builder
                .HasOne<Dentist>(x => x.Dentist)
                .WithMany(x => x.BookingDetails)
                .HasForeignKey(x => x.DentistId);

            builder.Property(x => x.Created_at).HasDefaultValueSql("getutcdate()");

        }
    }
}
