﻿using System.Collections.Generic;

namespace DentistBookingBlazor.FE.Pages
{
    public partial class ClinicEdit
    {
        public bool ShowErrors { get; set; } = false;
        public IEnumerable<string> Message { get; set; }
    }
}
