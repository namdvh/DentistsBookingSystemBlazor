using DentistBooking.Data.DataContext;
using DentistBooking.Data.Entities;
using DentistBooking.Data.Enum;
using DentistBooking.ViewModels.System.Users;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace DentistBooking.Blazor.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;
        public UserService( IConfiguration config, HttpClient httpClient)
        {
            _config = config;
            _httpClient = httpClient;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var rs = await _httpClient.PostAsJsonAsync("/api/login", loginRequest);
            var content = await rs.Content.ReadAsStringAsync();
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                });
            if (!rs.IsSuccessStatusCode)
            {
                return loginResponse;
            }
            return loginResponse;
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            var rs = await _httpClient.PostAsJsonAsync("/api/Login/register", request);
            var content = await rs.Content.ReadAsStringAsync();
            var registerResponse = JsonSerializer.Deserialize<RegisterResponse>(content,
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

        private UserDTO MapToDto(User user, string roleName)
        {
            var userDto = new UserDTO()
            {
                Id = user.Id.ToString(),
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                Phone = user.PhoneNumber,
                Status = user.Status,
                Created_at = user.Created_at,
                role = roleName
            };
            return userDto;
        }
    }

}   

