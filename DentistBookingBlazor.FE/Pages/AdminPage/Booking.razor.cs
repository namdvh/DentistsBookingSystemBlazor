
using DentistBooking.Data.Enum;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Bookings;
using DentistBookingBlazor.FE.Components;
using DentistBookingBlazor.FE.Services.Bookings;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages.AdminPage
{
    public partial class Booking
    {
        [Inject]
        private IBookingService BookingService { get; set; }



        private List<BookingDTO> booking;
        private ListBookingResponse response;
        private PaginationDTO paginationDTO;
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public BookingStatusRequest request { get; set; }
        protected Confirmation ActionConfirmation { get; set; }
        public int ActionID { get; set; }
        public Status Status { get; set; }


        PaginationFilter paginationFilter = new();


        protected override async Task OnInitializedAsync()
        {
            await GetBookings();
        }

        private async Task GetBookings()
        {
            var authenticationState = await authenticationStateTask;

            if (!authenticationState.User.Identity.IsAuthenticated)
            {
                NavigationManager.NavigateTo("/Error");
            }
            if (!authenticationState.User.IsInRole("Admin"))
            {
                NavigationManager.NavigateTo("/Error");
            }
            response = await BookingService.GetBookingList(paginationFilter);
            booking = (List<BookingDTO>)response.Content;
            paginationDTO = response.Pagination;
        }



        private async Task SelectedPage(int page)
        {
            paginationFilter.PageNumber = page;
            await GetBookings();
        }

        public async Task OnConfirm(int id, Status status)
        {

            ActionID = id;
            Status = status;
            ActionConfirmation.Show();

        }

        public async Task OnConfirmAction(bool actionConfirmed)
        {
            if (actionConfirmed)
            {
                request = new();

                if (Status == Status.CONFIRMED)
                {
                    request.bookingID = ActionID;
                    request.status = Status;
                }
                else
                {
                    request.bookingID = ActionID;
                    request.status = Status;
                }

                await bookingService.UpdateBookingStatus(request);
                ToastService.ShowSuccess("Update successfully.", "Success");
                await GetBookings();


            }
        }

    }
}
