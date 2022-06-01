#nullable enable
using DentistBooking.Data.Enum;
using System;
using System.Collections.Generic;

namespace DentistBooking.ViewModels.System.Dentists
{
    public class UpdateDentistRequest
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        
        public DateTime? Dob { get; set; }
        //public string Password { get; set; }
       // public string ConfirmPassword { get; set; }
        
        public string? PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender? Gender { get; set; }
        public Status? Status { get; set; }
        public Position? Position { get; set; }
        public string? Description { get; set; }
        public int ClinicId { get; set; }
        public Guid UpdatedBy { get; set; }
        public List<int> ServiceId { get; set; }

    }
}