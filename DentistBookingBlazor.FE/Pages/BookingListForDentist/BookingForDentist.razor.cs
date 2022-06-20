using Blazored.LocalStorage;
using DentistBooking.Blazor.Services.Users;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Bookings;
using DentistBookingBlazor.FE.Services.Bookings;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
namespace DentistBookingBlazor.FE.Pages.BookingListForDentist
{
    public partial class BookingForDentist
    {

        [Inject]
        private ILocalStorageService ILocalStorageService { get; set; }
        [Inject]
        private IBookingService BookingService { get; set; }
        [Inject]
        private IUserService userService { get; set; }
        PaginationFilter paginationFilter = new();
        private ListBookingDTOResponse response;
        public string dentistName { get; set; }
        private PaginationDTO paginationDTO;

        private List<BookingDTO> booking;

        protected override async Task OnInitializedAsync()
        {
            await GetBookingForDentist();
        }
        private async Task GetBookingForDentist()
        {
            var savedToken = await ILocalStorageService.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(savedToken);
            var tokenS = jsonToken as JwtSecurityToken;
            var userId = tokenS.Claims.First(claim => claim.Type == "UserId").Value;
            var dentist = await userService.GetUser(Guid.Parse(userId));
            dentistName = dentist.FirstName;
            response = await BookingService.GetBookingListForDentist(paginationFilter, (int)dentist.DentistId);
            booking = (List<BookingDTO>)response.Content;
            paginationDTO = response.Pagination;
        }
        private async Task SelectedPage(int page)
        {
            paginationFilter.PageNumber = page;
            await GetBookingForDentist();
        }
    }
}