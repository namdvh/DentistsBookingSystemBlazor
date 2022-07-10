using System.Collections.Generic;
using DentistBooking.Data.Enum;
using DentistBooking.ViewModels.System.Dentists;
using DentistBooking.ViewModels.System.Services;

namespace DentistBooking.ViewModels.System.Bookings
{
    public class BookingDetailDTO
    {
        public int Id { get; set; }

        public KeyTime KeyTime { get; set; }
        public string? Note { get; set; }
        public string DentistName { get; set; }

        public Status Status { get; set; }
        public DentistServiceDto Services { get; set; }


    }
}