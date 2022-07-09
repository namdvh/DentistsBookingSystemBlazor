#nullable enable
using DentistBooking.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DentistBooking.ViewModels.System.Dentists
{
    public class UpdateDentistRequest
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public DateTime? Dob { get; set; }
        [Required]

        public string? PhoneNumber { get; set; }
        [RegularExpression(@"^(?:(?! )[^0-9]*[^ 0-9])?$", ErrorMessage = "FirstName should not contain numbers")]

        public string? FirstName { get; set; }
        [RegularExpression(@"^(?:(?! )[^0-9]*[^ 0-9])?$", ErrorMessage = "FirstName should not contain numbers")]

        [Required]

        public string? LastName { get; set; }

        public Gender? Gender { get; set; }
        public Status? Status { get; set; }
        public Position? Position { get; set; }
        [Required]
        [RegularExpression(@"^(?:(?! )[^0-9]*[^ 0-9])?$", ErrorMessage = "Desciption should not contain numbers")]

        public string? Description { get; set; }
        public int ClinicId { get; set; }
        public Guid UpdatedBy { get; set; }
        public List<int> ServiceId { get; set; }

    }
}