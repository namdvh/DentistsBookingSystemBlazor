using DentistBooking.Data.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace DentistBooking.ViewModels.System.Services
{
    public class ServiceRequest
    {
        public int? Id { get; set; }

        public Guid UserId { get; set; }
        [Required]
        [RegularExpression(@"^(?:(?! )[^0-9]*[^ 0-9])?$", ErrorMessage = "Name should not contain numbers")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^(?:(?! )[^0-9]*[^ 0-9])?$", ErrorMessage = "Procedure should not contain numbers")]
        public string Procedure { get; set; }
        public Status Status { get; set; }
        [Required]
        [Range(100, 500)]
        public decimal Price { get; set; }
        public int? DiscountId { get; set; }

    }
}