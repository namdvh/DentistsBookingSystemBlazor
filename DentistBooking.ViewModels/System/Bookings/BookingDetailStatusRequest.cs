using System.ComponentModel.DataAnnotations;
using DentistBooking.Data.Enum;

namespace DentistBooking.ViewModels.System.Bookings
{
    public class BookingDetailStatusRequest
    {
        [Required]
        public int bookingDetailID { get; set; }
        [Required]
        public Status status { get; set; }
    }
}