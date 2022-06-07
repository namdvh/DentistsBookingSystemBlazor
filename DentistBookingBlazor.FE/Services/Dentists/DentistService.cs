using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Clinics;
using DentistBooking.ViewModels.System.Dentists;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DentistBookingBlazor.FE.Services.Dentists
{
    public class DentistService : IDentistService
    {
        private readonly HttpClient _httpClient;

        public DentistService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DentistResponse> GetDentistList(PaginationFilter filter)
        {
            //var result = await _httpClient.GetFromJsonAsync<DentistResponse>("api/dentists?PageNumber=" + filter.PageNumber+"&PageSize="+filter.PageSize);

            var queryStringParam = new Dictionary<string, string>
            {
                ["PageNumber"] = filter.PageNumber.ToString(),
                ["PageSize"] = filter.PageSize.ToString(),
            };

            var url = QueryHelpers.AddQueryString("/api/dentists", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<DentistResponse>(url);

            return result;
        }

        public async Task<bool> CreateDentist(AddDentistRequest request)
        {
            var rs = await _httpClient.PostAsJsonAsync("/api/dentists", request);

            return rs.IsSuccessStatusCode;

        }

        public async Task<DentistDTO> GetDentist(Guid userID)
        {
            var rs = await _httpClient.GetFromJsonAsync<DentistDTO>($"/api/dentists/{userID}");
            return rs;
        }


        public async Task<ListClinicResponse> GetClinic()
        {
            var rs = await _httpClient.GetFromJsonAsync<ListClinicResponse>($"/api/clinics");
            return rs;
        }
    }
}
