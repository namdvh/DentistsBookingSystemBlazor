using DentistBooking.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DentistBooking.ViewModels.System.Clinics
{
    public class ClinicRequest
    {
        public int? Id { get; set; }
        [Required]
        [RegularExpression(@"^(?:(?! )[^0-9]*[^ 0-9])?$", ErrorMessage = "Name should not contain numbers")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^(?:(?! )[^0-9]*[^ 0-9])?$", ErrorMessage = "Description should not contain numbers")]
        public string Description { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9 _]", ErrorMessage = "Address should not contain special character")]
        public string Address { get; set; }
        [Required]

        public string Phone { get; set; }
        public Guid UserId { get; set; }


    }
}
