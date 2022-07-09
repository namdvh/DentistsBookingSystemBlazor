using System;
using System.ComponentModel.DataAnnotations;
using DentistBooking.Data.Enum;

namespace DentistBooking.ViewModels.System.Users
{
    public class UpdateUserRequest
    {
        public Guid UserId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_]+( [a-zA-Z0-9_]+)*$", ErrorMessage = "FirstName should not contain numbers")]

        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_]+( [a-zA-Z0-9_]+)*$", ErrorMessage = "LastName should not contain numbers")]

        public string LastName { get; set; }
        [Required]

        public DateTime DOB { get; set; }
        [Required]
        [EmailAddress]

        public string Email { get; set; }
        [Required]

        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }

    }
}