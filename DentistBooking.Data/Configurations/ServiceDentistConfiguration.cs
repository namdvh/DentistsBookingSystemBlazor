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
    public class ServiceDentistConfiguration : IEntityTypeConfiguration<ServiceDentist>
    {
        public void Configure(EntityTypeBuilder<ServiceDentist> builder)
        {
            builder.ToTable("ServiceDentists");
            builder.HasKey(x => new { x.ServiceId, x.DentistId });

            builder
                .HasOne<Service>(x => x.Service)
                .WithMany(x => x.ServiceDentists)
                .HasForeignKey(x => x.ServiceId);


            builder
                .HasOne<Dentist>(x => x.Dentist)
                .WithMany(x => x.ServiceDentists)
                .HasForeignKey(x => x.DentistId);
        }
    }
}
