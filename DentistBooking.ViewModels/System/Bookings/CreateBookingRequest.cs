﻿using DentistBooking.Data.Enum;
using System;
using System.Collections.Generic;

namespace DentistBooking.ViewModels.System.Bookings
{
    public class CreateBookingRequest
    {
        public List<int> DentistIds { get; set; }
        public List<int> ServiceIds { get; set; }
        public List<KeyTime> KeyTimes { get; set; }
        public Guid UserId { get; set; }
        public decimal Total { get; set; }
        public string? Note { get; set; }
    }
}
