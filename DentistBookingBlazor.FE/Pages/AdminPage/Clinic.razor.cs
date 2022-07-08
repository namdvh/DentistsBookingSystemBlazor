
using Blazored.LocalStorage;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Clinics;
using DentistBookingBlazor.FE.Components;
using DentistBookingBlazor.FE.Services.Clinics;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages.AdminPage
{
    public partial class Clinic
    {
        [Inject]
        private IClinicService ClinicService { get; set; }

        protected Confirmation DeleteConfirmation { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private int DeleteId { get; set; }
        [Inject]
        private ILocalStorageService ILocalStorageService { get; set; }

        private List<ClinicDTO> clinic;
        private ListClinicResponse response;
        private PaginationDTO paginationDTO;

        PaginationFilter paginationFilter = new();


        protected override async Task OnInitializedAsync()
        {
            var authenticationState = await authenticationStateTask;

            if (!authenticationState.User.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo("/Error");
            }
            var savedToken = await ILocalStorageService.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(savedToken);
            var tokenS = jsonToken as JwtSecurityToken;
            var role = tokenS.Claims.First(claim => claim.Type == "Role").Value;
            if (!role.Equals("Admin"))
            {
                NavigationManager.NavigateTo("/Error");
            }
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

        public async Task OnDeleteClinic(int deleteId, int checkStatus)
        {
            if (checkStatus != -1)
            {
                DeleteId = deleteId;
                DeleteConfirmation.Show();
            }
            else
            {
                await ClinicService.DeleteClinic(deleteId);
                await GetClinics();
            }

        }

        public async Task OnConfirmDeleteClinic(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                var rs = await ClinicService.DeleteClinic(DeleteId);

                if (rs)
                {
                    ToastService.ShowSuccess("Delete succesffuly", "Success");
                }
                else
                {
                    ToastService.ShowError("Delete Failed", "Error");
                }
                await GetClinics();
            }
        }

    }
}
