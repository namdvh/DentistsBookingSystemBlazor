using DentistBooking.Data.Enum;
using System;

namespace DentistBooking.ViewModels.System.Bookings
{
    public class BookingRequest
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }

        public Status Status { get; set; }

        public Guid UserId { get; set; }
    }
}
