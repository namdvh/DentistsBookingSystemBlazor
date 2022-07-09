using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Bookings;
using DentistBooking.ViewModels.System.Clinics;
using DentistBooking.ViewModels.System.Services;
using DentistBookingBlazor.FE.Components;
using DentistBookingBlazor.FE.Services.Bookings;
using DentistBookingBlazor.FE.Services.Clinics;
using DentistBookingBlazor.FE.Services.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using Blazored.LocalStorage;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Components.Authorization;

namespace DentistBookingBlazor.FE.Pages.UserPage
{
    public partial class BookingCreate
    {
        [Parameter] public string InitialText { get; set; } = "Select clinic";

        [Inject]
        private ILocalStorageService ILocalStorageService { get; set; }

        [Inject]
        public ISessionStorageService sessionStorage { get; set; }
        [Inject]
        public IClinicService ClinicService { get; set; }
        [Inject]
        public IBookingService BookingService { get; set; }
        [Inject]
        public IServiceService ServiceService { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string clinicId = "";
        public DateTime OrderDate = DateTime.Parse(DateTime.Now.ToShortDateString());
        public string MinDate = DateTime.Now.ToString("yyyy-MM-dd");
        public string MaxDate = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
        List<DentistBooking.Data.Enum.KeyTime> listKeytime = new();
        List<DentistBooking.Data.Enum.KeyTime> allKeyTime = Enum.GetValues(typeof(DentistBooking.Data.Enum.KeyTime)).Cast<DentistBooking.Data.Enum.KeyTime>().ToList();
        List<int> serviceIds = new();

        protected KeyTime GetKeyTime { get; set; }

        PaginationFilter paginationFilter = new();
        ListClinicResponse clinicResponse = new();
        ListServiceResponse serviceResponse = new();
        CreateBookingRequest request;
        private int ServiceId { get; set; }

        List<ClinicDTO> clinicList = new();
        ClinicDTO chosenClinic { get; set; }
        List<ServiceDto> serviceList = new();

        public CreateBookingRequest Cart = new();


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
            if (!role.Equals("User"))
            {
                NavigationManager.NavigateTo("/Error");
            }
            await GetClinics();
            Cart = await sessionStorage.GetItemAsync<CreateBookingRequest>("cart");
            if (serviceList.Count == 0)
            {
                serviceList = await sessionStorage.GetItemAsync<List<ServiceDto>>("services");
            }
            if (clinicId.Equals(""))
            {
                chosenClinic = await sessionStorage.GetItemAsync<ClinicDTO>("clinic");
                if (chosenClinic != null)
                {
                    clinicId = chosenClinic.Id.ToString();
                }
            }


        }

        public async Task GetClinics()
        {
            clinicResponse = await ClinicService.GetClinicList(paginationFilter);
            clinicList = clinicResponse.Content as List<ClinicDTO>;
            string test = MinDate;

        }

        public async Task DoStuff(ChangeEventArgs e)
        {
            clinicId = e.Value.ToString();
            serviceResponse = await ServiceService.GetServiceListByClinic(int.Parse(clinicId));
            serviceList = serviceResponse.Content as List<ServiceDto>;
            await sessionStorage.SetItemAsync("services", serviceList);
            chosenClinic = await ClinicService.GetClinic(int.Parse(clinicId));
            await sessionStorage.SetItemAsync("clinic", chosenClinic);

        }

        public async Task OnGetKeyTime(int serviceId)
        {
            ServiceId = serviceId;
            List<DentistBooking.Data.Enum.KeyTime> listKT =await BookingService.GetPostListKeyTime(int.Parse(clinicId), serviceId, OrderDate);

            GetKeyTime.Show(listKT);

        }

        public async Task Reset()
        {
            await sessionStorage.ClearAsync();
            Cart = await sessionStorage.GetItemAsync<CreateBookingRequest>("cart");
        }

        public async Task AddKeyTime(int keytime)
        {
            var savedToken = await ILocalStorageService.GetItemAsync<string>("authToken");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(savedToken);
            var tokenS = jsonToken as JwtSecurityToken;
            var userId = tokenS.Claims.First(claim => claim.Type == "UserId").Value;

            var cart = await sessionStorage.GetItemAsync<CreateBookingRequest>("cart");
            if (cart != null)
            {
                cart.KeyTimes.Add((DentistBooking.Data.Enum.KeyTime)keytime);
                cart.ServiceIds.Add(ServiceId);

                await sessionStorage.SetItemAsync("cart", cart);
                ToastService.ShowSuccess("Add service successfully.", "Success");

            }
            else
            {
                listKeytime.Add((DentistBooking.Data.Enum.KeyTime)keytime);
                serviceIds.Add(ServiceId);
                request = new CreateBookingRequest()
                {
                    ClinicId = int.Parse(clinicId),
                    Date = OrderDate,
                    UserId = Guid.Parse(userId),
                    KeyTimes = listKeytime,
                    ServiceIds = serviceIds

                };
                await sessionStorage.SetItemAsync("cart", request);

            }
            Cart = await sessionStorage.GetItemAsync<CreateBookingRequest>("cart");



        }
    }
}
