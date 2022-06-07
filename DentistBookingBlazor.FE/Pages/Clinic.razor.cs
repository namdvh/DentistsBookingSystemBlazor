﻿
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Clinics;
using DentistBookingBlazor.FE.Services.Clinics;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages
{
    public partial class Clinic
    {
        [Inject] 
        private IClinicService ClinicService { get; set; }

        private List<ClinicDTO> clinic;
        private ListClinicResponse response;
        private PaginationDTO paginationDTO;

        PaginationFilter paginationFilter = new();


        protected override async Task OnInitializedAsync()
        {
            await GetClinics();
        }

        private async Task GetClinics()
        {
            response = await ClinicService.GetClinicList(paginationFilter);
            clinic = (List<ClinicDTO>)response.Content;
            paginationDTO = response.Pagination;
        }



        private async Task SelectedPage(int page)
        {
            paginationFilter.PageNumber = page;
            await GetClinics();
        }
    }
}