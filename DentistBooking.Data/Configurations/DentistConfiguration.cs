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
    public class DentistConfiguration : IEntityTypeConfiguration<Dentist>
    {
        public void Configure(EntityTypeBuilder<Dentist> builder)
        {
            builder.ToTable("Dentists");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                  .ValueGeneratedOnAdd();

            builder.Property(x => x.Position).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
            builder.HasOne(x => x.Clinic).WithMany(x => x.Dentists).HasForeignKey(x => x.ClinicId);
            builder.HasOne(x => x.User).WithOne(x => x.Dentist).HasForeignKey<User>(x => x.DentistId);
            //builder.HasOne(x => x.Image).WithOne(x => x.Dentist).HasForeignKey<Image>(x=>x.DentistId); 
        }

    }
}
