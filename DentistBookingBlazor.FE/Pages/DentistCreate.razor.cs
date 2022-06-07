﻿

using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Clinics;
using DentistBooking.ViewModels.System.Dentists;
using DentistBooking.ViewModels.System.Services;
using DentistBookingBlazor.FE.Services.Clinics;
using DentistBookingBlazor.FE.Services.Dentists;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
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
        public PaginationFilter paginationFilter = new();
        private ListClinicResponse responseClinic;
        private ListServiceResponse responseService;

        public List<ClinicDTO> clinic = new();
        public List<ServiceDto> sevices = new();
        public List<int> selectedServices = new();

        protected async override Task OnInitializedAsync()
        {
            await GetClinic();
            await GetServices();

        }

        private async Task GetClinic()
        {
            responseClinic = await ClinicService.GetClinicList(paginationFilter);
            clinic = responseClinic.Content as List<ClinicDTO>;
        }

        private async Task GetServices()
        {
            responseService = await DentistService.GetServices(paginationFilter);
            sevices = responseService.Content as List<ServiceDto>;
        }

        void CheckboxClicked(int CheckID, object checkedValue)
        {
            if ((bool)checkedValue)
            {
                if (!selectedServices.Contains(CheckID))
                {
                    selectedServices.Add(CheckID);
                }
            }
            else
            {
                if (selectedServices.Contains(CheckID))
                {
                    selectedServices.Remove(CheckID);
                }
            }
        }

        private async Task SubmitDentist(EditContext context)
        {


            dentist.ServiceId = selectedServices;
            var rs = await dentisttService.CreateDentist(dentist);
            NavigationManager.NavigateTo("/dentist");
        }
    }
}
