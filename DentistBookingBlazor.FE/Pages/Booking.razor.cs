using Blazored.LocalStorage;
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

namespace DentistBookingBlazor.FE.Pages
{
    public partial class Booking
    {
        [Parameter] public string InitialText { get; set; } = "Select clinic";
        private readonly ISyncLocalStorageService _localStorage;


        [Inject]
        public IClinicService ClinicService { get; set; }
        [Inject]
        public IBookingService BookingService { get; set; }
        [Inject]
        public IServiceService ServiceService { get; set; }

        public string clinicId;
        public DateTime Date;
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



        protected override async Task OnInitializedAsync()
        {
            await GetClinics();
        }

        public async Task GetClinics()
        {
            clinicResponse = await ClinicService.GetClinicList(paginationFilter);
            clinicList = clinicResponse.Content as List<ClinicDTO>;

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

        public void AddKeyTime(int keytime)
        {
            var cart =  _localStorage.GetItem<CreateBookingRequest>("cart");
            if(cart != null)
            {
                request.KeyTimes.Add((DentistBooking.Data.Enum.KeyTime)keytime);
                request.ServiceIds.Add(ServiceId);
            }
            else
            {
                listKeytime.Add((DentistBooking.Data.Enum.KeyTime)keytime);
                serviceIds.Add(ServiceId);
                request = new CreateBookingRequest()
                {
                    ClinicId = int.Parse(clinicId),
                    Date = Date,
                    UserId = Guid.NewGuid(),
                    KeyTimes = listKeytime,
                    ServiceIds = serviceIds
                };
            }
             _localStorage.SetItem("cart", request);

            // lay keytime qua cart
            
        }
    }
}
