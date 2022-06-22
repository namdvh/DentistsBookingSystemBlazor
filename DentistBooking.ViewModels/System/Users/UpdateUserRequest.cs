using System;
using System.ComponentModel.DataAnnotations;
using DentistBooking.Data.Enum;

namespace DentistBooking.ViewModels.System.Users
{
    public class UpdateUserRequest
    {
        public Guid UserId { get; set; }

        [Required]
        [RegularExpression(@"^\d*[a-zA-Z]{1,}\d*", ErrorMessage = "FirstName should not contain numbers")]

        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^\d*[a-zA-Z]{1,}\d*", ErrorMessage = "LastName should not contain numbers")]

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