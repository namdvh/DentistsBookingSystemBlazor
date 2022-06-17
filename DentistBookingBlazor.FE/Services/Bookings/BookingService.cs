using DentistBooking.Data.Enum;
using DentistBooking.ViewModels.System.Bookings;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Services.Bookings
{
    public class BookingService : IBookingService
    {
        private readonly HttpClient _httpClient;

        public BookingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateBooking(CreateBookingRequest request)
        {
            var rs = await _httpClient.PostAsJsonAsync("/api/bookings", request);

            return rs.IsSuccessStatusCode;
        }

        public async Task<List<KeyTime>> GetPostListKeyTime(int clinicId, int serviceId, DateTime date)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["clinicId"] = clinicId.ToString(),
                ["serviceId"] = serviceId.ToString(),
                ["date"] = date.ToString()
            };

            var url = QueryHelpers.AddQueryString("/api/bookings/getUnavailableKeyTime", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<KeyTime>>(url);

            return result;

        }
    }
}
