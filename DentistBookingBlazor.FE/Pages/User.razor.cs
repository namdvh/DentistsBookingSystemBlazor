
using DentistBooking.Blazor.Services.Users;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Users;
using DentistBookingBlazor.FE.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages
{
    public partial class User
    {
        [Inject]
        private IUserService UserService { get; set; }

        protected Confirmation DeleteConfirmation { get; set; }

        private string DeleteId { get; set; }

        private List<UserDTO> user;
        private ListUserResponse response;
        private PaginationDTO paginationDTO;

        PaginationFilter paginationFilter = new();


        protected override async Task OnInitializedAsync()
        {
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
                await UserService.DeleteUser(Guid.Parse(DeleteId));
                await GetUsers();
            }
        }
    }
}
