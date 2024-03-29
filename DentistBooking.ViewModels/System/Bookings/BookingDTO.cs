﻿using System;
using System.Collections.Generic;
using DentistBooking.Data.Enum;
using DentistBooking.ViewModels.System.Users;

namespace DentistBooking.ViewModels.System.Bookings
{
    public class BookingDTO
    {
        public int Id { get; set; } 
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public Status Status { get; set; } 
        public Guid UserId { get; set; }
        
        public UserDTO User { get; set; }
        public DateTime CreateAt { get; set; }
        
        public List<BookingDtoDetail> Detail { get; set; }
    }
}