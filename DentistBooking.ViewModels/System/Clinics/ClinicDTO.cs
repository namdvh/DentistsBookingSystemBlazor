using DentistBooking.Data.Enum;
using System;

namespace DentistBooking.ViewModels.System.Clinics
{
    public class ClinicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Status Status { get; set; }

    }
}
