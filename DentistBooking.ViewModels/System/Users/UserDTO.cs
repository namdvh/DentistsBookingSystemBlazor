using DentistBooking.Data.Enum;
using System;

namespace DentistBooking.ViewModels.System.Users
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
        public Status Status { get; set; }
        public string ImageUrl { get; set; }
    }
}