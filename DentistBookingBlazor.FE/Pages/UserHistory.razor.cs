
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Bookings;
using DentistBookingBlazor.FE.Components;
using DentistBookingBlazor.FE.Services.Bookings;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages
{
    public partial class UserHistory
    {
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
            response = await BookingService.GetBookingListForUser(paginationFilter, Guid.Parse("d5a918c6-5ed4-43eb-bcdf-042594ae2644"));
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
