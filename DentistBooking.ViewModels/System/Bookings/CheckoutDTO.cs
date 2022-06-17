using DentistBooking.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistBooking.ViewModels.System.Bookings
{
    public class CheckoutDTO
    {
        public string ServiceNames { get; set; }
        public KeyTime KeyTimes { get; set; }
        public decimal Price { get; set; }
    }
}
