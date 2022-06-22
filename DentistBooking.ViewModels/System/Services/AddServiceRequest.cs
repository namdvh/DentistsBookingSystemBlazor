using DentistBooking.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistBooking.ViewModels.System.Services
{
    public class AddServiceRequest
    {
        public Guid UserId { get; set; }
        [Required]
        [RegularExpression(@"^\d*[a-zA-Z]{1,}\d*", ErrorMessage = "Name should not contain numbers")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^\d*[a-zA-Z]{1,}\d*", ErrorMessage = "Procedure should not contain numbers")]
        public string Procedure { get; set; }
        public Status Status { get; set; }
        [Required]
        [Range(100, 500)]
        public decimal Price { get; set; }
        public int? DiscountId { get; set; }
    }
}
