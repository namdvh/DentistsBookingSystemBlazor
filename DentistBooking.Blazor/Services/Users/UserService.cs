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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _config;
        private readonly DentistDBContext _context;
        private readonly HttpClient _httpClient;
        public UserService(UserManager<User> userManager, SignInManager<User> signInService, RoleManager<Role> roleManager, IConfiguration config, DentistDBContext context, HttpClient httpClient)
        {
            _userManager = userManager;
            _signInManager = signInService;
            _roleManager = roleManager;
            _config = config;
            _context = context;
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
            if (rs.IsSuccessStatusCode)
            {
                var user = await _userManager.FindByNameAsync(loginRequest.UserName);
                if (user == null)
                {
                    loginResponse.Successful = false;
                    loginResponse.Error = "Username and password are invalid.";
                }

                var result = await _signInManager.PasswordSignInAsync(loginRequest.UserName, loginRequest.Password, false, false);
            }
            if (!rs.IsSuccessStatusCode)
            {
                loginResponse.Successful = false;
                loginResponse.Error = "Username and password are invalid.";
            }
            loginResponse.Successful = true;
            return loginResponse;
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            RegisterResponse response = new RegisterResponse();
            response.Messages = new();
            RegisterRequestValidator validator = new RegisterRequestValidator();
            ValidationResult results = validator.Validate(request);

            var defaultRole = _roleManager.FindByIdAsync("20efd516-f16c-41b3-b11d-bc908cd2056b").Result;

            if (!results.IsValid)
            {

                response.Content = null;
                response.Code = "200";
                foreach (var failure in results.Errors)
                {
                    response.Messages.Add(failure.ErrorMessage.ToString());
                }
                return response;
            }
            else
            {
                var user = new User()
                {
                    DOB = request.DOB,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserName = request.UserName,
                    PhoneNumber = request.PhoneNumber,
                    Status = Status.ACTIVE,
                    Gender = request.Gender,
                };

                var rs = await _userManager.CreateAsync(user, request.Password);
                if (rs.Succeeded)
                {

                    await _userManager.AddToRoleAsync(user, defaultRole.Name);
                    response.Content = user;
                    response.Code = "200";
                    response.Messages.Add("Regist successfully");

                    return response;
                }
                response.Content = null;
                response.Code = "200";
                response.Messages.Add("Username already exists ");

                return response;
            }
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

