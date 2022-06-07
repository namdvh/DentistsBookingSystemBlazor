

using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Clinics;
using DentistBooking.ViewModels.System.Dentists;
using DentistBookingBlazor.FE.Services.Clinics;
using DentistBookingBlazor.FE.Services.Dentists;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages
{
    public partial class DentistCreate
    {

        [Inject]
        private IDentistService DentistService { get; set; }
        [Inject]
        private IClinicService ClinicService { get; set; }

        public AddDentistRequest dentist = new AddDentistRequest();

        public List<ClinicDTO> clinic = new();
        private PaginationFilter paginationFilter = new();

        private ListClinicResponse responseClinic;

        protected async override Task OnInitializedAsync()
        {
            await GetClinic();
        }

        private async Task GetClinic()
        {
            responseClinic = await ClinicService.GetClinicList(paginationFilter);
            clinic = responseClinic.Content as List<ClinicDTO>;
        }
    }
}
