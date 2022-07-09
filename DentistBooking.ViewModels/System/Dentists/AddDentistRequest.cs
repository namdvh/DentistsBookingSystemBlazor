using DentistBooking.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DentistBooking.ViewModels.System.Dentists
{
    public class AddDentistRequest
    {


        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"^(?:(?! )[^0-9]*[^ 0-9])?$", ErrorMessage = "FirstName should not contain numbers")]

        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^(?:(?! )[^0-9]*[^ 0-9])?$", ErrorMessage = "LastName should not contain numbers")]

        public string LastName { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]

        public Position Position { get; set; }
        [Required]
        [RegularExpression(@"^(?:(?! )[^0-9]*[^ 0-9])?$", ErrorMessage = "Description should not contain numbers")]
        public string Description { get; set; }
        [Required]
        public int ClinicId { get; set; }

        public List<int>? ServiceId { get; set; }
    }
}