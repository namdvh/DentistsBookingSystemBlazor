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

namespace DentistBookingBlazor.FE.Pages.UserPage
{
    public partial class BookingCreate
    {
        [Parameter] public string InitialText { get; set; } = "Select clinic";
        [Inject]
        public ISessionStorageService sessionStorage { get; set; }
        [Inject]
        public IClinicService ClinicService { get; set; }
        [Inject]
        public IBookingService BookingService { get; set; }
        [Inject]
        public IServiceService ServiceService { get; set; }

        public string clinicId;
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
        List<ServiceDto> serviceList = new();

        public CreateBookingRequest Cart { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await GetClinics();

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
        }

        public async Task OnGetKeyTime(int serviceId)
        {
            ServiceId = serviceId;
            GetKeyTime.Show();

        }

        public async Task Reset()
        {
            await sessionStorage.ClearAsync();
            Cart = await sessionStorage.GetItemAsync<CreateBookingRequest>("cart");
        }

        public async Task AddKeyTime(int keytime)
        {
            var cart = await sessionStorage.GetItemAsync<CreateBookingRequest>("cart");
            if (cart != null)
            {
                cart.KeyTimes.Add((DentistBooking.Data.Enum.KeyTime)keytime);
                cart.ServiceIds.Add(ServiceId);

                await sessionStorage.SetItemAsync("cart", cart);

            }
            else
            {
                listKeytime.Add((DentistBooking.Data.Enum.KeyTime)keytime);
                serviceIds.Add(ServiceId);
                request = new CreateBookingRequest()
                {
                    ClinicId = int.Parse(clinicId),
                    Date = OrderDate,
                    UserId = Guid.Parse("d5a918c6-5ed4-43eb-bcdf-042594ae2644"),
                    KeyTimes = listKeytime,
                    ServiceIds = serviceIds

                };
                await sessionStorage.SetItemAsync("cart", request);

            }
            Cart = await sessionStorage.GetItemAsync<CreateBookingRequest>("cart");



        }
    }
}
