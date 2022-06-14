﻿using DentisBooking.Data.Entities;
using DentistBooking.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistBooking.ViewModels.System.Bookings
{
    public class BookingDetailResponse
    {
        public IEnumerable<BookingDetailDTO> Details { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
