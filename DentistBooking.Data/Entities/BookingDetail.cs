﻿using DentistBooking.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistBooking.Data.Entities
{
    public class BookingDetail
    {
        public int Id { get; set; }

        public KeyTime KeyTime { get; set; }
        public string? Note { get; set; }

        public Status Status { get; set; }

        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? Deleted_at { get; set; }
        public Guid? Created_by { get; set; }
        public Guid? Deleted_by { get; set; }
        public Guid? Updated_by { get; set; }


        //Relationship

        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int? DentistId { get; set; }
        public Dentist Dentist { get; set; }
    }
}
