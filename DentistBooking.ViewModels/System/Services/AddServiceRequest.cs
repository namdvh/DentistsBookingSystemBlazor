﻿using DentistBooking.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistBooking.ViewModels.System.Services
{
    public class AddServiceRequest
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Procedure { get; set; }
        public Status Status { get; set; }
        public decimal Price { get; set; }
        public int? DiscountId { get; set; }
    }
}
