﻿using DentisBooking.Data.Entities;
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
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.ToTable("Clinics");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired()
                   .HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired()
                   .HasMaxLength(300);

            builder.Property(x => x.Address).IsRequired()
                   .HasMaxLength(500);

            builder.Property(x => x.Phone).IsRequired()
                   .HasMaxLength(15);

            builder.HasMany(x => x.Dentists)
                   .WithOne(x => x.Clinic)
                   .HasForeignKey(x => x.ClinicId);

            //builder.HasMany(x => x.Images)
            //       .WithOne(x => x.Clinic)
            //       .HasForeignKey(x => x.ClinicId);

            builder.Property(x => x.Created_at)
                   .HasDefaultValueSql("getutcdate()");
        }
    }
}
