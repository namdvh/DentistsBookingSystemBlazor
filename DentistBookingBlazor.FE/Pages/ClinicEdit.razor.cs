using System.Collections.Generic;

namespace DentistBookingBlazor.FE.Pages
{
    public partial class ClinicCreate
    {
        public bool ShowErrors { get; set; } = false;
        public IEnumerable<string> Message { get; set; }
    }
}
