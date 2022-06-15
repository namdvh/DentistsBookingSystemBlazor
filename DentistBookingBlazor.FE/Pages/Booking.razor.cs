using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Clinics;
using DentistBookingBlazor.FE.Services.Bookings;
using DentistBookingBlazor.FE.Services.Clinics;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages
{
    public partial class Booking
    {
        [Inject]
        public IClinicService ClinicService { get; set; }
        public IBookingService BookingService { get; set; }

        PaginationFilter paginationFilter = new();
        ListClinicResponse clinicResponse = new();
        List<ClinicDTO> clinicList = new();

        protected override async Task OnInitializedAsync()
        {
            await GetClinics();
        }

        public async Task GetClinics()
        {
            clinicResponse = await ClinicService.GetClinicList(paginationFilter);
            clinicList = (List<ClinicDTO>)clinicResponse.Content;
  
        }
    }
}
