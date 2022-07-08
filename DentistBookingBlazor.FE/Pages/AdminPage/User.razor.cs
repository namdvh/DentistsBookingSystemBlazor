
using Blazored.LocalStorage;
using DentistBooking.Blazor.Services.Users;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Users;
using DentistBookingBlazor.FE.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages.AdminPage
{
    public partial class User
    {
        [Inject]
        private IUserService UserService { get; set; }

        protected Confirmation DeleteConfirmation { get; set; }

        private string DeleteId { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        private ILocalStorageService ILocalStorageService { get; set; }

        private List<UserDTO> user;
        private ListUserResponse response;
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
            await GetUsers();
        }

        private async Task GetUsers()
        {
            response = await UserService.GetUserList(paginationFilter);
            user = (List<UserDTO>)response.Content;
            paginationDTO = response.Pagination;
        }



        private async Task SelectedPage(int page)
        {
            paginationFilter.PageNumber = page;
            await GetUsers();
        }

        public async Task OnDeleteUser(string deleteId, int checkStatus)
        {
            if (checkStatus != -1)
            {
                DeleteId = deleteId;
                DeleteConfirmation.Show();
            }
            else
            {
                await UserService.DeleteUser(Guid.Parse(deleteId));
                await GetUsers();
            }

        }

        public async Task OnConfirmDeleteUser(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                var rs = await UserService.DeleteUser(Guid.Parse(DeleteId));
                if (rs)
                {
                    ToastService.ShowSuccess("Delete successfully", "Success");
                }
                else
                {
                    ToastService.ShowError("Delete failed", "Error");

                }
                await GetUsers();
            }
        }
    }
}
