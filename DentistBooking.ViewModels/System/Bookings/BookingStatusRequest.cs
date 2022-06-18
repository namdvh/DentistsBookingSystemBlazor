using DentistBooking.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistBooking.ViewModels.System.Bookings
{
    public class BookingStatusRequest
    {
        [Required]
        public int bookingID { get; set; }
        [Required]
        public Status status { get; set; }
    }
}
