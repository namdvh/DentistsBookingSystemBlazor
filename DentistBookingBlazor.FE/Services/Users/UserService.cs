using Blazored.LocalStorage;
using DentistBooking.ViewModels.Pagination;
using DentistBooking.ViewModels.System.Users;
using DentistBookingBlazor.FE;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace DentistBooking.Blazor.Services.Users
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;


        public UserService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var rs = await _httpClient.PostAsJsonAsync("/api/login", loginRequest);
            var content = await rs.Content.ReadAsStringAsync();
            var loginResponse = System.Text.Json.JsonSerializer.Deserialize<LoginResponse>(content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
            if (!rs.IsSuccessStatusCode)
            {
                return loginResponse;
            }
            await _localStorage.SetItemAsync("authToken", loginResponse.Token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginRequest.UserName);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.Token);
            return loginResponse;
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            var rs = await _httpClient.PostAsJsonAsync("/api/Login/register", request);
            var content = await rs.Content.ReadAsStringAsync();
            var registerResponse = System.Text.Json.JsonSerializer.Deserialize<RegisterResponse>(content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
            if (!rs.IsSuccessStatusCode)
            {
                return registerResponse;
            }

            return registerResponse;
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            var result = await _httpClient.DeleteAsync($"/api/users/{userId}");
            return result.IsSuccessStatusCode;
        }

        public async Task<UserDTO> GetUser(Guid userId)
        {
            var rs = await _httpClient.GetFromJsonAsync<UserDTO>($"/api/users/{userId}");
            return rs;
        }

        public async Task<ListUserResponse> GetUserList(PaginationFilter filter)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["PageNumber"] = filter.PageNumber.ToString(),
                ["PageSize"] = filter.PageSize.ToString(),
            };

            var url = QueryHelpers.AddQueryString("/api/users", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<ListUserResponse>(url);

            return result;
        }
        public async Task<bool> UpdateUser(UpdateUserRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync("/api/users", request);
            return result.IsSuccessStatusCode;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }

}

