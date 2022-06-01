using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistBooking.Data.Entities
{
    public class ServiceDentist
    {
        public int DentistId { get; set; }

        public Dentist Dentist { get; set; }

        public int ServiceId { get; set; }

        public Service Service { get; set; }


    }
}
