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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.HasMany(x => x.Bookings).WithOne(x => x.Created_by).HasForeignKey(x => x.UserId);
            //builder.HasOne(x => x.Image).WithOne(x => x.User).HasForeignKey<Image>(x=>x.UserId);
            builder.Property(x => x.Created_at).HasDefaultValueSql("getutcdate()");
        }
    }
}
