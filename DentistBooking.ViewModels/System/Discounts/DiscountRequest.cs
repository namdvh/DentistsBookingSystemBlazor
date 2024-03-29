﻿using DentistBooking.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistBooking.ViewModels.System.Discounts
{
    public class DiscountRequest
    {
        public int? Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]

        public DateTime StartDate { get; set; }
        [Required]

        public DateTime EndDate { get; set; }
        [Required]
        public string Description { get; set; }
        public float? Percent { get; set; }
        [Required]

        public decimal? Amount { get; set; }
        public Guid UserId { get; set; }


    }
}
