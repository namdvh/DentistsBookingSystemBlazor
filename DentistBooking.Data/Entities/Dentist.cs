using DentisBooking.Data.Entities;
using DentistBooking.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistBooking.Data.Entities
{
    public class Dentist
    {
        public int Id { get; set; }
        public Position Position { get; set; }
        public string Description { get; set; }
        public ICollection<BookingDetail> BookingDetails { get; set; }
        public User User { get; set; }
        public ICollection<ServiceDentist> ServiceDentists { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}
