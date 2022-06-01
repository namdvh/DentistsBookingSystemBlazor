using DentistBooking.Data.Enum;
using System;

namespace DentistBooking.ViewModels.System.Users
{
    public class RegisterRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ConfirmPassword { get; set; }
        public Gender Gender { get; set; }
    }
}
