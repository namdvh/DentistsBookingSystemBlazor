using Blazored.LocalStorage;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Dentists;
using DentistBookingBlazor.FE.Components;
using DentistBookingBlazor.FE.Services.Dentists;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages.AdminPage
{
    public partial class Dentist
    {
        [Inject]
        private IDentistService DentistService { get; set; }

        private List<DentistDTO> dentist;
        private DentistResponse response;
        private PaginationDTO paginationDTO;
        PaginationFilter paginationFilter = new();
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }
        [Inject]
        private ILocalStorageService ILocalStorageService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected Confirmation DeleteConfirmation { get; set; }

        private int DeleteId { get; set; }


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
            await GetDentists();
        }

        private async Task GetDentists()
        {
            response = await DentistService.GetDentistList(paginationFilter);
            dentist = (List<DentistDTO>)response.Content;
            paginationDTO = response.Pagination;
        }



        private async Task SelectedPage(int page)
        {
            paginationFilter.PageNumber = page;
            await GetDentists();
        }

        public async Task OnDeleteDentist(int deleteId, int checkStatus)
        {
            if (checkStatus != -1)
            {
                DeleteId = deleteId;
                DeleteConfirmation.Show();
            }
            else
            {
                await DentistService.DeleteDentist(deleteId);
                await GetDentists();
            }

        }

        public async Task OnConfirmDeleteDentist(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                var rs = await DentistService.DeleteDentist(DeleteId);

                if (rs)
                {
                    ToastService.ShowSuccess("Delete succesffuly", "Success");
                }
                else
                {
                    ToastService.ShowError("Delete Failed", "Error");
                }

                await GetDentists();
            }
        }

    }
}
