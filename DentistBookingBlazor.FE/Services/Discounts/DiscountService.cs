using DentistBooking.Data.Entities;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Discounts;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Services.Discounts
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateDiscount(DiscountRequest request)
        {
            var rs = await _httpClient.PostAsJsonAsync("/api/discounts", request);

            return rs.IsSuccessStatusCode;

        }

        public async Task<bool> DeleteDiscount(int discountId)
        {
            var result = await _httpClient.DeleteAsync($"/api/discounts/{discountId}");
            return result.IsSuccessStatusCode;
        }

        public async Task<DiscountDTO> GetDiscount(int? discountId)
        {
            var rs = await _httpClient.GetFromJsonAsync<DiscountDTO>($"/api/discounts/{discountId}");
            return rs;
        }

        public async Task<ListDiscountResponse> GetDiscountList(PaginationFilter filter)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["PageNumber"] = filter.PageNumber.ToString(),
                ["PageSize"] = filter.PageSize.ToString(),
            };

            var url = QueryHelpers.AddQueryString("/api/discounts", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<ListDiscountResponse>(url);

            return result;
        }

        public async Task<bool> UpdateDiscount(DiscountRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync("/api/discounts", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> ApplyForAll(int discountId)
        {
            var result = await _httpClient.DeleteAsync($"/api/discounts/apply/{discountId}");
            return result.IsSuccessStatusCode;

        }
    }
}
