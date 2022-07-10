
using Blazored.LocalStorage;
using DentistBooking.Data.Enum;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Bookings;
using DentistBookingBlazor.FE.Components;
using DentistBookingBlazor.FE.Services.Bookings;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        [Inject]
        private ILocalStorageService ILocalStorageService { get; set; }

        [Parameter]
        public string BookingId { get; set; }

        public Status BookingStatus { get; set; }
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
            await GetDetails();
        }

        private async Task GetDetails()
        {
            response = await BookingService.GetBookingDetail(int.Parse(BookingId));
            detail = (List<BookingDetailDTO>)response.Details;
            BookingStatus = detail.First().BookingStatus;
        }

    }
}
