using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Clinics;
using DentistBooking.ViewModels.System.Dentists;
using DentistBooking.ViewModels.System.Services;
using DentistBookingBlazor.FE.Services.Clinics;
using DentistBookingBlazor.FE.Services.Dentists;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages.AdminPage
{
    public partial class DentistUpdate
    {

        [Parameter]
        public string userID { get; set; }

        [Inject]
        private IDentistService DentistService { get; set; }
        [Inject]
        private IClinicService ClinicService { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public UpdateDentistRequest dentistRequest = new UpdateDentistRequest();
        public PaginationFilter paginationFilter = new();
        private ListClinicResponse responseClinic;
        private ListServiceResponse responseService;
        DentistDTO dto = new DentistDTO();

        public List<ClinicDTO> clinic = new();
        public List<ServiceDto> sevices = new();
        public int selectedClinicId = new();
        public List<int> selectedServices = new();
        public List<int> existedService = new();

        protected async override Task OnInitializedAsync()
        {
            var authenticationState = await authenticationStateTask;

            if (!authenticationState.User.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo("/Error");
            }
            dto = await DentistService.GetDentist(Guid.Parse(userID));
            await GetClinic();
            foreach (var item in dto.Services)
            {
                existedService.Add(item.Id);
                selectedServices.Add(item.Id);
            }
            selectedClinicId = dto.ClinicID;
            dentistRequest.ClinicId = dto.ClinicID;
            dentistRequest.Email = dto.Email;
            dentistRequest.Id = dto.DentistID;
            dentistRequest.UserName = dto.UserName;
            dentistRequest.Dob = dto.Dob;
            dentistRequest.Status = dto.Status;
            dentistRequest.PhoneNumber = dto.Phone;
            dentistRequest.FirstName = dto.FirstName;
            dentistRequest.LastName = dto.LastName;
            dentistRequest.Gender = dto.Gender;
            dentistRequest.Position = dto.Position;
            dentistRequest.Description = dto.Description;
            dentistRequest.UpdatedBy = Guid.Parse("d5a918c6-5ed4-43eb-bcdf-042594ae3357");
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

        private async Task UpdateDentist(EditContext context)
        {


            dentistRequest.ServiceId = selectedServices;
            dentistRequest.Id = dto.DentistID;
            var rs = await DentistService.UpdateDentist(dentistRequest);
            NavigationManager.NavigateTo("/dentist");
        }



    }
}
