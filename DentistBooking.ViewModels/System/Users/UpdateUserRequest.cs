﻿using System;
using DentistBooking.Data.Enum;

namespace DentistBooking.ViewModels.System.Users
{
    public class UpdateUserRequest
    {
        public Guid UserId { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        
        public Status Status { get; set; }
    }
}