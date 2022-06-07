using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Clinics;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Services.Clinics
{
    public class ClinicService : IClinicService
    {
        private readonly HttpClient _httpClient;

        public ClinicService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateClinic(ClinicRequest request)
        {
            var rs = await _httpClient.PostAsJsonAsync("/api/clinics", request);

            return rs.IsSuccessStatusCode;
            
        }

        public async Task<ClinicDTO> GetClinic(int clinicId)
        {
            var rs = await _httpClient.GetFromJsonAsync<ClinicDTO>($"/api/clinics/{clinicId}");
            return rs;
        }

        public async Task<ListClinicResponse> GetClinicList(PaginationFilter filter)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["PageNumber"] = filter.PageNumber.ToString(),
                ["PageSize"] = filter.PageSize.ToString(),
            };

            var url = QueryHelpers.AddQueryString("/api/clinics", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<ListClinicResponse>(url);

            return result;
        }

        public async Task<bool> UpdateClinic(ClinicRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync("/api/clinics", request);
            return result.IsSuccessStatusCode;


        }
    }
}
