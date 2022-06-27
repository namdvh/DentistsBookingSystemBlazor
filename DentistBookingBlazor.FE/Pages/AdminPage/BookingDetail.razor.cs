
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
    public partial class BookingDetail
    {
        [Inject]
        private IBookingService BookingService { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private List<BookingDetailDTO> detail;
        private BookingDetailResponse response;
        [Parameter]
        public string BookingId { get; set; }
        protected override async Task OnInitializedAsync()
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
            await GetDetails();
        }

        private async Task GetDetails()
        {
            response = await BookingService.GetBookingDetail(int.Parse(BookingId));
            detail = (List<BookingDetailDTO>)response.Details;
        }

    }
}
