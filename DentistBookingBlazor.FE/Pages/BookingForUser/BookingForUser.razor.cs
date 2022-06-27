using Blazored.LocalStorage;
using DentistBooking.Blazor.Services.Users;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Bookings;
using DentistBookingBlazor.FE.Services.Bookings;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages.BookingForUser
{
    public partial class BookingForUser
    {
        [Inject]
        private ILocalStorageService ILocalStorageService { get; set; }
        [Inject]
        private IBookingService BookingService { get; set; }
        [Inject]
        private IUserService userService { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        PaginationFilter paginationFilter = new();
        private ListBookingDTOResponse response;
        public string dentistName { get; set; }
        private PaginationDTO paginationDTO;

        private List<BookingDTO> booking;
        protected override async Task OnInitializedAsync()
        {
            var authenticationState = await authenticationStateTask;

            if (!authenticationState.User.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo("/Error");
            }
            if (!authenticationState.User.IsInRole("User"))
            {
                NavigationManager.NavigateTo("/Error");
            }
            await GetBookingForUser();
        }
        private async Task GetBookingForUser()
        {
            var savedToken = await ILocalStorageService.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(savedToken);
            var tokenS = jsonToken as JwtSecurityToken;
            var userId = tokenS.Claims.First(claim => claim.Type == "UserId").Value;
            var user = await userService.GetUser(Guid.Parse(userId));
            response = await BookingService.GetBookingListForUser(paginationFilter, Guid.Parse(userId));
            booking = (List<BookingDTO>)response.Content;
            paginationDTO = response.Pagination;
        }
        private async Task SelectedPage(int page)
        {
            paginationFilter.PageNumber = page;
            await GetBookingForUser();
        }
    }
}
