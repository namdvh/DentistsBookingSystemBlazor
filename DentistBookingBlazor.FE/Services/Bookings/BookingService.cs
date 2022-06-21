using DentistBooking.Data.Enum;
using DentistBooking.ViewModels.Pagination;
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

        public async Task<bool> DeleteBookingByUser(int bookingId)
        {
            var result = await _httpClient.DeleteAsync($"/api/bookings/{bookingId}");
            return result.IsSuccessStatusCode;
        }

        public async Task<BookingDetailResponse> GetBookingDetail(int bookingId)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["bookingId"] = bookingId.ToString()
            };
            var url = QueryHelpers.AddQueryString("/api/bookings/getbookingdetail", queryStringParam);
            var rs = await _httpClient.GetFromJsonAsync<BookingDetailResponse>(url);
            return rs;
        }

        public async Task<ListBookingResponse> GetBookingList(PaginationFilter filter)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["PageNumber"] = filter.PageNumber.ToString(),
                ["PageSize"] = filter.PageSize.ToString(),
            };

            var url = QueryHelpers.AddQueryString("/api/bookings/getallbooking", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<ListBookingResponse>(url);

            return result;
        }

        public async Task<ListBookingDTOResponse> GetBookingListForDentist(PaginationFilter filter, int dentistId)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["PageNumber"] = filter.PageNumber.ToString(),
                ["PageSize"] = filter.PageSize.ToString(),
            };

            var url = QueryHelpers.AddQueryString($"/api/bookings/dentist/{dentistId}", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<ListBookingDTOResponse>(url);

            return result;
        }

        public async Task<ListBookingDTOResponse> GetBookingListForUser(PaginationFilter filter, Guid userId)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["PageNumber"] = filter.PageNumber.ToString(),
                ["PageSize"] = filter.PageSize.ToString(),
            };

            var url = QueryHelpers.AddQueryString($"/api/bookings/{userId}", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<ListBookingDTOResponse>(url);
            return result;
        }

        public async Task<BookingDetailResponse> GetDetailByDentistAndBooking(int dentistId, int bookingId)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["dentistId"] = dentistId.ToString(),
                ["bookingId"] = bookingId.ToString(),
            };

            var url = QueryHelpers.AddQueryString($"/api/bookings/detaildentist", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<BookingDetailResponse>(url);
            return result;
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

        public async Task<bool> UpdateBooking(BookingRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync("/api/bookings", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateBookingDetailStatus(BookingDetailStatusRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync("/api/bookings/detail/status", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateBookingStatus(BookingStatusRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync("/api/bookings/status", request);
            return result.IsSuccessStatusCode;

        }

    }
}
