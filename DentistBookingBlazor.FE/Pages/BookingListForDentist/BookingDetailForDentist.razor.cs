using Blazored.LocalStorage;
using DentistBooking.Blazor.Services.Users;
using DentistBooking.Data.Enum;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Bookings;
using DentistBookingBlazor.FE.Components;
using DentistBookingBlazor.FE.Services.Bookings;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Pages.BookingListForDentist
{
    public partial class BookingDetailForDentist
    {
        [Inject]
        private IBookingService BookingService { get; set; }

        [Inject]
        private ILocalStorageService ILocalStorageService { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private List<BookingDetailDTO> detail { get; set; }
        private BookingDetailResponse response;
        private IUserService userService { get; set; }
        PaginationFilter paginationFilter = new();
        [Parameter]
        public string BookingId { get; set; }
        [Parameter]
        public string dentistId { get; set; }
        protected Confirmation ActionConfirmation { get; set; }
        public int ActionID { get; set; }
        public Status Status { get; set; }
        public BookingDetailStatusRequest request { get; set; }
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
            if (!role.Equals("Docter"))
            {
                NavigationManager.NavigateTo("/Error");
            }
            await GetDetails();
        }

        private async Task GetDetails()
        {
            response = await BookingService.GetDetailByDentistAndBooking(int.Parse(dentistId), int.Parse(BookingId));
            detail = new();
            detail = (List<BookingDetailDTO>)response.Details;
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
                    request.bookingDetailID = ActionID;
                    request.status = Status;
                }
                else
                {
                    request.bookingDetailID = ActionID;
                    request.status = Status;
                }

                await BookingService.UpdateBookingDetailStatus(request);
                ToastService.ShowSuccess("Update booking successfully.", "Success");
                await GetDetails();

            }
        }
    }
}
