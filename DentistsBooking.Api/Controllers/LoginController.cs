using DentistBooking.Blazor.Services.Users;
using DentistBooking.Data.Entities;
using DentistBooking.Data.Enum;
using DentistBooking.ViewModels.System.Users;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace DentistsBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        public LoginController(IConfiguration configuration, SignInManager<User> signManager, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _configuration = configuration;
            _signInManager = signManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            LoginResponse loginResponse = new LoginResponse();
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return BadRequest(new LoginResponse
                {
                    Successful = false,
                    Error = "Username and password are invalid."
                });
            }
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (!result.Succeeded)
            {
                return BadRequest(new LoginResponse
                {
                    Successful = false,
                    Error = "Username and password are invalid."
                });
            }
            return Ok(new LoginResponse { Successful = true });
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
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
                response.Successfull = false;
                foreach (var failure in results.Errors)
                {
                    response.Messages.Add(failure.ErrorMessage.ToString());
                }
                return BadRequest(response);
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
                    response.Content = user;
                    response.Code = "200";
                    response.Successfull = true;
                    response.Messages.Add("Regist successfully");
                }
                else
                {
                    response.Content = null;
                    response.Code = "200";
                    response.Successfull = false;
                    response.Messages.Add("Username already exists ");
                }
                return Ok(response);
            }
        }
    }
}
