using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Services;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Services.Services
{
    public class ServiceService:IServiceService
    {
        private readonly HttpClient _httpClient;

        public ServiceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateService(AddServiceRequest request)
        {
            var rs = await _httpClient.PostAsJsonAsync("/api/services", request);

            return rs.IsSuccessStatusCode;

        }

        public async Task<bool> DeleteService(int serviceId)
        {
            var result = await _httpClient.DeleteAsync($"/api/services/{serviceId}");
            return result.IsSuccessStatusCode;
        }

        public async Task<ServiceDto> GetService(int serviceId)
        {
            var rs = await _httpClient.GetFromJsonAsync<ServiceDto>($"/api/services/{serviceId}");
            return rs;
        }

        public async Task<ListServiceResponse> GetServiceList(PaginationFilter filter)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["PageNumber"] = filter.PageNumber.ToString(),
                ["PageSize"] = filter.PageSize.ToString(),
            };

            var url = QueryHelpers.AddQueryString("/api/services", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<ListServiceResponse>(url);

            return result;
        }

        public async Task<ListServiceResponse> GetServiceListByClinic(int clinicId)
        {
            var rs = await _httpClient.GetFromJsonAsync<ListServiceResponse>($"/api/services/clinics/{clinicId}");
            return rs;

        }

        public async Task<bool> UpdateService(ServiceRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync("/api/services", request);
            return result.IsSuccessStatusCode;
        }
    }
}
