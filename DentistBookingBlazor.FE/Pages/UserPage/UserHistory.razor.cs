
using Blazored.LocalStorage;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Bookings;
using DentistBookingBlazor.FE.Components;
using DentistBookingBlazor.FE.Services.Bookings;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages.UserPage
{
    public partial class UserHistory
    {
        [Inject]
        private ILocalStorageService ILocalStorageService { get; set; }

        [Inject]
        private IBookingService BookingService { get; set; }

        private List<BookingDTO> booking;
        private ListBookingDTOResponse response;
        private PaginationDTO paginationDTO;

        PaginationFilter paginationFilter = new();


        protected override async Task OnInitializedAsync()
        {
            await GetBookings();
        }

        private async Task GetBookings()
        {
            var savedToken = await ILocalStorageService.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(savedToken);
            var tokenS = jsonToken as JwtSecurityToken;
            var userId = tokenS.Claims.First(claim => claim.Type == "UserId").Value;

            response = await BookingService.GetBookingListForUser(paginationFilter, Guid.Parse(userId));
            booking = (List<BookingDTO>)response.Content;
            paginationDTO = response.Pagination;
        }



        private async Task SelectedPage(int page)
        {
            paginationFilter.PageNumber = page;
            await GetBookings();
        }

        public async Task OnDeleteBooking(int bookingId)
        {

            await BookingService.DeleteBookingByUser(bookingId);
            await GetBookings();


        }


    }
}
