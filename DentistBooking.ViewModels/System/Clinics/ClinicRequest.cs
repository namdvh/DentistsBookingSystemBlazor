using DentistBooking.Data.Enum;
using System;
using System.Collections.Generic;

namespace DentistBooking.ViewModels.System.Clinics
{
    public class ClinicRequest
    {
        public int? Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Guid UserId { get; set; }


    }
}
